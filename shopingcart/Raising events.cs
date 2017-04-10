public void AddItems(
      IEnumerable<ShoppingCartItem> shoppingCartItems,
      IEventStore eventStore)
    {
      foreach (var item in shoppingCartItems)
        if (this.items.Add(item))
          eventStore.Raise(
            "ShoppingCartItemAdded",
            new { UserId, item });
    }
