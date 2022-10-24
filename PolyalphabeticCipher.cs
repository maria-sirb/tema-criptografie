using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Criptografie1
{
    class PolyalphabeticCipher : Cryptography
    {
        public string Text { get; set; }
        public List<Dictionary<char, char>> Alphabets { get; set; }
        public int Block { get; set; }
        public PolyalphabeticCipher(string text, int block)
        {
            Text = text;
            Block = block;
            Alphabets = new List<Dictionary<char, char>>();
        }

        public override string Decript(string encriptedText)
        {
            int k = 0, blockNr = 0;
            StringBuilder decriptedText = new StringBuilder();
            while(true)
            {
                if(k >= encriptedText.Length)
                {
             
                    break;
                }
                if(k % Block == 0)
                {
                    string subText = encriptedText.Substring(k, Math.Min(Block, encriptedText.Length - k));
                    Dictionary<char, char> Alphabet = Alphabets[blockNr];
                    MonoalphabeticCipher mc = new MonoalphabeticCipher(subText, Alphabet);
                    
                    string decriptedBlock = mc.Decript(subText);
                    decriptedText.Append(decriptedBlock);
                    k += Block;
                    blockNr++;
                }
            }
            return decriptedText.ToString();
        }

        public override string Encript()
        {
            int k = 0;
            StringBuilder encriptedText = new StringBuilder();
            while(true)
            {
                if(k >= Text.Length)
                {
                    break;
                }
                if (k % Block == 0)
                {
                    string subText = Text.Substring(k, Math.Min(Block, Text.Length - k));
                    Dictionary<char, char> Alphabet = Shuffle();
                    Alphabets.Add(Alphabet);


                    MonoalphabeticCipher mc = new MonoalphabeticCipher(subText, Alphabet);
                    string encriptedBlock = mc.Encript();
                    encriptedText.Append(encriptedBlock);

                  //  Console.WriteLine(encriptedBlock);
                    
                    foreach (KeyValuePair<char, char> kvp in Alphabet)
                    {
                        Console.WriteLine(kvp.Key + " " + kvp.Value);
                    }
                    k += Block;   
                }
                
            }
            return encriptedText.ToString();
        }
    }
}
