namespace ShoppingCart.ShoppingCart
{
  using EventFeed;
  using Nancy;
  using Nancy.ModelBinding;

  public class ShoppingCartModule : NancyModule
  {
    public ShoppingCartModule(
      IShoppingCartStore shoppingCartStore,
      IProductCatalogueClient productCatalogue,
      IEventStore eventStore) 
      : base("/shoppingcart")
    {
…

  Delete("/{userid:int}/items", parameters =>
      {
        var productCatalogueIds = this.Bind<int[]>();
        var userId = (int)parameters.userid;

        var shoppingCart = shoppingCartStore.Get(userId);
        shoppingCart.RemoveItems(productCatalogueIds, eventStore);
        shoppingCartStore.Save(shoppingCart);

        return shoppingCart;
      });
    }
  }
}
