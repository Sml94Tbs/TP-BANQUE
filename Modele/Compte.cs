using System;

namespace Banque_CorrigeV2_Bis
{

    /// <summary>
    /// Classe qui gère les comptes
    /// </summary>

    [Serializable]
    public abstract class Compte
    {

        protected readonly int num;
        protected readonly Client proprio;
        protected double solde;





        public Compte(int n, Client c)
        {
            num = n;
            solde = 0;
            proprio = c;
        }

        

        // ou ça
        public int Numero
        {
            get
            { return num; }
        }



        public virtual string Description
        {
            get
            {

                return num + " " + proprio + " " + solde + "€" ;

               
            }

        }



        public Client Propriétaire
        {
            get { return proprio; }
        }

        protected double Solde { get => solde; }

        

        public void crediter(double mont)
        {
            solde = solde + mont;
        }

        public abstract void debiter(double mont);

    }

}
