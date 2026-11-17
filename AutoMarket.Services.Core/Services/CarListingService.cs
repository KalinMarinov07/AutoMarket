namespace AutoMarket.Services.Core.Services
{
    using AutoMarket.Data;
    using AutoMarket.Data.Models;
    using AutoMarket.Services.Core.Contracts;
    using AutoMarket.ViewModels.Brand;
    using AutoMarket.ViewModels.CarListing;
    using AutoMarket.ViewModels.Model;
    using Microsoft.EntityFrameworkCore;

    using static Common.ApplicationConstants;

    public class CarListingService : ICarListingService
    {
        private readonly AutoMarketDbContext dbContext;

        public CarListingService(AutoMarketDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddNewCarListingAsync(CarListingInputModel inputModel)
        {
            await dbContext.CarListings.AddAsync(new CarListing
            {
                ModelId = inputModel.ModelId,
                Price = inputModel.Price,
                Mileage = inputModel.Mileage,
                ManufactureMonth = inputModel.ManufactureMonth,
                ManufactureYear = inputModel.ManufactureYear,
                EngineType = inputModel.EngineType,
                VehicleType = inputModel.VehicleType,
                ImageUrl = inputModel.ImageUrl,
                Description = inputModel.Description,
            });

            await dbContext.SaveChangesAsync();
        }

        public async Task<CarListingDetailsViewModel?> GetCarListingDetailsAsync(int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return null;
            }

            return await dbContext.CarListings
                .Where(c => c.Id == id)
                .Select(c => new CarListingDetailsViewModel
                {
                    Id = c.Id,
                    BrandName = c.Model.Brand.Name,
                    ModelName = c.Model.Name,
                    Price = c.Price.ToString(PriceDefaultFormat),
                    ManufactureDate = c.ManufactureMonth != null ? $"{c.ManufactureMonth:D2}/{c.ManufactureYear}" : $"{c.ManufactureYear}",
                    Mileage = c.Mileage.ToString(MileageDefaultFormat),
                    VehicleType = c.VehicleType.ToString(),
                    EngineType = c.EngineType.ToString(),
                    Description = c.Description != null ? c.Description : "No additional description.",
                    ImageUrl = c.ImageUrl
                })
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CarListingIndexViewModel>> GetCarListingsAsync()
        {
            return await dbContext.CarListings
                .OrderBy(c => c.Model.Brand.Name)
                .ThenBy(c => c.Model.Name)
                .ThenBy(c => c.Id)
                .Select(c => new CarListingIndexViewModel
                {
                    Id = c.Id,
                    BrandName = c.Model.Brand.Name,
                    ModelName = c.Model.Name,
                    Price = c.Price.ToString(PriceDefaultFormat),
                    ImageUrl = c.ImageUrl
                })
                .Take(EntitiesPerPage)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<BrandDropdownViewModel>> LoadAllBrandsDropdownItemsAsync()
        {
            return await dbContext.Brands
                .AsNoTracking()
                .Select(b => new BrandDropdownViewModel
                {
                    Id = b.Id,
                    Name = b.Name,
                })
                .OrderBy(b => b.Name)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<ModelDropdownViewModel>> LoadAllModelsDropdownItemsAsync()
        {
            return await dbContext.Models
                .AsNoTracking()
                .Select(m => new ModelDropdownViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    BrandId = m.BrandId,
                })
                .OrderBy(m => m.Name)
                .ToArrayAsync();
        }

        public async Task<bool> BrandExistsAsync(CarListingInputModel inputModel)
        {
            if (!await dbContext.Brands.AnyAsync(b => b.Id == inputModel.BrandId))
            {
                return false;
            }

            return true;
        }

        public async Task<bool> ModelBelongsToBrandAsync(CarListingInputModel inputModel)
        {
            if (!await dbContext.Models.AnyAsync(m => m.Id == inputModel.ModelId && m.BrandId == inputModel.BrandId))
            {
                return false;
            }

            return true;
        }

        public async Task<CarListingInputModel?> GetCarListingForEditAsync(int? id)
        {
            CarListingInputModel? carListingToEdit = await dbContext.CarListings
                .Where(c => c.Id == id)
                .Select(c => new CarListingInputModel
                {
                    BrandId = c.Model.BrandId,
                    ModelId = c.ModelId,
                    EngineType = c.EngineType,
                    VehicleType = c.VehicleType,
                    ManufactureMonth = c.ManufactureMonth,
                    ManufactureYear = c.ManufactureYear,
                    Price = c.Price,
                    Mileage = c.Mileage,
                    ImageUrl = c.ImageUrl,
                    Description = c.Description
                })
                .SingleOrDefaultAsync();

            if (carListingToEdit == null)
            {
                return null;
            }

            carListingToEdit.Brands = await LoadAllBrandsDropdownItemsAsync();
            carListingToEdit.Models = await LoadAllModelsDropdownItemsAsync();

            return carListingToEdit;
        }

        public async Task<bool> EditCarListingAsync(int? id, CarListingInputModel inputModel)
        {
            CarListing? carListingToEdit = await dbContext.CarListings
                .Where(c => c.Id == id)
                .SingleOrDefaultAsync();

            if (carListingToEdit == null)
            {
                return false;
            }

            carListingToEdit.ModelId = inputModel.ModelId;
            carListingToEdit.VehicleType = inputModel.VehicleType;
            carListingToEdit.EngineType = inputModel.EngineType;
            carListingToEdit.ManufactureMonth = inputModel.ManufactureMonth;
            carListingToEdit.ManufactureYear = inputModel.ManufactureYear;
            carListingToEdit.Price = inputModel.Price;
            carListingToEdit.Mileage = inputModel.Mileage;
            carListingToEdit.ImageUrl = inputModel.ImageUrl;
            carListingToEdit.Description = inputModel.Description;

            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}
