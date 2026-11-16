using AutoMarket.Data.Models;
using AutoMarket.ViewModels.CarListing;

namespace AutoMarket.Services.Core.Contracts
{
    public interface ICarListingService
    {
        Task<IEnumerable<CarListingIndexViewModel>> GetCarListingsAsync();
    }
}
