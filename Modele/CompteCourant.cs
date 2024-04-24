using Banque_CorrigeV2_Bis.Exeptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banque_CorrigeV2_Bis.Modele
{
    
        [Serializable]
        public class CompteCourant : Compte
        {

            private double decouv = 0;

            public CompteCourant(int n, Client c) : base(n, c)
            {


            }


            public bool setDecouv(double value)
            {
                bool res = false;


                if (this.Solde > -value)
                {
                    decouv = value;
                    res = true;

                }

                else
                {
                res = false;

                }
                return (res);

            }


            // On peut aussi utiliser celui là....
            // Set utilisé avec l'outil d'encapsulation
            /// <summary>
            /// méthode qui affecte un certain montant de découvert
            /// </summary>
            /// <param name="value">double représentant le découvert</param>
            public double Decouv
            {
                get => decouv;

                set
                {
                    if (this.Solde >= (-value)) { decouv = value; }

                    else
                    {
                        // Propager une exception

                    }


                }
            }

         
            public override void debiter(double mont)
            {
                if (solde - mont < -decouv)
                {
                throw new DebitExeption(Convert.ToString(mont) + "N'est pas possible");
            }
                else
                {
                    solde = solde - mont;
                   
                }
            }

           
            

            public override string Description
            {
                get => base.Description + " - decouvert : " + this.decouv;
            }




        }

    }

