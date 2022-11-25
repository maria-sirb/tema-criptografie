using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.DesignerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Criptografie1
{
    class Utilities
    {
        Random rnd = new Random();
        protected Dictionary<char, char> Shuffle()
        {
            Dictionary<char, char> Shuffled = new Dictionary<char, char>();
            char[] shuffledAlphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            
            ShuffleHelper(shuffledAlphabet);
            for (int i = 0; i < 26; i++)
            {
                Shuffled.Add(Convert.ToChar(97 + i), shuffledAlphabet[i]);
            }
            return Shuffled;
        }
        protected char[] ShuffleAlphabet()
        {
            char[] shuffledAlphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            ShuffleHelper(shuffledAlphabet);
            return shuffledAlphabet;

        }
        /// <summary>
        /// Shuffles the numbers from 0 to n-1
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        protected int[] ShuffleNumbers(int n)
        {
            int[] shuffledNumbers = new int[n];
            
            for (int i = 0; i < n; i++)
            {
                shuffledNumbers[i] = i;
            }
            ShuffleHelper(shuffledNumbers);
            return shuffledNumbers;

        }
        /// <summary>
        /// Rotates the alphabet so that 'letter' is on the first position
        /// </summary>
        /// <param name="letter"></param>
        /// <param name="alphabet"></param>
        /// <returns></returns>
        protected char[] ShiftAlphabet(char letter, char[] alphabet)
        {
            int index = Array.IndexOf(alphabet, letter);
            char[] shifted = new char[26];
            for(int i = 0; i < alphabet.Length; i++)
            {
                Array.Copy(alphabet, index, shifted, 0, 26 - index);
                Array.Copy(alphabet, 0, shifted, 26 - index, index);
            }
            return shifted;
        }
        private void ShuffleHelper<T>(T[] toShuffle)
        {
            
            for (int i = toShuffle.Length - 1; i > 0; i--)
            {
                int j = rnd.Next(0, i + 1);
                T temp = toShuffle[i];
                toShuffle[i] = toShuffle[j];
                toShuffle[j] = temp;
            }
          
        }
    }
}
