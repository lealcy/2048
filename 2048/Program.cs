using System;
using System.Collections.Generic;

namespace Application
{
    class MainClass
    {
        private static Dictionary<int, ConsoleColor> colors;

        public static void Main (string[] args)
        {
            Console.CursorVisible = false;
            colors = new Dictionary<int, ConsoleColor>();
            colors [0] = ConsoleColor.White;
            colors [2] = ConsoleColor.Gray;
            colors [4] = ConsoleColor.Yellow;
            colors [8] = ConsoleColor.DarkYellow;
            colors [16] = ConsoleColor.Red;
            colors [32] = ConsoleColor.DarkRed;
            colors [64] = ConsoleColor.Magenta;
            colors [128] = ConsoleColor.DarkMagenta;
            colors [256] = ConsoleColor.Cyan;
            colors [512] = ConsoleColor.DarkCyan;
            colors [1024] = ConsoleColor.Blue;
            colors [2048] = ConsoleColor.Green;

            Game2048 g = new Game2048 (4, 4);
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            drawBoard (g, x, y);
            while (true) {
                switch (Console.ReadKey (true).Key) {
                case ConsoleKey.Escape:
                case ConsoleKey.Enter:
                    return;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    g.MoveUp ();
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    g.MoveRight ();
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    g.MoveDown ();
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    g.MoveLeft ();
                    break;
                }
                if (g.IsBoardFull ()) {
                    drawBoard (g, x, y);
                    Console.WriteLine ("\nGAME OVER!");
                    return;
                }
                if (g.BoardChanged) {
                    g.AddValue ();
                    g.BoardChanged = false;
                }
                drawBoard (g, x, y);
                
            }


        }

        private static void drawBoard(Game2048 g, int x, int y) {
            for (int i = 0; i < g.Board.Length; i++) {
                for (int j = 0; j < g.Board[i].Length; j++) {
                    if (colors.ContainsKey (g.Board [i] [j])) {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = colors [g.Board [i] [j]];
                    } else {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.SetCursorPosition (x + i * 6, y + j * 3);
                    Console.Write ("      ");
                    Console.SetCursorPosition (x + i * 6, (y + j * 3) + 1);
                    Console.Write ("{0, 5} ", g.Board[i][j]);
                    Console.SetCursorPosition (x + i * 6, (y + j * 3) + 2);
                    Console.Write ("      ");
                    Console.ResetColor ();
                }
            }
        }
    }
}
