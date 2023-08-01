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
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Columns; j++)
                {
                    if (tab.PiecePosition(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        AddPiece(tab.PiecePosition(i, j));
                        Console.Write(" ");
                    }
                  
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        } 

        public static void AddPiece(Piece piece)
        {
            if (piece.Color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}
