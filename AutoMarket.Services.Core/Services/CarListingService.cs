namespace AutoMarket.Services.Core.Services
{
    using AutoMarket.Data;
    using AutoMarket.Services.Core.Contracts;
    using AutoMarket.ViewModels.CarListing;
    using Microsoft.EntityFrameworkCore;

    using static Common.ApplicationConstants;

    public class CarListingService : ICarListingService
    {
        private readonly AutoMarketDbContext dbContext;

        public CarListingService(AutoMarketDbContext dbContext)
        {
            this.dbContext = dbContext;
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
                    Price = c.Price.ToString("N2"),
                    ImageUrl = c.ImageUrl
                })
                .Take(EntitiesPerPage)
                .ToArrayAsync();
        }
    }
}
