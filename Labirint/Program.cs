using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Labirint
{

    internal class Program
    {
        static void Main(string[] args)
        {
            int y = 0;
            int x = 0;
            int i = 0;
            int j = 0;
            var wall = '█';
            var pus = ' ';
            var player = '☺';
            var end = '*';
            int count = 0;
            int playerY = -1;
            int playerX = -1;
            bool start = true;

            int[,] maze = new int[20, 20]
           {
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            {1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1},
            {1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 0, 1},
            {1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1},
            {1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1},
            {1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1},
            {1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 0, 1},
            {1, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1},
            {1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1},
            {1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1},
            {1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 0, 1},
            {1, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1},
            {1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 0, 1, 1, 1},
            {1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1},
            {1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1},
            {1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1},
            {1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 1, 1, 0, 1},
            {1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1, 0, 0, 1},
            {1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1},
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
           };
            for (i = 0; i < maze.GetLength(0); i++)
            {
                for (j = 0; j < maze.GetLength(1); j++)
                {
                    Console.SetCursorPosition(x++, y);
                    count++;
                    Console.ForegroundColor = ConsoleColor.White;
                    if (maze[i, j] == 0)
                    {
                        Console.WriteLine(pus);
                    }
                    if (maze[i, j] == 1)
                    {
                        Console.WriteLine(wall);
                    }
                    if (maze[i, j] == 2)
                    {
                        Console.Write(player);
                        playerX = j;
                        playerY = i;
                    }
                    if (maze[i, j] == 3)
                    {   Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(end);
                        Console.ForegroundColor = ConsoleColor.White;
                    }


                    if (count == 20 || count == 40  || count == 60|| count == 80 || count == 100 || count == 120 || count == 140 
                    || count == 160 || count == 180 || count == 200 || count == 220 || count == 240 || count == 260 || count == 280 || count == 300 || count == 320 || count == 340 || count == 360
                    || count == 380 || count == 400)
                    {
                        Console.SetCursorPosition(x -= 20, y++);
                    }
                }
            }

            Console.CursorVisible = false;
            ConsoleKeyInfo key;
            Console.SetCursorPosition(x = playerX, y = playerY);
            Console.Write("☺");

            while (start)
            {
                key = Console.ReadKey(true);

                    if (key.KeyChar == 119 || key.KeyChar == 87)
                    {
                       if (maze[playerY - 1, playerX] != 1)
                        {
                            Console.SetCursorPosition(x, y--); Console.Write(" ");
                            Console.SetCursorPosition(x, y); Console.Write("☺");
                            playerY--;
                        }
                    }
                    else if (key.KeyChar == 115 || key.KeyChar == 83)
                    {
                        if (maze[playerY + 1, playerX] != 1)
                        {
                            Console.SetCursorPosition(x, y++); Console.Write(" ");
                            Console.SetCursorPosition(x, y); Console.Write("☺");
                            playerY++;
                        }
                    }
                    else if (key.KeyChar == 97 || key.KeyChar == 65)
                    {
                        if (maze[playerY, playerX - 1] != 1)
                        {
                            Console.SetCursorPosition(x--, y); Console.Write(" ");
                            Console.SetCursorPosition(x, y); Console.Write("☺");
                            playerX--;
                        }
                    }
                    else if (key.KeyChar == 100 || key.KeyChar == 68)
                    {
                        if (maze[playerY, playerX + 1] != 1)
                        {
                            Console.SetCursorPosition(x, y); Console.Write(" ");
                            Console.SetCursorPosition(++x, y); Console.Write("☺");
                            playerX++;
                        }
                    }
                if (playerY == 18 & playerX == 18)
                {
                    start = false;
                    
                }
            }
            Console.Clear();
            Console.SetCursorPosition(x = 50, y = 15);
            Console.WriteLine("Вы прошли лабиринт");
            Console.SetCursorPosition(x-=50, y = 30);
            Console.WriteLine("Нажмите Enter чтобы завершить игру");
            Console.ReadLine();
        }
    }
}        