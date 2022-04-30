using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektasSlaptazodziai
{
    internal class PasswordGenerator
    {

        public static string GeneratePassword(int capitalTimes, int smallTimes, int digitsTimes, int specialCharTimes)
        {
            // Galimi simboliai

            //-------------------------------------------

            // 26 reiksmes
            string[] capitalLetters = { "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "A", "S", "D", "F", "G", "H", "J", "K", "L", "Z", "X", "C", "V", "B", "N", "M" };
            // 26
            string[] smallLetters = { "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "a", "s", "d", "f", "g", "h", "j", "k", "l", "z", "x", "c", "v", "b", "n", "m" };
            // 10
            string[] digits = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            // 24
            string[] specialChar = { "`", "~", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "=", "+", "|", "[", "]", "{", "}", "'", "/", "?" };

            //-------------------------------------------

            string generatedPassword = "";
            int length = 0;
            length += capitalTimes + smallTimes + digitsTimes + specialCharTimes;

            Random rnd = new Random();

            for(int i = 0; i < length; i++)
            {
                int rndFunction = rnd.Next(1, 5); // nuo 1 iki 4

                if(rndFunction == 1 && capitalTimes > 0) // Didieji
                {
                    generatedPassword += capitalLetters[rnd.Next(0, 26)];
                    capitalTimes--;
                }
                else if(rndFunction == 1 && capitalTimes == 0)
                {
                    i--;
                }

                if (rndFunction == 2 && smallTimes > 0) // Mazieji
                {
                    generatedPassword += smallLetters[rnd.Next(0, 26)];
                    smallTimes--;
                }
                else if (rndFunction == 2 && smallTimes == 0)
                {
                    i--;
                }

                if (rndFunction == 3 && digitsTimes > 0) // Skaiciai
                {
                    generatedPassword += digits[rnd.Next(0, 10)];
                    digitsTimes--;
                }
                else if (rndFunction == 3 && digitsTimes == 0)
                {
                    i--;
                }

                if (rndFunction == 4 && specialCharTimes > 0) // Simboliai
                {
                    generatedPassword += specialChar[rnd.Next(0, 24)];
                    specialCharTimes--;
                }
                else if (rndFunction == 4 && specialCharTimes == 0)
                {
                    i--;
                }
            }

            return generatedPassword;
        } 
    }
}
