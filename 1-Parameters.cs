using System;

namespace ProvableCode.Patterns
{
    public static class Example1
	{
        public class Transaction { }

		public class ShoppingService
		{

            public Transaction BeginTransaction()
            {
                return new Transaction();
            }

			public void AddToCart(Transaction transaction, int cartId, int itemId, int quantity)
			{
			}
		}

		public static void Right()
		{
			ShoppingService shoppingService = new ShoppingService();
            var t = shoppingService.BeginTransaction();
			shoppingService.AddToCart(t, 1, 2, 3);
		}

		//public static void Wrong()
		//{
		//	ShoppingService shoppingService = new ShoppingService();
		//	shoppingService.AddToCart(1, 2, 3);
		//}
	}
}
