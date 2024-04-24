using Banque_CorrigeV2_Bis.Exeptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banque_CorrigeV2_Bis.Modele
{

    [Serializable]
    internal class CompteEpargne : Compte
    {
        private double taux;

        public CompteEpargne(int n, Client c, double unTaux) : base(n, c)
        {
            taux = unTaux;

        }

       

        // On crée et on propage au controleur l'exception "métier" DebitException 
        public override void debiter(double mont)
        {
                if (solde - mont < 0)
                {
                    throw new DebitExeption(Convert.ToString(solde) + "N'est pas possible");
                }
                else
                {
                    solde = solde - mont;


                }
        }



        public override string Description
        {
            get => base.Description + " taux : " + taux;
        }

    }
}
