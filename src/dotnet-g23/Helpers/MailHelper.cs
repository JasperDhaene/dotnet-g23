using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Helpers
{
    public class MailHelper
    {
	    public static string GetMailDomain(String address) {
	        return address.Split('@').Last();
	    }
	}
}
