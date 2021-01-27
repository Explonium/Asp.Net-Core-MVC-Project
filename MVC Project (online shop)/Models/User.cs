using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Security.Cryptography;

namespace MVC_Project__online_shop_.Models
{
    public class User
    {
        public int Id { get; set; }

        // Login data
        public string Username { get; set; }
        public string Email { get; set; }

        // Password data
        public string EncryptedPassword { get; set; }                    // Encrypted password = SHA1(Password + Salt)
        public string Salt { get; set; } = Guid.NewGuid().ToString();    // Salt

        // Additional user info
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool CheckUser(string password) => EncryptedPassword == EncryptPassword(password);

        private string EncryptPassword(string password)
        {
            var data = Encoding.ASCII.GetBytes(password + Salt);
            var sha1data = new SHA1CryptoServiceProvider().ComputeHash(data);

            string result = new ASCIIEncoding().GetString(sha1data);
            return result;
        }
    }
}
