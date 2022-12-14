using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Criptografie1
{
    abstract class MonoalphabeticSubstitution : Utilities
    {
        public static string Cryptanalyse(string encriptedText)
        {
            encriptedText = encriptedText.ToLower();
            //contains letters sorted by their frequency in the english language
            char[] lettersFrquency = { 'e', 't', 'o', 'a', 'n', 'i', 'h', 's', 'r', 'd', 'l', 'c', 'u', 'm', 'w', 'f', 'g', 'y', 'p', 'b', 'v', 'k', 'j', 'x', 'q', 'z' };

            Dictionary<char, int> textLetters = new Dictionary<char, int>();

            for (int i = 0; i < 26; i++)
            {
                textLetters.Add(Convert.ToChar(97 + i), 0);
            }

            for (int i = 0; i < encriptedText.Length; i++)
            {
                if (encriptedText[i] > 'a' && encriptedText[i] < 'z')
                    textLetters[encriptedText[i]]++;
            }
            //the dictionary now contains all the letters in the encripted text as key and their apparition count as value
            //convert the dictionary to list to sort it 
            List<KeyValuePair<char, int>> textLettersList = textLetters.ToList();

            //sort letters by their apparition count
            textLettersList.Sort((x, y) => y.Value.CompareTo(x.Value));

            StringBuilder decriptedText = new StringBuilder();

            //go over encripted text
            for (int i = 0; i < encriptedText.Length; i++)
            {
                if (encriptedText[i] >= 'a' && encriptedText[i] <= 'z')
                {
                    //search each letter`s position in the sorted list
                    //in the decripted text, replace it with the letter on the same position from the letterFrequencies array 
                    int indexOfChar = textLettersList.FindIndex(x => x.Key == encriptedText[i]);
                    decriptedText.Append(lettersFrquency[indexOfChar]);

                }
                else
                {
                    decriptedText.Append(encriptedText[i]);
                }

            }

            return decriptedText.ToString();
        }
    
    }
}
