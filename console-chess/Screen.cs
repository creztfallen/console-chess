using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Table;

namespace console_chess
{
    class Screen
    {
        public static void PrintTable(GameTable tab)
        {
            for (int i = 0; i < tab.Rows; i++) {
                for (int j = 0; j < tab.Columns; j++)
                {
                    if (tab.PiecePosition(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write($"{tab.PiecePosition(i, j)} ");
                    }
                }
                Console.WriteLine();
            }
        } 
    }
}
