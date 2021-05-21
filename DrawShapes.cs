using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice
{
    public class DrawShapes
    {
        public static void DrawRectagle()
        {
            for(int i = 0; i < 4; i++)
            {
                for(int j=0; j<4; j++)
                {
                    Console.Write(" - ");
                }
                Console.WriteLine();
            }
        }
    }
}
