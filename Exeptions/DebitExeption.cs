using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banque_CorrigeV2_Bis.Exeptions
{
    public class DebitExeption : Exception
    {
        public DebitExeption(string message) : base(message + " n'est pas valide") {}
    }
}
