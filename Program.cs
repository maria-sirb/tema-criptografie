using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Criptografie1
{
    class Program
    {
        static void Main(string[] args)
        {
            using(StreamReader sr = new StreamReader("../../TextSample.txt"))
            {

                StringBuilder sb = new StringBuilder();
                while(!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line != "")
                    {
                        sb.Append($"{line} ");
                    }

                }
                string str = sb.ToString();
            
          /*  CaesarsCipher cc = new CaesarsCipher(3, "Hello Worldz!");
            Console.WriteLine(cc.Encript());
            Console.WriteLine(cc.Decript("Khoor Zruogc!"));*/

           // CaesarsCipher cc2 = new CaesarsCipher(3, str);
           // string encriptedcc2 = cc2.Encript();
           // Console.WriteLine(encriptedcc2);
           // Console.WriteLine("*******************************************************");
          //  Console.WriteLine(MonoalphabeticSubstitution.Cryptanalyse(encriptedcc2));
           
            }

            /*MonoalphabeticCipher mc = new MonoalphabeticCipher("Hello World!");
            string encriptedMc = mc.Encript();
            Console.WriteLine(encriptedMc);
            Console.WriteLine(mc.Decript(encriptedMc));*/

            /*PolyalphabeticCipher pc = new PolyalphabeticCipher("Hello World, Hello World!", 4);
            string encriptedPc = pc.Encript();
            Console.WriteLine("encripted: " + encriptedPc);
            Console.WriteLine("decripted:  " + pc.Decript(encriptedPc));
            */

            PlayfairCipher pc = new PlayfairCipher("apple", "hello world");
            string encriptedpc = pc.Encript();
            Console.WriteLine(encriptedpc);
            Console.WriteLine(pc.Decript(encriptedpc));
            Console.ReadKey();

        }
    }
}
