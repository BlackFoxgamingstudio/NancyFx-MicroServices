  private static Policy exponentialRetryPolicy =
      Policy
        .Handle<Exception>()
        .WaitAndRetryAsync(
          3, 
          attempt => TimeSpan.FromMilliseconds(100 * Math.Pow(2, attempt)), (ex, _) => Console.WriteLine(ex.ToString()));



    public Task<IEnumerable<ShoppingCartItem>>
      GetShoppingCartItems(int[] productCatalogueIds) =>
      exponentialRetryPolicy
        .ExecuteAsync(async () => await GetItemsFromCatalogueService(productCatalogueIds).ConfigureAwait(false));
