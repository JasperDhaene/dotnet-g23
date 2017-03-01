using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Helpers
{
    public class MailHelper
    {

	    public static bool VerifyMailAddress(string address, string orgdomain)
	    {
		    if (orgdomain == GetMailDomain(address))
				return true;
		    return false;
	    }

	    public static string GetMailDomain(string address) {
			return address.Substring(address.IndexOf('@'), address.Length - 1);
		}
	}
}
