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

        public class CustomerRepository
        {
            public void Save(Customer customer)
            {
                if (!customer.Validate())
                    throw new ArgumentException();
            }
        }

		public static void Right()
		{
            var repository = new CustomerRepository();
			Customer customer = new Customer()
			{
				Name = "Michael L Perry",
				PhoneNumber = "(214) 222-9999"
			};

            if (!customer.Validate())
                Console.WriteLine("Invalid customer");
            else
                repository.Save(customer);
		}

		public static void Wrong()
		{
            var repository = new CustomerRepository();
            Customer customer = new Customer()
			{
				Name = "Michael L Perry",
				PhoneNumber = "222-9999"
			};

            repository.Save(customer);
        }
    }
}
