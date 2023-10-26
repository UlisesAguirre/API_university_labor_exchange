using API_university_labor_exchange.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace API_university_labor_exchange.Services.Implementations
{
    public class Encrypt : IEncrypt
    {
        public string GetSHA256(string password)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encodign = new ASCIIEncoding();
            byte [] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}
