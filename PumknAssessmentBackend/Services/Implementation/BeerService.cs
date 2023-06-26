using Microsoft.AspNetCore.Routing.Tree;
using PumknAssessmentBackend.Helpers;
using PumknAssessmentBackend.Models;
using PumknAssessmentBackend.Services.Interfaces;
using System.Net;
using System.Net.Http;

namespace PumknAssessmentBackend.Services.Implementation
{
	public class BeerService : IBeerService
	{
		private readonly IExternalBeerService _externalBeerService;

		public BeerService(IExternalBeerService externalBeerService) 
		{
			_externalBeerService = externalBeerService;
		}

		/// <summary>
		/// Gets all beers.
		/// </summary>
		/// <returns></returns>
		public async Task<BackendServiceResponse<List<Beer>>> GetAllBeers()
		{
			BackendServiceResponse<List<Beer>> response = new();

			try
			{
				var url = EndpointHelper.GetAllBeers;
				var externalResponse = await _externalBeerService.CallExternalService(url);

				if(externalResponse.Success ==  true) 
				{
					response.Success = true;
					response.Message = "Beers obtained successfully";
					response.Data = externalResponse.Data;
				}
				else
				{
					response.Success = false;
					response.Message = externalResponse.Message;
					response.StatusCode = externalResponse.StatusCode;
				}
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = ex.Message;
				response.StatusCode = HttpStatusCode.InternalServerError;
			
				//Log Error Here
			}

			return response;
		}

		/// <summary>
		/// Gets the beer by identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public async Task<BackendServiceResponse<Beer>> GetBeerById(int id)
		{
			BackendServiceResponse<Beer> response = new();

			try
			{
				var url = EndpointHelper.GetBeerById;
				var externalResponse = await _externalBeerService.CallExternalService(url + id.ToString());

				if (externalResponse.Success == true)
				{
					response.Success = true;
					response.Message = "Beer found successfully";

					if (externalResponse?.Data?.Count > 0)
					{
						response.Data = externalResponse?.Data?.FirstOrDefault();
					}
				}
				else
				{
					response.Success = false;
					response.Message = externalResponse.Message;
					response.StatusCode = externalResponse.StatusCode;
				}
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = ex.Message;
				response.StatusCode = HttpStatusCode.InternalServerError;

				//Log Error Here
			}

			return response;
		}

		/// <summary>
		/// Gets the random beer.
		/// </summary>
		/// <returns></returns>
		public async Task<BackendServiceResponse<Beer>> GetRandomBeer()
		{
			BackendServiceResponse<Beer> response = new();

			try
			{
				var url = EndpointHelper.GetRandomBeer;
				var externalResponse = await _externalBeerService.CallExternalService(url);

				if (externalResponse.Success == true)
				{
					response.Success = true;
					response.Message = "Random beer obtained successfully";

					if (externalResponse?.Data?.Count > 0)
					{
						response.Data = externalResponse?.Data?.FirstOrDefault();
					}
				}
				else
				{
					response.Success = false;
					response.Message = externalResponse.Message;
					response.StatusCode = externalResponse.StatusCode;
				}
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = ex.Message;
				response.StatusCode = HttpStatusCode.InternalServerError;

				//Log Error Here
			}

			return response;
		}

		/// <summary>
		/// Searches the beer.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public async Task<BackendServiceResponse<List<Beer>>> SearchBeer(string name)
		{
			BackendServiceResponse<List<Beer>> response = new();

			try
			{
				var url = EndpointHelper.SearchBeer;
				var externalResponse = await _externalBeerService.CallExternalService(url + name);

				if (externalResponse.Success == true)
				{
					response.Success = true;
					response.Message = "Search results obtained successfully";
					response.Data = externalResponse.Data;
				}
				else
				{
					response.Success = false;
					response.Message = externalResponse.Message;
					response.StatusCode = externalResponse.StatusCode;
				}
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = ex.Message;
				response.StatusCode = HttpStatusCode.InternalServerError;

				//Log Error Here
			}

			return response;
		}
	}
}
