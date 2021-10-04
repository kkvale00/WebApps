using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace _01___AziendaWeb.Models
{
    public class DAOCliente
    {

        private Database db;

        private static DAOCliente instance = null;

        private DAOCliente()
        {
            db = new Database("AziendaWeb");

        }

        public static DAOCliente GetInstance()
        {
            if (instance == null)
                instance = new DAOCliente();

            return instance;
        }

        public List<Cliente> ElencoClienti()
        {
            List<Cliente> ris = new List<Cliente>();

            string query = "select * from clienti";

            List<Dictionary<string, string>> righe = db.Read(query);

            foreach (Dictionary<string, string> riga in righe)
            {
                Cliente c = new Cliente();

                c.FromDictionary(riga);

                ris.Add(c);
            }

            return ris;
        }

        public Cliente CercaCliente(int id)
        {
            Cliente c = null;

            foreach (Cliente cli in ElencoClienti())
                if (cli.Id == id)
                    c = cli;

            return c;
        }

        public bool Salva(Cliente c)
        {
            string query = $"insert into clienti (nominativo,piva,annofondazione,settore,servizioacquistato,capitale)" +
                           $"values('{c.Nominativo}', '{c.Piva}', '{c.Annofondazione}', '{c.Settore}','{c.Servizioacquistato}',{c.Capitale});";


            return db.Update(query);
        }


        public bool Elimina(int id)
        {
            string query = $"delete from clienti where id = {id}";

            return db.Update(query);
        }
    }
}
