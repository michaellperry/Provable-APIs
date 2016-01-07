using System;
using System.Text.RegularExpressions;

namespace ProvableCode.Patterns
{
	public static class Example5
	{
		public class Customer
		{
			private static Regex ValidPhoneNumber = new Regex(@"\([0-9]{3}\) [0-9]{3}-[0-9]{4}");

			public string Name { get; }
			public string PhoneNumber { get; }

            private Customer(string name, string phoneNumber)
            {
                Name = name;
                PhoneNumber = phoneNumber;
            }

            public static Customer Create(string name, string phoneNumber)
            {
                if (ValidPhoneNumber.IsMatch(phoneNumber))
                {
                    return new Customer(name, phoneNumber);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
		}

        public class CustomerRepository
        {
            public void Save(Customer customer)
            {
            }
        }

		public static void Right()
		{
            var repository = new CustomerRepository();
            try
            {
                Customer customer = Customer.Create("Michael L Perry", "(214) 222-9999");
                repository.Save(customer);
            }
            catch (Exception ex)
            {
                
            }

		}

		//public static void Wrong()
		//{
  //          var repository = new CustomerRepository();
  //          Customer customer = new Customer()
		//	{
		//		Name = "Michael L Perry",
		//		PhoneNumber = "222-9999"
		//	};

  //          repository.Save(customer);
  //      }
    }
}
