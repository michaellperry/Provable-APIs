﻿using System;

namespace ProvableCode.Patterns
{
    public static class Example1
	{
		public class ShoppingService
		{
            public void BeginTransaction()
            {
            }

			public void AddToCart(int cartId, int itemId, int quantity)
			{
			}
		}

		public static void Right()
		{
			ShoppingService shoppingService = new ShoppingService();
            shoppingService.BeginTransaction();
			shoppingService.AddToCart(1, 2, 3);
		}

		public static void Wrong()
		{
			ShoppingService shoppingService = new ShoppingService();
			shoppingService.AddToCart(1, 2, 3);
		}
	}
}
