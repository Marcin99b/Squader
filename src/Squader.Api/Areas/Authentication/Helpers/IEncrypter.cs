using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Squader.Api.Areas.Authentication.Helpers
{
    public interface IEncrypter
    {
        string GetSalt(string value);
        string GetHash(string value, string salt);
        string GetSalt();
    }
}
