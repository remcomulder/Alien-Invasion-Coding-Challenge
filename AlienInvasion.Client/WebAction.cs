using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace AlienInvasion.Client
{
	public class WebAction
	{
		private byte[] HttpPost(string url, string postData)
		{
			byte[] data = Encoding.ASCII.GetBytes(postData);

			var myRequest = (HttpWebRequest) WebRequest.Create(url);
			myRequest.Method = "POST";
			myRequest.ContentType = "application/x-www-form-urlencoded";
			myRequest.ContentLength = data.Length;
			myRequest.Timeout = 15000;

			WebResponse response;
			try
			{
				Stream newStream = myRequest.GetRequestStream();
				newStream.Write(data, 0, data.Length);
				newStream.Close();
				response = myRequest.GetResponse();
			}
			catch (WebException webEx)
			{
				response = webEx.Response;

				if (response == null)
					return null;
			}
			catch (Exception)
			{
				return null;
			}

			Stream responseStream = response.GetResponseStream();
			var memStream = new MemoryStream();

			var respBuffer = new byte[10000];
			try
			{
				int bytesRead = responseStream.Read(respBuffer, 0, respBuffer.Length);
				while (bytesRead > 0)
				{
					memStream.Write(respBuffer, 0, bytesRead);
					bytesRead = responseStream.Read(respBuffer, 0, respBuffer.Length);
				}
			}
			finally
			{
				responseStream.Close();
				response.Close();
			}

			return memStream.ToArray();
		}

		public byte[] HttpPostForm(string url, IDictionary<string, string> formValues)
		{
			var sb = new StringBuilder();

			foreach (var keyValue in formValues)
			{
				sb.Append(HttpUtility.UrlEncode(keyValue.Key) + "=" + HttpUtility.UrlEncode(keyValue.Value));
				sb.Append("&");
			}

			return HttpPost(url, sb.ToString().TrimEnd('&'));
		}
	}
}
