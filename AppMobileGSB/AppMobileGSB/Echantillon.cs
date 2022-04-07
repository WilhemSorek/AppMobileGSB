using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace AppMobileGSB.Droid.Model
{
    public class Echantillon
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string code { get; set; }
        public string libelle { get; set; }
        public int quantiteStock { get; set; }
        
        /*public Echantillon(string code, string libelle, string quantiteStock)
        {
            this.code = code;
            this.libelle = libelle;
            this.quantiteStock = quantiteStock;
        }

        public string getCode()
        {
            return code;
        }

        public void setCode(string uncode)
        {
            this.code = uncode;
        }

        public string getLibelle()
        {
            return libelle;
        }

        public void setLibelle(string unLibelle)
        {
            this.libelle = unLibelle;
        }

        public string getQuantiteStock()
        {
            return quantiteStock;
        }

        public void setQuantiteStock(string uneQuantite)
        {
            this.quantiteStock = uneQuantite;
        }*/
    }
}
