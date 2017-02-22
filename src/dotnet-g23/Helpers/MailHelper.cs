using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Helpers
{
    public class MailHelper
    {

	    public static bool VerifyMailAddress(string address, string[] approved = null)
	    {
			approved = approved ?? new string[] { "temp.com" };

		    if (Array.IndexOf(approved, GetMailExtension(address)) > -1)
				return true;
		    return false;
	    }

	    private static string GetMailExtension(string address) {
			return address.Substring(address.IndexOf('@'), address.Length - 1);
		}
	}
}
