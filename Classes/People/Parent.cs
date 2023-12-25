using Masrofy4.Classes.People;
using System.Security.Cryptography;
using System.Text;

namespace Masrofy4.Classes
{
    public class Parent : Person
    {
        public string otpKey { get; set; }
        public string nationalID { get; set; }
        public string userName { get; set; }

        // for db integrity
        private string password { get; set; }

        public Parent(string name, string mobileNum, string nationalID, string userName)
        {
            this.name = name;
            this.mobileNum = mobileNum;
            this.nationalID = nationalID;
            this.userName = userName;
            
        }

        //formats the string as two uppercase hexadecimal characters
        public static string HashPassword(string pw)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in pw)
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }
    }
}