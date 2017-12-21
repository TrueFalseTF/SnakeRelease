using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class FoodCreator
    {
        private int mapWidht;
        private int mapHeight;
        private char sym;

        

        public FoodCreator(int mapWidht, int mapHeight, char sym)
        {
            this.mapWidht = mapWidht; // this - идентифицирует переменную объекта класс при совпадении её индексации с переменной параметра конструктора
            this.mapHeight = mapHeight;
            this.sym = sym;
        }

        

        public Point CreateFood(Figure snake)
        {
            Point p = new Point(0, 0, sym);
            do
            {
                Random random = new Random();
                p.x = random.Next(2, mapWidht - 2);
                p.y = random.Next(2, mapHeight - 2);

                
            } while (snake.IsHit(p));

            return p;
        }
    }
}