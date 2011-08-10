using System;

namespace QED2._02
{
	public static class Example2
	{
		public class Cache<TKey, TItem>
		{
			public bool Contains(TKey key)
			{
				return false;
			}

			public void Add(TKey key, TItem item)
			{
				if (Contains(key))
					throw new ApplicationException();
			}

			public TItem Get(TKey key)
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

			if (cache.Contains(key))
			{
				value = cache.Get(key);
			}
			else
			{
				value = LoadValue(key);
				cache.Add(key, value);
			}
		}

		public static void Wrong1()
		{
			Cache<int, string> cache = new Cache<int, string>();
			int key = 42;
			string value;

			value = cache.Get(key);
			if (value == null)
			{
				value = LoadValue(key);
				cache.Add(key, value);
			}
		}

		public static void Wrong2()
		{
			Cache<int, string> cache = new Cache<int, string>();
			int key = 42;
			string value;

			value = LoadValue(key);
			cache.Add(key, value);
		}

		private static string LoadValue(int key)
		{
			return "the value";
		}
	}
}
