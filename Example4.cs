using System;

namespace QED2._02
{
	public static class Example4
	{
		public class Connection
		{
			private string _connectionString;
			private bool _connected = false;

			public string ConnectionString
			{
				get
				{
					return _connectionString;
				}
				set
				{
					if (_connected)
						throw new ApplicationException();

					_connectionString = value;
				}
			}

			public void Connect()
			{
				if (String.IsNullOrEmpty(_connectionString))
					throw new ApplicationException();

				_connected = true;
			}

			public void Disconnect()
			{
				_connected = false;
			}
		}

		public static void Right()
		{
			Connection connection = new Connection();
			connection.ConnectionString = "DataSource=//MyMachine";
			connection.Connect();
			connection.Disconnect();
		}

		public static void Wrong1()
		{
			Connection connection = new Connection();
			connection.Connect();
			connection.Disconnect();
		}

		public static void Wrong2()
		{
			Connection connection = new Connection();
			connection.ConnectionString = "DataSource=//MyMachine";
			connection.Connect();
			connection.ConnectionString = "DataSource=//HisMachine";
			connection.Disconnect();
		}
	}
}
