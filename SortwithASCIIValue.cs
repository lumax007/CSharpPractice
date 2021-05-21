using System;

namespace CSharpPractice
{
    public class SortwithASCIIValue
    {
        public static void Process()
        {
            string[] names = { "Nikhil", "Aakash", "Srinivaas", "Bhushan", "Prashant Shrivastava"};
            for (int i = 0; i < names.Length; i++)
            {
                char[] arrChar = names[i].ToCharArray();
                bool isSort;
                int counter = arrChar.Length;
                do
                {
                    for (int j = 0; j < arrChar.Length - 1; j++)
                    {
                        if (arrChar[j] > arrChar[j + 1])
                        {
                            var temp = arrChar[j];
                            arrChar[j] = arrChar[j + 1];
                            arrChar[j + 1] = temp;
                        }
                    }
                    isSort = true;
                    counter--;
                } while (isSort && counter > 0);
                Console.WriteLine(arrChar);
            }
        }
    }
}
