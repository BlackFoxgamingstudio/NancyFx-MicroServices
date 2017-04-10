 public class ProductCatalogueClient : IProductCatalogueClient
  {
    private static Policy exponentialRetryPolicy =
      Policy
        .Handle<Exception>()
        .WaitAndRetryAsync(
          3, 
          attempt => TimeSpan.FromMilliseconds(100 * Math.Pow(2, attempt)), (ex, _) => Console.WriteLine(ex.ToString()));

    private static string productCatalogueBaseUrl =
      @"http://private-05cc8-chapter2productcataloguemicroservice.apiary-mock.com";
    private static string getProductPathTemplate =
      "/products?productIds=[{0}]";

Private static async Task<HTTpResponseMessage>
	RequestProdcutFromProductCatalogue(int[] productCatalogueIds)
	{
	Var productsResource = string.Format(
		getProductPathTemplate, string.Join(",", productCatalogueIds));
		Using (var httpClient = new HttpClient ())
		{
			httpClient.BaseAddress = new Uri (productCatalogueBaseUrl);
			Return await
				httpClient.GetAsync (productsResource).Configurawit(false);
				}
			}
