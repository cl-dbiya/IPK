using System.Collections.Generic;
using System.Globalization;

namespace IpPublicKnowledge
{
	public class IPI
	{
		public System.Net.IPAddress IP { get; set; }

		public string AS { get; set; }

		public string city { get; set; }

		public string country { get; set; }

		public string countryCode { get; set; }

		public string isp { get; set; }

		public string lat { get; set; }

		public string lon { get; set; }

		public string org { get; set; }

		public string query { get; set; }

		public string region { get; set; }

		public string regionName { get; set; }

		public string status { get; set; }

		public string timezone { get; set; }

		public string zip { get; set; }

		//set Language and language code.
		public Dictionary<string, string> languages { get; set; }

		public IPI() { }

		public void setLanguage()
		{

			var cinfo = CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures);
			this.languages = new Dictionary<string, string>();
			try
			{
				foreach (CultureInfo cul in cinfo)
				{
					if (cul.DisplayName.Contains(this.country + ")"))
					{
						this.languages.Add(cul.Name, cul.DisplayName);
					}
				}
			}
			catch (System.Exception ex)
			{
				System.Console.WriteLine(ex.Message);
			}
		}
	}
}
