using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PumknAssessmentBackend.Models;
using PumknAssessmentBackend.Models.DTOs;
using PumknAssessmentBackend.Services.Interfaces;

namespace PumknAssessmentBackend.Controllers
{
	[ApiController]
	public class SearchController : ControllerBase
	{
		private readonly IBeerService _beerService;
		public SearchController(IBeerService beerService) 
		{
			_beerService = beerService;
		}

		[HttpPost]
		[Route("/search")]
		public async Task<ActionResult<BackendServiceResponse<List<Beer>>>> GetRandomBeer([FromBody] SearchQueryDto searchQueryDto)
		{
			BackendServiceResponse<List<Beer>> response = await _beerService.SearchBeer(searchQueryDto.Query);

			return response.Success ? Ok(response) : StatusCode((int)response.StatusCode, response.Message);
		}
	}
}
