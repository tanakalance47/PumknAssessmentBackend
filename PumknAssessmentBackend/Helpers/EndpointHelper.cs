namespace PumknAssessmentBackend.Helpers
{
	public static class EndpointHelper
	{
		public const string GetAllBeers = "https://api.punkapi.com/v2/beers";
		public const string GetRandomBeer = "https://api.punkapi.com/v2/beers/random";
		public const string SearchBeer = "https://api.punkapi.com/v2/beers?beer_name=";
		public const string GetBeerById = "https://api.punkapi.com/v2/beers/";
	}
}