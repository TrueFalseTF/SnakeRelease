﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Snake
{
    class Program
    {        
        static void Main(string[] args)
        {
                        
            int mapWight = 80;
            int mapHeight = 25;

            Console.SetWindowSize(mapWight, mapHeight);
            Console.SetBufferSize(mapWight, mapHeight);

            Walls walls = new Walls(mapWight, mapHeight);


            Point p = new Point(1, 5, '*');
            Snake snake = new Snake(p, 20, Direktion.RIGHT);

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood(snake);

            startDraw(walls, snake, food);


            while (true)
            {
                CheckAndResetWindowSize(mapWight, mapHeight, walls, snake, food);// не работатет

                Thread.Sleep(100);

                if (Console.KeyAvailable && walls.IsHit(snake) == false)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HendleKey(key.Key);
                }

                if (snake.IsHitTail())
                {
                    break;
                }
                
                if(snake.Eat(food, -77, -23))
                {
                    food = foodCreator.CreateFood(snake);
                    food.Draw();
                }

                if (snake.Eat(food, 1, 1))
                {
                    food = foodCreator.CreateFood(snake);
                    food.Draw();
                }

                if (walls.IsHit(snake))
                {
                    snake.Move(-77, -23);
                    walls.Draw();
                }
                else
                {
                    snake.Move(1,1);
                }                 
            }

            WriteGameOver();
            Console.ReadLine();
        }

        static void WriteGameOver()
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
            yOffset++;
            WriteText("Автор: Дмитрий Чёпоров", xOffset + 2, yOffset++);            
            WriteText("============================", xOffset, yOffset++);
        }

        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }

        static void CheckAndResetWindowSize(int mapWight, 
                                            int mapHeight, 
                                            Walls walls, 
                                            Snake snake,
                                            Point food)
        {
            if (Console.WindowWidth < mapWight || Console.WindowHeight < mapHeight)
            {
                Console.SetWindowSize(mapWight, mapHeight);
                startDraw(walls, snake, food);// не работает
            }
            
        }

        static void startDraw(Walls walls, Snake snake, Point food)
        {

            walls.Draw();

            snake.Drow();

            food.Draw();

        }
    }
}
