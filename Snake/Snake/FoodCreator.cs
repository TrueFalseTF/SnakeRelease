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
        private char sym;//Поля класса с локальной доступностью

        Random random = new Random();

        public FoodCreator(int mapWidht, int mapHeight, char sym)
        {
            this.mapWidht = mapWidht; // this - идентифицирует переменную объекта класс при совпадении её индексации с переменной параметра конструктора
            this.mapHeight = mapHeight;
            this.sym = sym;
        }

        public Point CreateFood()
        {
            int x = random.Next(2, mapWidht - 2);
            int y = random.Next(2, mapHeight - 2);
            return new Point(x, y, sym);
        }
    }
}
