using System;
using System.Text.RegularExpressions;

namespace ProvableCode.Patterns
{
	public static class Example3
	{
		public class Customer
		{
			private static Regex ValidPhoneNumber = new Regex(@"\([0-9]{3}\) [0-9]{3}-[0-9]{4}");

			public string Name { get; set; }
			public string PhoneNumber { get; set; }

			public bool Validate()
			{
				if (!ValidPhoneNumber.IsMatch(PhoneNumber))
					return false;

				return true;
			}
		}

		public static void Right()
		{
			Customer customer = new Customer()
			{
				Name = "Michael L Perry",
				PhoneNumber = "(214) 222-9999"
			};

			if (!customer.Validate())
				throw new ApplicationException();
		}

		public static void Wrong()
		{
			Customer customer = new Customer()
			{
				Name = "Michael L Perry",
				PhoneNumber = "222-9999"
			};
		}
	}
}
