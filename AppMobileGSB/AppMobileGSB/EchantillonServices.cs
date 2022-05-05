using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Essentials;
using AppMobileGSB.Droid.Model;
using System.Collections.ObjectModel;

namespace AppMobileGSB
{
    public static class EchantillonServices
    {
        static SQLiteConnection db;
        public static async Task Init()
        {

            //Si elle existe déjà, ne pas recréer la base de données
            if (db != null)
                
                return;

                var databasePath = Path.Combine(FileSystem.AppDataDirectory, "EchantillonDB.db");
                db = new SQLiteConnection(databasePath);

                db.CreateTable<Echantillon>();
                 db.CreateTable<Composant>();
                Console.WriteLine("Table créée");
        }

        public static List<Echantillon> QuerySelectListEchantillons()
        {
            List<Echantillon> lsech = new List<Echantillon>();
            lsech = db.Query<Echantillon>("select * from Echantillon");
            return lsech;

        }
        public static List<Composant> QuerySelectListComp(string comp, string id)
        {
            List<Composant> lsech = new List<Composant>();
            lsech = db.Query<Composant>("select * from Composant where nom = ? and idEchantillon = ? ", comp, id);
            return lsech;
        }

        public static List<Composant> QuerySelectListCompById(string id)
        {
            List<Composant> lsech = new List<Composant>();
            lsech = db.Query<Composant>("select * from Composant where idEchantillon = ? ", id);
            return lsech;
        }


        public static async Task addEchantillon(string unCode, string unLibelle, int uneQteStock)
        {
            await Init();
            var echantillon = new Echantillon
            {
                code = unCode,
                libelle = unLibelle,
                quantiteStock = uneQteStock,
            };

            var id = db.Insert(echantillon);
        }

        public static async Task addComposant(string nomComp, String idEchantillon)
        {
            await Init();

            await insertComp(nomComp, idEchantillon);

        }
        public static async Task majEchantillon(string unCode, int uneQte)
        {

            int addition;
            await Init();
            List<Echantillon> qte = db.Query<Echantillon>("select * from Echantillon where code = ?", unCode);

                 addition = uneQte + qte[0].quantiteStock;
                db.Query<Echantillon>("update Echantillon SET quantiteStock = ? where code = ?", addition, unCode);
        }

        public static async Task<Boolean> insertComp(string comp, string id)
        {
            Boolean result = false ;
            await Init();
            string query = "insert INTO Composant (nom, idEchantillon) values " + comp + "," + id + ";";
            try
            {
                db.Execute(query);
                result = true;
            }
            catch(SQLiteException ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }


        public static async Task DelEchantillon(string unCode, int uneQte)
        {
            int suppres;
            List<Echantillon> qte = db.Query<Echantillon>("select * from Echantillon where code = ?", unCode);
            suppres = qte[0].quantiteStock - uneQte;
            db.Query<Echantillon>("update Echantillon SET quantiteStock = ? where code = ?", suppres, unCode);
        }

        public static async Task DelComp(string comp, string id)
        {
            
           db.Query<Echantillon>("DELETE from Composant where nom = ? and idEchantillon = ?", comp, id);
        }

        public static Boolean VerifQte(string unCode, int uneQte)
        {
            int suppres;
            bool result = false;
            List<Echantillon> qte = db.Query<Echantillon>("select * from Echantillon where code = ?", unCode);
            suppres = qte[0].quantiteStock - uneQte;
            if (suppres > 0)
            {
                result = true;
            }
            return result;
        }
        public static IEnumerable<Echantillon> QuerySelectEchantillon(Echantillon echantillon)
        {
            return (IEnumerable<Echantillon>)db.Query<Echantillon> ("select * from Echantillon where code = ?", echantillon.code);
        }
       
    }
}
