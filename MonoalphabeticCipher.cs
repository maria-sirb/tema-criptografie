using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Criptografie1
{
    class MonoalphabeticCipher : Cryptography
    {
        public string Text { get; set; }
        public Dictionary<char, char> Alphabet { get; set; }

        public MonoalphabeticCipher(string text)
        {
            Text = text;
            Alphabet = Shuffle();

        }
        public MonoalphabeticCipher(string text, Dictionary<char, char> alphabet)
        {
            Text = text;
            Alphabet = alphabet;
        }
        public override string Decript(string encriptedText)
        {
            StringBuilder decriptedText = new StringBuilder(); 
            for(int i= 0; i < encriptedText.Length; i++)
            {
                if (Text[i] >= 'a' && Text[i] <= 'z')
                {
                    decriptedText.Append(Alphabet.FirstOrDefault(x => x.Value == encriptedText[i]).Key);
                }
                else if (Text[i] >= 'A' && Text[i] <= 'Z')
                {
                    decriptedText.Append(Char.ToUpper(Alphabet.FirstOrDefault(x => x.Value == Char.ToLower(encriptedText[i])).Key));
                }
                else
                {
                    decriptedText.Append(encriptedText[i]);
                }
            }
            return decriptedText.ToString();
        }

        public override string Encript()
        {
            StringBuilder decriptedText = new StringBuilder();
            for(int i = 0; i < Text.Length; i++)
            {
                if (Text[i] >= 'a' && Text[i] <= 'z')
                {
                    decriptedText.Append(Alphabet[Text[i]]);
                }
                else if (Text[i] >= 'A' && Text[i] <= 'Z')
                {
                    decriptedText.Append(Char.ToUpper(Alphabet[Char.ToLower(Text[i])]));
                }
                else
                {
                    decriptedText.Append(Text[i]);
                }
            }
            return decriptedText.ToString();
        }
        
    }
}
