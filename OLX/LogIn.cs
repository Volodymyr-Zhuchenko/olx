using OLX.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLX
{
    public static class LogIn
    {
        public static User Connect()
        {
            using (Data data = new Data())
            {
                Console.WriteLine("Input your login:");
                string login = Console.ReadLine();
                User user = data.Users.FirstOrDefault(l => l.Login == login);
                if (user != null)
                {
                    Console.WriteLine("Input password:");
                    string password = Console.ReadLine();
                    if (user.Password == password )
                    {
                        Console.WriteLine("Connect is sucсessfull");
                    }
                    else { 
                        user = null;
                        Console.WriteLine("Password is not corectly"); 
                    }
                }
                else
                {
                    Console.WriteLine($"Not found user with a login {login}(");
                }
                return user;
                

                




            }
        }
    }
}
