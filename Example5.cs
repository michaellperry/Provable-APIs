using System;

namespace QED2._02
{
	public static class Example5
	{
		public class Transaction : IDisposable
		{
			public void Dispose()
			{
			}
		}

		public class ShoppingService
		{
			public void AddToCart(Transaction transaction, int cartId, int itemId, int quantity)
			{
			}
		}

		public static void Right()
		{
			ShoppingService shoppingService = new ShoppingService();
			using (Transaction transaction = new Transaction())
			{
				shoppingService.AddToCart(transaction, 1, 2, 3);
			}
		}

		public static void Wrong()
		{
			ShoppingService shoppingService = new ShoppingService();
			shoppingService.AddToCart(new Transaction(), 1, 2, 3);
		}
	}
}
