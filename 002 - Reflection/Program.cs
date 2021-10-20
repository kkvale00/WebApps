using System;
using System.Collections.Generic;

namespace _002___Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona p = new Persona { Nome = "mario", Eta = 33, Dict = new Dictionary<string, string>() };
            Type t = p.GetType();

            var properties = t.GetProperties();

            foreach (var pr  in properties)
            {
                Console.WriteLine(pr.GetValue(p).GetType());
            }
            Console.ReadKey();

            try
            {

               Console.WriteLine(p.Scheda());
            }
            catch(NomeisNullException)
            {
                Console.WriteLine("il nome e null");
            }
            catch(Exception)
            {
                Console.WriteLine("nooooooo di nuvoo...");
            }
        }
    }
}
