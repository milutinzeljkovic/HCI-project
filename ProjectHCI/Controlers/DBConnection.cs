using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHCI.Controlers
{
	public class DBConnection
	{
		private DBConnection()
		{
		}

		private string databaseName = string.Empty;
		private string username = string.Empty;
		private string password = string.Empty;
		private string server = string.Empty;

		public string DatabaseName
		{
			get { return databaseName; }
			set { databaseName = value; }
		}

		public string Server { get; set; }
		public string Password { get; set; }
		public string Username { get; set; }

		private MySql.Data.MySqlClient.MySqlConnection connection = null;
		public MySql.Data.MySqlClient.MySqlConnection Connection
		{
			get { return connection; }
		}

		private static DBConnection _instance = null;
		public static DBConnection Instance()
		{
			if (_instance == null)
				_instance = new DBConnection();
			return _instance;
		}

		public bool IsConnect()
		{
			if (Connection == null)
			{
				if (String.IsNullOrEmpty(databaseName))
					return false;

				string connstring = string.Format("Server="+Server+"; database={0}; UID=" + Username + "; password=" + Password, databaseName);
				connection = new MySql.Data.MySqlClient.MySqlConnection(connstring);
				connection.Open();
			}

			return true;
		}

		public void Close()
		{
			connection.Close();
		}
	}
}
