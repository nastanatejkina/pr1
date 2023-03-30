using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    class Program
    {
        public class User
        {
            public string Name { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }

            public User(string name, string login, string password)
            {
                Name = name;
                Login = login;
                Password = password;
            }

            public bool Enter(string login, string password)
            {
                return Login == login && Password == password;
            }
        }

        public class Admin : User
        {
            public string Place { get; set; }

            public Admin(string name, string login, string password, string place)
                : base(name, login, password)
            {
                Place = place;
            }

            public string GetPlace()
            {
                return Place;
            }

            public void SetPlace(string place)
            {
                Place = place;
            }
        }

        public class Client : User
        {
            public string Place { get; set; }

            public Client(string name, string login, string password, string place)
                : base(name, login, password)
            {
                Place = place;
            }

            public string GetPlace()
            {
                return Place;
            }

            public void SetPlace(string place)
            {
                Place = place;
            }
        }

        public  class Path
        {
            public string[] Points { get; set; }
            public int Time { get; set; }

            public Path(string[] points, int time)
            {
                Points = points;
                Time = time;
            }
        }

        public class Map
        {
            public List<Path> Paths { get; set; }

            public Map()
            {
                Paths = new List<Path>();
            }

            public void AddPath(string place1, string place2, int time)
            {
                Paths.Add(new Path(new string[] { place1, place2 }, time));
            }
        }

        public class PizzaSystem
        {
            public List<User> Users { get; set; }
            public Map Map { get; set; }
            public User CurrentUser { get; set; }
            public string CurrentLocation { get; set; }

            public PizzaSystem()
            {
                Users = new List<User>();
                Map = new Map();
                CurrentUser = null;
                CurrentLocation = null;
            }

            public void AddUser(string name, string login, string password, string reputation, int type)
            {
                if (type == 1)
                {
                    Users.Add(new Admin(name, login, password, ""));
                }
                else if (type == 2)
                {
                    Users.Add(new Client(name, login, password, ""));
                }
            }

            public User FindUser(string login, string password)
            {
                foreach (User user in Users)
                {
                    if (user.Enter(login, password))
                    {
                        return user;
                    }
                }
                return null;
            }

            public void Save()
            {
                
            }

            public void Load()
            {
                
            }

            
        }
        static void Main(string[] args)
        {
            PizzaSystem pizzaSystem = new PizzaSystem();

            // добавляем пользователя
            pizzaSystem.AddUser("Иванов", "ivanov123", "qwerty", "client", 1);

            // ищем пользователя
            User user = pizzaSystem.FindUser("ivanov123", "qwerty");

            if (user != null)
            {
                Console.WriteLine("Найден пользователь: " + user.Name);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Пользователь не найден.");
                Console.ReadLine();
            }

        }
    }
    
 
}

