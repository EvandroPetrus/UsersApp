using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Application.Helpers
{
    public class SHA1Helper
    {
        public static string Encrypt(string value)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                var hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(value));
                var sb = new StringBuilder();

                foreach (var item in hashBytes)
                    sb.Append(item.ToString("x2"));

                return sb.ToString();
            }
        }
    }
}
