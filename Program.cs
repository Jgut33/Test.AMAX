using System;
using System.Linq;

namespace Test.AMAX
{
    class Program
    {



        static void Main(string[] args)
        {
            int[] maze1;
            int[] enter1;
            int[] exit1;

            while (true)        // checking input
            {
                Console.WriteLine("Insert the maze's parameters in format: lenght height");
                string maze = Console.ReadLine();
                Console.WriteLine("Insert coordinates of the starting point");
                string enter = Console.ReadLine();
                Console.WriteLine("Insert coordinates of the exit point");
                string exit = Console.ReadLine();
                maze1 = maze.Split(' ').Select(int.Parse).ToArray();
                enter1 = enter.Split(' ').Select(int.Parse).ToArray();
                exit1 = exit.Split(' ').Select(int.Parse).ToArray();
                if (maze1.Length != 2 || enter1.Length != 2 || exit1.Length != 2)
                    Console.WriteLine("Wrong enter format");
                else if (enter1[0] > maze1[0] + 1 || enter1[0] < 0 || enter1[1] > maze1[1] + 1 || enter1[1] < 0 || exit1[0] > maze1[0] + 1 || exit1[0] < 0 || exit1[1] > maze1[1] + 1 || exit1[0] < 0)
                    Console.WriteLine("Wrong starting or exit coordinates");
                else
                    break;
            }

            Console.WriteLine("Build your maze with tools ═║╗╝╚╔");       //building maze
            string[,] mazebuild = new string[maze1[0] + 2, maze1[1] + 2];
            for (int i = 1; i < maze1[1] + 1; i++)
            {
                string row = Console.ReadLine();
                char[] row1 = row.ToCharArray();
                for (int j = 1; j < maze1[0] + 1; j++)
                    mazebuild[j, i] = Convert.ToString(row1[j - 1]);
            }

            string a186 = "║";
            string a187 = "╗";
            string a188 = "╝";
            string a200 = "╚";
            string a201 = "╔";
            string a205 = "═";
            int x = enter1[0];
            int y = enter1[1];
            int x0 = 0;
            int y0 = 0;

            while (x != exit1[0] && y != exit1[1])      //searching for the exit
            {
                if (x == 0 && y == 0)
                    break;
                else if (x == 0)
                {
                    if (mazebuild[x + 1, y] == a187 || mazebuild[x + 1, y] == a188 || mazebuild[x + 1, y] == a205)
                    {
                        x0 = x;
                        y0 = y;
                        x++;
                    }
                    else
                        break;
                }
                else if (y == 0)
                {
                    if (mazebuild[x, y + 1] == a186 || mazebuild[x, y + 1] == a200 || mazebuild[x, y + 1] == a188)
                    {
                        x0 = x;
                        y0 = y;
                        y++;
                    }
                    else
                        break;
                }
                else if (x == maze1[0] + 1)
                {
                    if (mazebuild[x - 1, y] == a200 || mazebuild[x - 1, y] == a201 || mazebuild[x - 1, y] == a205)
                    {
                        x0 = x;
                        y0 = y;
                        x--;
                    }
                    else
                        break;
                }
                else if (y == maze1[1] + 1)
                {
                    if (mazebuild[x, y - 1] == a186 || mazebuild[x, y - 1] == a187 || mazebuild[x, y - 1] == a201)
                    {
                        x0 = x;
                        y0 = y;
                        y--;
                    }
                    else
                        break;
                }
                else
                {
                    if (x0 - x == -1)
                    {
                        if (mazebuild[x, y] == a187)
                        {
                            if (mazebuild[x, y + 1] == a186 || mazebuild[x, y + 1] == a200 || mazebuild[x, y + 1] == a188)
                            {
                                x0 = x;
                                y0 = y;
                                y++;
                            }
                            else
                                break;
                        }
                        else if (mazebuild[x, y] == a188)
                        {
                            if (mazebuild[x, y - 1] == a186 || mazebuild[x, y - 1] == a187 || mazebuild[x, y - 1] == a201)
                            {
                                x0 = x;
                                y0 = y;
                                y--;
                            }
                            else
                                break;
                        }
                        else if (mazebuild[x, y] == a205)
                        {
                            if (mazebuild[x + 1, y] == a187 || mazebuild[x + 1, y] == a188 || mazebuild[x + 1, y] == a205)
                            {
                                x0 = x;
                                y0 = y;
                                x++;
                            }
                            else
                                break;
                        }
                        else
                            break;
                    }
                    else if (x0 - x == 1)
                    {
                        if (mazebuild[x, y] == a200)
                        {
                            if (mazebuild[x, y - 1] == a186 || mazebuild[x, y - 1] == a187 || mazebuild[x, y - 1] == a201)
                            {
                                x0 = x;
                                y0 = y;
                                y--;
                            }
                            else
                                break;
                        }
                        else if (mazebuild[x, y] == a201)
                        {
                            if (mazebuild[x, y + 1] == a186 || mazebuild[x, y + 1] == a200 || mazebuild[x, y + 1] == a188)
                            {
                                x0 = x;
                                y0 = y;
                                y++;
                            }
                            else
                                break;
                        }
                        else if (mazebuild[x, y] == a205)
                        {
                            if (mazebuild[x - 1, y] == a200 || mazebuild[x - 1, y] == a201 || mazebuild[x - 1, y] == a205)
                            {
                                x0 = x;
                                y0 = y;
                                x--;
                            }
                            else
                                break;
                        }
                        else
                            break;
                    }
                    else if (y0 - y == -1)
                    {
                        if (mazebuild[x, y] == a200)
                        {
                            if (mazebuild[x + 1, y] == a187 || mazebuild[x + 1, y] == a188 || mazebuild[x + 1, y] == a205)
                            {
                                x0 = x;
                                y0 = y;
                                x++;
                            }
                            else
                                break;
                        }
                        else if (mazebuild[x, y] == a186)
                        {
                            if (mazebuild[x, y + 1] == a186 || mazebuild[x, y + 1] == a200 || mazebuild[x, y + 1] == a188)
                            {
                                x0 = x;
                                y0 = y;
                                y++;
                            }
                            else
                                break;
                        }
                        else if (mazebuild[x, y] == a188)
                        {
                            if (mazebuild[x - 1, y] == a200 || mazebuild[x - 1, y] == a201 || mazebuild[x - 1, y] == a205)
                            {
                                x0 = x;
                                y0 = y;
                                x--;
                            }
                            else
                                break;
                        }
                        else
                            break;
                    }
                    else if (y0 - y == 1)
                    {
                        if (mazebuild[x, y] == a186)
                        {
                            if (mazebuild[x, y - 1] == a186 || mazebuild[x, y - 1] == a187 || mazebuild[x, y - 1] == a201)
                            {
                                x0 = x;
                                y0 = y;
                                y--;
                            }
                            else
                                break;
                        }
                        else if (mazebuild[x, y] == a187)
                        {
                            if (mazebuild[x - 1, y] == a200 || mazebuild[x - 1, y] == a201 || mazebuild[x - 1, y] == a205)
                            {
                                x0 = x;
                                y0 = y;
                                x--;
                            }
                            else
                                break;
                        }
                        else if (mazebuild[x, y] == a201)
                        {
                            if (mazebuild[x + 1, y] == a187 || mazebuild[x + 1, y] == a188 || mazebuild[x + 1, y] == a205)
                            {
                                x0 = x;
                                y0 = y;
                                x++;
                            }
                            else
                                break;
                        }
                        else
                            break;
                    }
                    else if (x0 - x == 0 && y0 - y == 0)
                    {
                        Console.WriteLine("point deriction where to go (up, down, left, right)");
                        string answer = Console.ReadLine();
                        if (answer == "up")
                            y0++;
                        else if (answer == "down")
                            y0--;
                        else if (answer == "left")
                            x0++;
                        else if (answer == "right")
                            x0--;
                        else
                            Console.WriteLine("wrong direction");
                    }
                }
            }

            if (x != exit1[0] && y != exit1[1])
                Console.WriteLine("false");
            else
                Console.WriteLine("true");

            Console.ReadKey();
        }
    }
}