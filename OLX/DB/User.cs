using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLX.DB
{
    public class User
    {
        public int UserID {  get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();

        public User(string Login, string Password) 
        {
            this.Login = Login;
            this.Password = Password;

        }


        public User()
        {

        }
    }


}
