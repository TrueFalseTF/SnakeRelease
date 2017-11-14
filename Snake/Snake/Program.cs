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
                        
            Point p = new Point(1, 3, '*');
            Snake snake = new Snake(p, 4, Direktion.RIGHT);
            snake.Drow();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while(true)
            {
                if(snake.IsHitTail())
                {
                    break;
                }
                
                if(snake.Eat(food, -76, -23))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }

                if (snake.Eat(food, 1, 1))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }

                if (walls.IsHit(snake))
                {
                    snake.Move(-76, -23);
                }
                else
                {
                    snake.Move(1,1);
                }

                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HendleKey(key.Key);
                }               
            }            
        }        
    }
}
