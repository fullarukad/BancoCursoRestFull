﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Helpers
{
    public static class IpHelper
    {
        public static string GetIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
               if(ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {  return ip.ToString(); }
            }
            return string.Empty;
        }
    }
}
