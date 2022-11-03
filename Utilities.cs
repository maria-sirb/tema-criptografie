using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Criptografie1
{
    class Utilities
    {
        protected Dictionary<char, char> Shuffle()
        {
            Dictionary<char, char> Shuffled = new Dictionary<char, char>();
            char[] shuffledAlphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            Random rnd = new Random();

            for (int i = 25; i > 0; i--)
            {
                int j = rnd.Next(0, i + 1);

                char temp = shuffledAlphabet[i];
                shuffledAlphabet[i] = shuffledAlphabet[j];
                shuffledAlphabet[j] = temp;
            }
            for (int i = 0; i < 26; i++)
            {
                Shuffled.Add(Convert.ToChar(97 + i), shuffledAlphabet[i]);
            }
            return Shuffled;
        }
    }
}
