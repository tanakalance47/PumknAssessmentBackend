using Microsoft.AspNetCore.Mvc;
using PumknAssessmentBackend.Models;
using PumknAssessmentBackend.Services.Interfaces;

namespace PumknAssessmentBackend.Controllers
{
	[ApiController]
	public class BeerController : ControllerBase
	{
		private readonly IBeerService _beerService;
		public BeerController(IBeerService beerService) 
		{ 
		   _beerService = beerService;
		}

		[HttpGet]
		[Route("/beer/menu")]
		public async Task<ActionResult<BackendServiceResponse<List<Beer>>>> GetAllBeers()
		{
			BackendServiceResponse<List<Beer>> response = await _beerService.GetAllBeers();

			return response.Success ? Ok(response) : StatusCode((int)response.StatusCode, response.Message);
		}

		[HttpGet]
		[Route("/beer/random")]
		public async Task<ActionResult<BackendServiceResponse<Beer>>> GetRandomBeer()
		{
			BackendServiceResponse<Beer> response = await _beerService.GetRandomBeer();

			return response.Success ? Ok(response) : StatusCode((int)response.StatusCode, response.Message);
		}

		[HttpGet]
		[Route("/beer/{id}")]
		public async Task<ActionResult<BackendServiceResponse<Beer>>> GetBeerById(int id)
		{
			BackendServiceResponse<Beer> response = await _beerService.GetBeerById(id);

			return response.Success ? Ok(response) : StatusCode((int)response.StatusCode, response.Message);
		}
	}
}