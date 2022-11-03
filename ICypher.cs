using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Criptografie1
{
    interface ICypher
    {
        string Encript();
        string Decript(string encriptedText);
    }
}
