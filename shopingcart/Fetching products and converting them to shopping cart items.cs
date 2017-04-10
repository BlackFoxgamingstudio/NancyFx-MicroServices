private async Task<IEnumerable<ShoppingCartItem>>
      GetItemsFromCatalogueService(int[] productCatalogueIds)
{
  var response = await
    RequestProductFromProductCatalogue(productCatalogueIds)
    .ConfigureAwait(false);
  return await ConvertToShoppingCartItems(response)
    .ConfigureAwait(false);
}
