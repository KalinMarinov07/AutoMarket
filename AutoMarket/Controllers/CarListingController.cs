namespace AutoMarket.Web.Controllers
{
    using AutoMarket.Data.Models;
    using AutoMarket.Services.Core.Contracts;
    using AutoMarket.ViewModels.CarListing;
    using Microsoft.AspNetCore.Mvc;

    public class CarListingController : Controller
    {
        private readonly ILogger<CarListingController> logger;

        private readonly ICarListingService carListingService;

        public CarListingController(ILogger<CarListingController> logger, ICarListingService carListingService)
        {
            this.logger = logger;

            this.carListingService = carListingService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<CarListingIndexViewModel> allCarListings = await carListingService.GetCarListingsAsync();

            return View(allCarListings);
        }

        [HttpGet]
        public async Task<IActionResult> Details([FromRoute]int? id)
        {
            CarListingDetailsViewModel? carListingDetails = await carListingService.GetCarListingDetailsAsync(id);

            if (carListingDetails == null)
            {
                return BadRequest("Something was wrong with your request! Please try again!");
            }

            return View(carListingDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CarListingInputModel newCarListing = new CarListingInputModel
            {
                Brands = await carListingService.LoadAllBrandsDropdownItemsAsync(),
                Models = await carListingService.LoadAllModelsDropdownItemsAsync(),
            };

            return View(newCarListing);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarListingInputModel inputModel)
        {
            if (!await carListingService.BrandExistsAsync(inputModel))
            {
                ModelState.AddModelError(nameof(CarListingInputModel.BrandId), "Invalid Brand selected!");

                inputModel.Brands = await carListingService.LoadAllBrandsDropdownItemsAsync();
                inputModel.Models = await carListingService.LoadAllModelsDropdownItemsAsync();

                return View(inputModel);
            }

            if (!await carListingService.ModelBelongsToBrandAsync(inputModel))
            {
                ModelState.AddModelError(nameof(CarListingInputModel.ModelId), "Invalid Model selected!");

                inputModel.Brands = await carListingService.LoadAllBrandsDropdownItemsAsync();
                inputModel.Models = await carListingService.LoadAllModelsDropdownItemsAsync();

                return View(inputModel);
            }

            if (!ModelState.IsValid)
            {
                inputModel.Brands = await carListingService.LoadAllBrandsDropdownItemsAsync();
                inputModel.Models = await carListingService.LoadAllModelsDropdownItemsAsync();

                return View(inputModel);
            }

            try
            {
                await carListingService.AddNewCarListingAsync(inputModel);

                TempData["Success"] = "Successfully added a new car listing!";
            }
            catch (Exception ex)
            {
                logger.LogError("Error occurred while trying to save valid car listing!");

                TempData["Error"] = "Unexpected error occurred! Please try again!";
            }

            return RedirectToAction("Index", "CarListing");
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute]int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return BadRequest("There was something wrong with your request! Please try again!");
            }

            CarListingInputModel? carListingToEdit = await carListingService.GetCarListingForEditAsync(id);

            if (carListingToEdit == null)
            {
                return NotFound("Car listing was not found!");
            }

            ViewData["CarListingId"] = id;

            return View(carListingToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int? id, CarListingInputModel inputModel)
        {
            if (!id.HasValue || id <= 0)
            {
                return BadRequest("There was something wrong with your request! Please try again!");
            }

            if (!await carListingService.BrandExistsAsync(inputModel))
            {
                ModelState.AddModelError(nameof(CarListingInputModel.BrandId), "Invalid Brand selected!");

                inputModel.Brands = await carListingService.LoadAllBrandsDropdownItemsAsync();
                inputModel.Models = await carListingService.LoadAllModelsDropdownItemsAsync();
                ViewData["CarListingId"] = id;

                return View(inputModel);
            }

            if (!await carListingService.ModelBelongsToBrandAsync(inputModel))
            {
                ModelState.AddModelError(nameof(CarListingInputModel.ModelId), "Invalid Model selected!");

                inputModel.Brands = await carListingService.LoadAllBrandsDropdownItemsAsync();
                inputModel.Models = await carListingService.LoadAllModelsDropdownItemsAsync();
                ViewData["CarListingId"] = id;

                return View(inputModel);
            }

            if (!ModelState.IsValid)
            {
                inputModel.Brands = await carListingService.LoadAllBrandsDropdownItemsAsync();
                inputModel.Models = await carListingService.LoadAllModelsDropdownItemsAsync();
                ViewData["CarListingId"] = id;

                return View(inputModel);
            }

            

            try
            {
                bool isCarListingFound = await carListingService.EditCarListingAsync(id, inputModel);

                if (!isCarListingFound)
                {
                    return NotFound("Car listing was not found!");
                }

                TempData["Success"] = "Successfully edited car listing!";
            }
            catch (Exception ex)
            {
                logger.LogError("Error occurred while trying to save valid car listing!");

                TempData["Error"] = "Unexpected error occurred! Please try again!";
            }

            return RedirectToAction("Index", "CarListing");
        }

        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute]int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return BadRequest("There was something wrong with your request! Please try again!");
            }

            CarListingDeleteViewModel? carListingToDelete = await carListingService.GetCarListingForDeleteAsync(id);

            if (carListingToDelete == null)
            {
                return NotFound("Car listing was not found!");
            }

            ViewData["CarListingId"] = id;

            return View(carListingToDelete);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute]int? id, CarListingDeleteViewModel deleteViewModel)
        {
            if (!id.HasValue || id <= 0 || id != deleteViewModel.Id)
            {
                return BadRequest("There was something wrong with your request! Please try again!");
            }

            try
            {
                bool isCarListingFound = await carListingService.DeleteCarListingAsync(id, deleteViewModel);

                if (!isCarListingFound)
                {
                    return NotFound("Car listing was not found!");
                }

                TempData["Success"] = "Successfully deleted car listing!";
            }
            catch (Exception ex)
            {

                logger.LogError("Error occurred while trying to save valid car listing!");

                TempData["Error"] = "Unexpected error occurred! Please try again!";
            }

            return RedirectToAction("Index", "CarListing");
        }
    }
}
