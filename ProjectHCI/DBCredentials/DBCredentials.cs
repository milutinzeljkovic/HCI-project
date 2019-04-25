using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHCI.DBCredentials
{
	public class DBCredential
	{
		




		private string username;

		public string Username
		{
			get { return username; }
			set { username = value; }
		}

		private string password;

		public string Password
		{
			get { return password; }
			set { password = value; }
		}

		private string database;

		public string Database
		{
			get { return database; }
			set { database = value; }
		}
		private string server;

		public string Server
		{
			get { return server; }
			set { server = value; }
		}

		private DBCredential()
		{
			using (StreamReader r = new StreamReader(@"C:\Users\milutin\source\repos\HCI-project\ProjectHCI\config.json")) 
			{
				var json = r.ReadToEnd();
				
				var jobj = JObject.Parse(json);
				Console.WriteLine(json);
				string[] tokens = json.Split(',');
				Console.WriteLine(tokens[1].Split(':')[1]);
				this.Server = (tokens[1].Split(':')[1]);
				this.Database = (tokens[2].Split(':')[1]);
				this.Username = (tokens[0].Split(':')[1]);
				this.Password = (tokens[3].Split(':')[1]);

				

			}
		}

		private static DBCredential _instance = null;
		public static DBCredential Instance()
		{
			if (_instance == null)
				_instance = new DBCredential();
			return _instance;
		}



	}
}
