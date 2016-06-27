using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Web.Script.Serialization;

namespace IpPublicKnowledge
{
	public static class IPK
	{
		public static string URLGetIP = "http://api.ipify.org";

		public static string URLGetAdress = "http://ip-api.com/json/";

		/// <summary>
		/// Resolves the public IP address and returns it as a string.
		/// </summary>
		/// <returns>
		/// A IPAddress object containing the IP address, or an Null if an error is
		/// encountered.
		/// </returns>
		public static IPAddress GetMyPublicIp()
		{
			try
			{
				WebClient wc = new WebClient();

				//get MyPublic IP
				var json = wc.DownloadString(URLGetIP);

				return IPAddress.Parse(json);
			}
			catch
			{
				return null;
			}

		}

		/// <summary>
		/// Resolves all The information about the Public Op address
		/// </summary>
		/// <param name="IPAddress">
		/// IP address to be resolved
		/// </param>
		/// <returns>
		/// An instance of <see cref="IPI" /> containing all information about the IP Address
		/// </returns>
		public static IPI GetIpInfo(IPAddress ip)
		{

			try
			{
				WebClient wc = new WebClient();


				//get all IP related information from the webservice.
				var json = wc.DownloadString(URLGetAdress + ip.ToString());

				IPI data = new JavaScriptSerializer().Deserialize<IPI>(json);

				var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);

				//return IP
				data.IP = ip;

				//set Languages
				setLanguage(ref data);
				return data;

			}
			catch (System.Exception ex)
			{
				System.Console.WriteLine(ex.Message);
				return null;
			}
		}

		public static void setLanguage(ref IPI data)
		{

			var cinfo = CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures);
			data.languages = new Dictionary<string, string>();
			try
			{
				foreach (CultureInfo cul in cinfo)
				{
					if (cul.DisplayName.Contains(data.country + ")"))
					{
						data.languages.Add(cul.Name, cul.DisplayName);
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
