using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverDevicesQuestionnaire
{
    public static class CommonCharacters
    {
        public static void InputString()
        {
            String firstInput = "Clever";
            String secondInput = "Devices";
            Console.WriteLine("Common Character between {0} and {1} are:", firstInput, secondInput);
            Console.WriteLine(getCommonCharacter(firstInput.ToCharArray(), secondInput.ToCharArray()));
            Console.ReadLine();
        }

        /// <summary>
        /// To find the common characters from two objects
        /// </summary>
        /// <param name="a">Character A</param>
        /// <param name="b">Character B</param>
        /// <returns></returns>
        static char[] getCommonCharacter(char[] a, char[] b)
        {
            String character = string.Empty;
            Boolean[] flags = new Boolean[256]; // sizeOf(Char) is 256

            //First checking the char[] b coz the result string I am going to display in the order of char[] a
            for (int i = 0; i < b.Length; i++)
                // For appearing character in b, set true element of boolean array
                flags[b[i]] = true; 

            for (int j = 0; j < a.Length; j++)
                if (flags[a[j]] == true)
                {
                    character += a[j]; // order of A
                    flags[a[j]] = false;
                }
            return character.ToArray();
        }
    }
}
