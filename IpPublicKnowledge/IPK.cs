using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Web.Script.Serialization;

namespace IpPublicKnowledge
{
	public static class IPK
	{
		private static string URLGetIP = "http://api.ipify.org";

		private static string URLGetAddress = "http://ip-api.com/json/";

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
				var PublicIP = wc.DownloadString(URLGetIP);

				return IPAddress.Parse(PublicIP);
			}
			catch
			{
				return null;
			}

		}

		/// <summary>
		/// Resolves all The information about the Any given Public IP address
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
				var json = wc.DownloadString(URLGetAddress + ip.ToString());

				IPI IpInfo = new JavaScriptSerializer().Deserialize<IPI>(json);

				//return IP
				IpInfo.IP = ip;

				//set Languages
				IpInfo.setLanguage();

				return IpInfo;
			}
			catch (System.Exception ex)
			{
				System.Console.WriteLine(ex.Message);
				return null;
			}
		}

		
	}
}
