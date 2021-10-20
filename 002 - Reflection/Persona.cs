using System;
using System.Collections.Generic;
using System.Text;

namespace _002___Reflection
{
    public class Persona
    {
        public string Nome { get; set; }
        public int Eta { get; set; }
        public Dictionary<string, string> Dict {get;set;}

        /*public void TestReflection()
        {
            var type = GetType();
            Console.WriteLine("il tipo di questo oggetto:");
            Console.WriteLine(type.Name);

            var infos = type.GetProperties();
            Console.WriteLine("le proprieta di questo oggetto");

            foreach (var info in infos)
            {
                Console.WriteLine(info.Name);
            }

        }
 */

        public string Scheda()
        {
            //THROW
            //randomicamente viene effettuato un throw
            //prpaga un'eccezione
            if(new Random().Next(2) == 1)
            {
                var e = new Exception("AAAAAAAAAAA");
                throw e;
            }
            return "Name" + Nome;

        }


    }
    //classe eccezione
    //definire delle eccezioni custom, in modo da rappresentare meglio
    //il tipo di eccezione che voglio propagare
    public class NomeisNullException : Exception
    {





    }
}
