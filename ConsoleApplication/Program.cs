using NinjaDomain.Classes;
using NinjaDomin.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //InsertNinja();
            //InsertMultipleNinjas();
            //SimpleNinjaQuery();
            QueryAndUpdateNinja(); 
            Console.ReadLine();
        }

        static void log(DbContext context)
        {
            context.Database.Log = Console.WriteLine;
        }
        private static void InsertNinja()
        {
            var ninja = new Ninja
            {
                Name = "Hayk",
                ServerInOniwaban = false,
                DateOfBirth = new DateTime(1980, 1, 1),
                ClanId = 1

            };
            using (var context=new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Ninjas.Add(ninja);
                context.SaveChanges();
            }
        }

        private static void InsertMultipleNinjas()
        {
            var ninja1 = new Ninja { Name = "Lenoanrdo", ServerInOniwaban = false, DateOfBirth = new DateTime(1984, 1, 1), ClanId = 1 };
            var ninja2 = new Ninja { Name = "Rapheal", ServerInOniwaban = false, DateOfBirth = new DateTime(1985, 1, 1), ClanId = 1 };
            using (var context = new NinjaContext())
            {
                var ninlist = new List<Ninja> { ninja1, ninja2 }; 
                context.Database.Log = Console.WriteLine;
                context.Ninjas.AddRange(ninlist);
                context.SaveChanges(); 
            }
        }

        private static void SimpleNinjaQuery()

        {
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine; 
                var ninjas = context.Ninjas.Where(n => n.Name == "Hayk");

                foreach (var ninja in ninjas)
                {

                    Console.WriteLine(ninja.Name);


                }
            }

        }
        
        private static void QueryAndUpdateNinja()
        {
            using (var context = new NinjaContext())
            {
                log(context);
                var ninja = context.Ninjas.FirstOrDefault();
                ninja.ServerInOniwaban = (!ninja.ServerInOniwaban);

                context.SaveChanges(); 
            }
        }
    }
}
