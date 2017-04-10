private static async Task<IEnumerable<ShoppingCartItem>> ConvertToShoppingCartItems(HttpResponseMessage response)
    {
      response.EnsureSuccessStatusCode();
      var products = 
        JsonConvert.DeserializeObject<List<ProductCatalogueProduct>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
      return
        products
          .Select(p => new ShoppingCartItem(
            int.Parse(p.ProductId),
            p.ProductName,
            p.ProductDescription,
            p.Price
        ));
    }

    private class ProductCatalogueProduct
    {
      public string ProductId { get; set; }
      public string ProductName { get; set; }
      public string ProductDescription { get; set; }
      public Money Price { get; set; }
    }
