using System;
using System.Collections.Generic;
using System.Linq;

namespace _001___CSharpIntermedio
{
    class Program
    {
        static void Main(string[] args)
        {
            //var a = new Foo { Bar = 1 };
            //var b = new Foo { Bar = 1 };
            //var c = a;
            //Console.WriteLine(a == b);
            //Console.WriteLine(c == a);
            //a.Bar = 42;
            //c.Bar = 99;
            //Console.WriteLine(a.Bar);
            var a = Foo.GetInstance();
            var b = Foo.GetInstance();
            Console.WriteLine(a == b);
            a.Bar = 666;
            Console.WriteLine(b.Bar);
            IEnumerable<string> nomi = new List<string> { "Mario", "Pippo" };
            IEnumerable<int> numeri = Enumerable.Range(1, 10);
            IEnumerable<string> nomeRipetuto = Enumerable.Repeat("Pippo", 10);
            Dictionary<string, string> associazioneNomeCognome = new Dictionary<string, string>
            {
                {"Mario", "Rossi"},
                { "Luigi", "Luigi" }
            };

            associazioneNomeCognome["Mario"] = "Pippo";
            foreach (var pair in associazioneNomeCognome)
            {
                Console.WriteLine($"Alla chiave: {pair.Key} è associata il valore: {pair.Value}");
            }

            var nomiCasuali = new List<string> { "Mario", "Luigi", "Susanna", "Andrea", "Pippo", "Goku", "Red", "Ruffy" };

            var listaConNomiCasuali = new List<string>();

            for (var i = 0; i < 1000; i++)
            {
                listaConNomiCasuali.Add(nomiCasuali[new Random().Next(nomiCasuali.Count())]);
            }

            foreach (var n in listaConNomiCasuali)
            {
                Console.WriteLine(n);
            }
            // Voglio fare un censimento dei nomi nella lista, senza tuttavia conoscere effettivamente
            // quali sono quelli utilizzati
            // Potrei utilizzare un doppio for, ma è un algoritmo che richiede un tempo di esecuzione
            // esponenziale

            // Posso sfruttare invece un dictionary andando a ridurre drasticamente il numero di iterazioni
            // per ottenere questo risultato con soltanto un ciclo for
            var censimentoNomi = new Dictionary<string, int>();

            var nomiSpecifici = new List<string> { "Mario", "Alessia", "Mario", "Mario", "Pippo", "Alessia" };
            foreach (var n in nomiSpecifici)
            {
                if (censimentoNomi.ContainsKey(n))
                {
                    censimentoNomi[n]++;
                }
                else
                {
                    censimentoNomi[n] = 1;
                }
            }

            foreach (var pair in censimentoNomi)
            {
                Console.WriteLine($"{pair.Key} : [{pair.Value}]");
            }
            // type inferency
            var ll = Foo.GetInstance();
            double h = 33;
            h = 33.33;
            // Qui è estremamente efficacie perché non devo ripetere il tipo
            var dictionaryInutile = new Dictionary<Dictionary<string, int>, List<bool>>();
            ; ;
        }

        class Foo
        {
            private static Foo _instance;
            public static Foo GetInstance()
            {
                if (_instance == null)
                    _instance = new Foo();

                return _instance;
            }
            public int Bar { get; set; }
            // public var MyProperty { get; set; } = 33;
            public int MyProperty { get; set; } = 33;

            private Foo() { }
        }



    }
}
