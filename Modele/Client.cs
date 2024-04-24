using System;

namespace Banque_CorrigeV2_Bis
{
    [Serializable]
    public class Client
    {
        private int num;
        private string nom;
        private string prenom;
        private string adresse;


        public Client(int num, string nom, string prenom, string ad)
        {
            this.num = num;
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = ad;
        }

        public string Nom { get => nom; }
        public string Prenom { get => prenom; }
        public string Adresse { get => adresse; set => adresse = value; }
        public int Num { get => num; }

        public override string ToString()

        {

            return (this.Num + "   " + this.Nom + " " + this.prenom + " " + this.Adresse);
        }



    }

}




