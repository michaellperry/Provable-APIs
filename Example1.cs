using System;

namespace QED2._02
{
    public static class Example1
	{
		public class Transaction
		{
		}

		public class ShoppingService
		{
			public Transaction Transaction { get; set; }

			public void AddToCart(int cartId, int itemId, int quantity)
			{
			}
		}

		public static void Right()
		{
			ShoppingService shoppingService = new ShoppingService();
			shoppingService.Transaction = new Transaction();
			shoppingService.AddToCart(1, 2, 3);
		}

		public static void Wrong()
		{
			ShoppingService shoppingService = new ShoppingService();
			shoppingService.AddToCart(1, 2, 3);
		}
	}
}
