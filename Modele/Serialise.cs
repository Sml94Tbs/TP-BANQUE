using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Banque_CorrigeV2_Bis
{
   public class Serialise
    {
      

        public static List<Compte> chargement()
        {
            List<Compte> lstcpt = new List<Compte>();
            try
            {
                if (File.Exists("data"))
                {
                   
                    BinaryFormatter deserializer = new BinaryFormatter();
                    FileStream stream = new FileStream("data", FileMode.Open);
                    lstcpt = (List<Compte>)deserializer.Deserialize(stream);
                    stream.Close();
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return (lstcpt);

        }

        public static void sauvegarde(List<Compte> lstcpt)
        {

            try
            {
                FileStream stream = new FileStream("data", FileMode.Create);
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(stream, lstcpt);
                stream.Close();
            }

            catch (Exception ex)
            {


                throw (ex);

            }


        }

    }
}
