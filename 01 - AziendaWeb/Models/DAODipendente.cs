using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace _01___AziendaWeb.Models
{
    public class DAODipendente
    {
        //List<Dipendente> elenco;

        private Database db;

        public static DAODipendente instance = null;

        private DAODipendente()
        {
            db = new Database("AziendaWeb");

        }

        public static DAODipendente GetInstance()
        {
            if (instance == null)
                instance = new DAODipendente();

            return instance;
        }


        //public DAODipendente()
        //{
        //    elenco = new List<Dipendente>();

        //    elenco.Add(new Dipendente
        //                    (1, "Pino", "Pane", new DateTime(1980, 3, 15),
        //                    "Acquisti", "Milano"
        //                    )
        //              );
        //    elenco.Add(new Dipendente
        //                    (2, "Lucia", "Tartaruga", new DateTime(1985, 11, 5),
        //                    "Acquisti", "Milano"
        //                    )
        //              );
        //    elenco.Add(new Dipendente
        //                    (3, "Erika", "Conigli", new DateTime(1990, 1, 21),
        //                    "Vendite", "Milano"
        //                    )
        //              );
        //}

        public List<Dipendente> ElencoDipendenti()
        {
            List<Dipendente> ris = new List<Dipendente>();

            string query = "select * from dipendenti";

            List<Dictionary<string, string>> righe = db.Read(query);

            foreach (Dictionary<string, string> riga in righe)
            {
                Dipendente d = new Dipendente();
               
                d.FromDictionary(riga);

                ris.Add(d);
            }

            return ris;
        }

        //public Dipendente CercaDipendente(int id)
        //{
        //    Dipendente d = null;

        //    foreach (Dipendente dip in elenco)
        //        if (dip.Id == id)
        //            d = dip;

        //    return d;
        //}

        public Dipendente CercaDipendente(int id)
        {
            Dipendente d = null;

            foreach (Dipendente dip in ElencoDipendenti())
                if (dip.Id == id)
                    d = dip;

            return d;
        }
        public bool Salva(Dipendente d)
        {
            string query = 
                $"insert into Dipendenti (nome,cognome,dob,reparto,residenza)" +
                $"values('{d.Nome}', '{d.Cognome}', '{d.Dob.Year}-{d.Dob.Month}-{d.Dob.Day}', '{d.Reparto}','{d.Residenza}');";


            return db.Update(query);
        }

        public bool Elimina(int id)
        {
            string query = $"delete from dipendenti where id = {id}";

            return db.Update(query);
        }

        public bool Modifica(Dipendente d)
        {
            string query = 
                $"update dipendenti set nome = '{d.Nome}'," +
                $"cognome = '{d.Cognome}', residenza = '{d.Residenza}', reparto = '{d.Reparto}'," +
                $"dob = '{d.Dob:yyyy-MM-dd}' where id = {d.Id}";

            return db.Update(query);
        }

    }
}
