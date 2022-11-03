using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Criptografie1
{
    //a b c d e f g h i j  k  l  m  n  o  p  q  r  s  t  u  v  w  x  y  z
    //1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26
    class CaesarsCipher : MonoalphabeticSubstitution, ICipher
    {
        private int _key;
        private string _text;
        private Dictionary<char, int> _letters;
        public int Key
        {
            get => _key;
            set => _key = value % 26;
        }
        public string Text { get; set;}
        public CaesarsCipher(int key, string text)
        {
            Key = key;
            Text = text;
            _letters = new Dictionary<char, int>();
            for(int i = 0; i < 26; i++)
            {
                _letters.Add(Convert.ToChar(97 + i), i);
            }
           /* foreach(KeyValuePair<char, int>  kvp in _letters)
            {
                Console.WriteLine(kvp.Key + " " +  kvp.Value);
            }*/
        }
        public string Decript(string encriptedText)
        {
            StringBuilder decriptedText = new StringBuilder();

            for (int i = 0; i < Text.Length; i++)
            {
                //get the corresponding index of the characther from the _letters dictionary
                _letters.TryGetValue(Char.ToLower(encriptedText[i]), out int charIndex);

                if (Text[i] >= 'a' && Text[i] <= 'z')
                {
                    decriptedText.Append(Convert.ToChar(97 + (26 + charIndex - Key) % 26));
                }
                else if (Text[i] >= 'A' && Text[i] <= 'Z')
                {
                    decriptedText.Append(Convert.ToChar(65 + (26 + charIndex - Key) % 26));
                }
                else
                {
                    decriptedText.Append(Text[i]);
                }
            }
            return decriptedText.ToString();

        }

        public string Encript()
        {
            StringBuilder encriptedText = new StringBuilder();

            for(int i = 0; i < Text.Length; i++)
            {
                //get the corresponding index of the characther from the _letters dictionary
                _letters.TryGetValue(Char.ToLower(Text[i]), out int charIndex);

                if (Text[i] >= 'a' && Text[i] <= 'z')
                {
                   encriptedText.Append(Convert.ToChar(97 + (charIndex + Key) % 26));
                }
                else if (Text[i] >= 'A' && Text[i] <= 'Z')
                {
                    encriptedText.Append(Convert.ToChar(65 + (charIndex + Key) % 26));
                }
                else
                {
                     encriptedText.Append(Text[i]);
                }
            }
            return encriptedText.ToString();

        }
    }
}
