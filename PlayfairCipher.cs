using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Criptografie1
{
    class PlayfairCipher : ICipher
    {
        public char[] Key { get; set; }
        public string Text { get; set; }
        public char[,] Table;
        public PlayfairCipher(string key, string text)
        {
            Key = key.ToCharArray();
            Text = FormText(text.ToLower());
            Table = new char[5,5];
            FormTable();
            Console.WriteLine(Text);
        }

        public string Encript()
        {
            StringBuilder encriptedText = new StringBuilder();
            for(int i = 0; i < Text.Length; i += 2)
            {
                char l1 = Text[i];
                char l2 = Text[i + 1];
                int lineL1, colL1, lineL2, colL2;
                (lineL1, colL1) = FindCoordinates(l1);
                (lineL2, colL2) = FindCoordinates(l2);

                //If both the letters are in the same row: Take the letter to the right of each one
                if (lineL1 == lineL2)
                {
                    encriptedText.Append(Table[lineL1, (colL1 + 1) % 5]);
                    encriptedText.Append(Table[lineL2, (colL2 + 1) % 5]);

                }
                //If both the letters are in the same column: Take the letter below each one
                else if (colL1 == colL2)
                {
                    encriptedText.Append(Table[(lineL1 + 1) % 5, colL1]);
                    encriptedText.Append(Table[(lineL2 + 1) % 5, colL2]);
                }
                //If neither of the above rules is true: Form a rectangle with the two letters and
                //take the letters on the horizontal opposite corner of the rectangle.
                else
                {
                    encriptedText.Append(Table[lineL1, colL2]);
                    encriptedText.Append(Table[lineL2, colL1]);
                }

            }
            return encriptedText.ToString();

        }

        public string Decript(string encriptedText)
        {
            StringBuilder decriptedText = new StringBuilder();
            for (int i = 0; i < encriptedText.Length; i += 2)
            {
                char l1 = encriptedText[i];
                char l2 = encriptedText[i + 1];
                int lineL1, colL1, lineL2, colL2;
                (lineL1, colL1) = FindCoordinates(l1);
                (lineL2, colL2) = FindCoordinates(l2);

                //If both the letters are in the same row: Take the letter to the left of each one
                if (lineL1 == lineL2)
                {
                    decriptedText.Append(Table[lineL1, (colL1 + 4) % 5]);
                    decriptedText.Append(Table[lineL2, (colL2 + 4) % 5]);

                }
                //If both the letters are in the same column: Take the letter above each one
                else if (colL1 == colL2)
                {
                    decriptedText.Append(Table[(lineL1 + 4) % 5, colL1]);
                    decriptedText.Append(Table[(lineL2 + 4) % 5, colL2]);
                }
                //If neither of the above rules is true: Form a rectangle with the two letters and
                //take the letters on the horizontal opposite corner of the rectangle.
                else
                {
                    decriptedText.Append(Table[lineL1, colL2]);
                    decriptedText.Append(Table[lineL2, colL1]);
                }

            }
            return decriptedText.ToString();

        }

        /// <summary>
        /// Searches for the letter in the table and returns it's coordinates
        /// </summary>
        /// <param name="letter"></param>
        /// <returns>The coordinates of the letter in the table</returns>
        private (int,int) FindCoordinates (char letter)
        {
      
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    if (Table[i, j] == letter)
                        return (i, j);
            return (0, 0);
        }
        /// <summary>
        /// Modifies the plaintext so it can be ready for encription
        /// </summary>
        /// <param name="text"></param>
        /// <returns>The modified string</returns>
        private string FormText(string text)
        {
            //remove all the whitespaces from text
            text = string.Join("", text.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
            StringBuilder modifiedText = new StringBuilder(text);
            int i = 0;
            while(i + 1 < modifiedText.Length)
            {
                if(modifiedText[i] == modifiedText[i + 1])
                {
                    modifiedText.Insert(i + 1, 'x');
                }
                i += 2;
            }
            if(modifiedText.Length % 2 == 1)
            {
                modifiedText.Append('z');
            }
            modifiedText.Replace('j', 'i');
            return modifiedText.ToString();
            
        }
        /// <summary>
        /// Forms the encryption table using the key
        /// </summary>
        private void FormTable()
        {
            //let letter 'j' out of the alphabet because the table has only 5 chars
            List<char> alphabet = new List<char> (){ 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            int l = 0, c = 0;
            foreach(char letter in Key)
            {
                if(alphabet.Contains(letter))
                {
                    alphabet.Remove(letter);
                    Table[l, c] = letter;
                    l += (c + 1) / 5;
                    c = (c + 1) % 5;
                    
                }
            }
            foreach(char letter in alphabet)
            {
                Table[l, c] = letter;
                l += (c + 1) / 5;
                c = (c + 1) % 5;
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(Table[i, j] + " ");

                }
                Console.WriteLine();
            }
        }
    }

}
