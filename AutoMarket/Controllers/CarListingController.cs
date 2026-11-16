namespace AutoMarket.Web.Controllers
{
    using AutoMarket.Data;
    using AutoMarket.Services.Core.Contracts;
    using AutoMarket.ViewModels.CarListing;
    using Microsoft.AspNetCore.Mvc;

    public class CarListingController : Controller
    {
        private readonly ICarListingService carListingService;

        public CarListingController(ICarListingService carListingService)
        {
            this.carListingService = carListingService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<CarListingIndexViewModel> allCarListings = await carListingService.GetCarListingsAsync();

            return View(allCarListings);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            CarListingDetailsViewModel? carListingDetails = await carListingService.GetCarListingDetailsAsync(id);

            if (carListingDetails == null)
            {
                return BadRequest("Something was wrong with your request! Please try again!");
            }

            return View(carListingDetails);
        }
    }
}
