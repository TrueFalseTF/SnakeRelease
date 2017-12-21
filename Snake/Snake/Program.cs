using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(80, 25);
                        
            Walls walls = new Walls(80, 25);
            walls.Draw();

            Write write = new Write(ConsoleColor.Red);
            write.Menu(25, 8);
            while (true)
            {
                break;
            }
                        
            Point p = new Point(1, 5, '*');
            Snake snake = new Snake(p, 4, Direktion.RIGHT);
            snake.Drow();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood(snake);
            food.Draw();

            while(true)
            {
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

            write.GameOver(25, 8);
            Console.ReadLine();
        }        
    }
}