namespace AutoMarket.Services.Core.Contracts
{
    using AutoMarket.Data.Models;
    using AutoMarket.ViewModels.Brand;
    using AutoMarket.ViewModels.CarListing;
    using AutoMarket.ViewModels.Model;

    public interface ICarListingService
    {
        Task<IEnumerable<CarListingIndexViewModel>> GetCarListingsAsync();

        Task<CarListingDetailsViewModel?> GetCarListingDetailsAsync(int? id);

        Task<IEnumerable<BrandDropdownViewModel>> LoadAllBrandsDropdownItemsAsync();

        Task<IEnumerable<ModelDropdownViewModel>> LoadAllModelsDropdownItemsAsync();

        Task AddNewCarListingAsync(CarListingInputModel inputModel);

        Task<bool> BrandExistsAsync(CarListingInputModel inputModel);

        Task<bool> ModelBelongsToBrandAsync(CarListingInputModel inputModel);

        Task<CarListingInputModel?> GetCarListingForEditAsync(int? id);
    }
}
