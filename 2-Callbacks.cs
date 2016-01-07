using System;

namespace ProvableCode.Patterns
{
	public static class Example2
	{
		public class Cache<TKey, TItem>
		{
            public TItem Get(TKey key, Func<TKey, TItem> loadValue)
            {
                TItem value;
                if (Contains(key))
                {
                    value = Get(key);
                }
                else
                {
                    value = loadValue(key);
                    Add(key, value);
                }
                return value;
            }

            private bool Contains(TKey key)
			{
				return false;
			}

			private void Add(TKey key, TItem item)
			{
				if (Contains(key))
					throw new ApplicationException();
			}

			private TItem Get(TKey key)
			{
				if (!Contains(key))
					throw new ApplicationException();

				return default(TItem);
			}
		}

		public static void Right()
		{
			Cache<int, string> cache = new Cache<int, string>();
			int key = 42;
			string value;
            Func<int, string> loadValue = LoadValue;

            value = cache.Get(key, loadValue);
		}

		//public static void Wrong1()
		//{
		//	Cache<int, string> cache = new Cache<int, string>();
		//	int key = 42;
		//	string value;

		//	value = cache.Get(key);
		//	if (value == null)
		//	{
		//		value = LoadValue(key);
		//		cache.Add(key, value);
		//	}
		//}

		//public static void Wrong2()
		//{
		//	Cache<int, string> cache = new Cache<int, string>();
		//	int key = 42;
		//	string value;

		//	value = LoadValue(key);
		//	cache.Add(key, value);
		//}

		private static string LoadValue(int key)
		{
			return "the value";
		}
	}
}
