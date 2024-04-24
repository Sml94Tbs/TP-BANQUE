using Banque_CorrigeV2_Bis.Exeptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace Banque_CorrigeV2_Bis
{
    class Mgr
    {
       
        // on propage à la vue une exception générique
      static  public void crediter (Compte c,double montant)
        {
            
                c.crediter(montant);
            

        }

        // On propage à la vue l'exception "métier" DebitException 
        static public void debiter(Compte c, double montant)
        {

            try
            {
               
                
                
                c.debiter(montant);

            
            }
            
            catch(DebitExeption e)
            {
                throw (e);
            }


        }



    }

    
}
