namespace AutoMarket.Web.Controllers
{
    using AutoMarket.Data;
    using AutoMarket.Services.Core.Contracts;
    using AutoMarket.ViewModels.CarListing;
    using Microsoft.AspNetCore.Mvc;

    public class CarListingController : Controller
    {
        private readonly ICarListingService carListingService;
        private readonly AutoMarketDbContext dbContext;

        public CarListingController(AutoMarketDbContext dbContext, ICarListingService carListingService)
        {
            this.dbContext = dbContext;
            this.carListingService = carListingService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<CarListingIndexViewModel> allCarListings = await carListingService.GetCarListingsAsync();

            return View(allCarListings);
        }
    }
}
