using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace JC.Utils.Helper
{
    public static class EncryptHelper
    {
        public static string Md5(string input)
        {
            if (String.IsNullOrEmpty(input))
                return string.Empty;

            using (var md5 = MD5.Create())
            {
                var temp = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
                return temp.Aggregate<byte, string>(null, (current, t) => current + t.ToString("x2"));
            }
        }
    }
}
