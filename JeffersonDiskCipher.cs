using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_Criptografie1
{
    internal class JeffersonDiskCipher : Utilities, ICipher
    {
        public char[][] DisksOrdered { get; set; }
        public int Position { get; set;}
        public int[] Key { get; set; }
        public string Text;
       
        public JeffersonDiskCipher(int[] key, int position, string text)
        {
            int lettersNumber = 0;
            foreach(char item in text)
            {
               if(Regex.IsMatch(item.ToString(), @"[a-zA-Z]"))
                {
                    lettersNumber++;
                }
            }
            Console.WriteLine(lettersNumber);
            if(lettersNumber != key.Length)
            {
                throw new ArgumentException("The number of letters in the message must match the key length aka number of disks");
            }
            Key = key;
            Position = position;
            Text = text.ToLower();
           
            DisksOrdered = new char[key.Length][];
            char[][] Disks = new char[key.Length][];
            for(int i = 0; i < Disks.Length; i++)
            {
                char[] sh = ShuffleAlphabet();
                Disks[i] = new char[26];
                Array.Copy(sh, Disks[i], sh.Length);
            }

            int diskPlace = 0;
            for (int i = 0; i < Key.Length; i++) 
            {
                DisksOrdered[diskPlace] = Disks[Key[i]];
                diskPlace++;
            }

        }
        public string Decript(string encriptedText)
        {
            int currentDisk = 0;
            StringBuilder decriptedText = new StringBuilder();
            for (int i = 0; i < Text.Length; i++)
            {
                if (encriptedText[i] >= 'a' && encriptedText[i] <= 'z')
                {
                    DisksOrdered[currentDisk] = ShiftAlphabet(encriptedText[i], DisksOrdered[currentDisk]);

                    foreach (char letter in DisksOrdered[currentDisk])
                    {
                        Console.Write(letter + " ");
                    }
                    Console.WriteLine();

                    decriptedText.Append(DisksOrdered[currentDisk][26 - Position]);
                    currentDisk++;
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
            int currentDisk = 0;
            StringBuilder encriptedText = new StringBuilder();
            for (int i = 0; i < Text.Length; i++)
            {
                if (Text[i] >= 'a' && Text[i] <= 'z')
                {
                    DisksOrdered[currentDisk] = ShiftAlphabet(Text[i], DisksOrdered[currentDisk]);

                    foreach (char letter in DisksOrdered[currentDisk])
                    {
                        Console.Write(letter + " ");
                    }
                    Console.WriteLine();

                    encriptedText.Append(DisksOrdered[currentDisk][Position]);
                    currentDisk++;
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
