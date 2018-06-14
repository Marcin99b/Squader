using System;
using System.Collections.Generic;
using System.Text;

namespace Squader.Common.Settings
{
    
    
    public class JwtSettings
    {
         public string Key { get; set; }
         public string Issuer { get; set; }
         public int ExpiryMinutes { get; set; }
    }
    
}
