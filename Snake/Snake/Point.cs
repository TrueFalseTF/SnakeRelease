using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Point
    {
        public int x;
        public int y;
        public char sym;//Поля класса c глобальной доступностью

        public Point()
        {
            
        }

        public Point(int _x, int _y, char _sym)
        {
            x = _x;
            y = _y;
            sym = _sym;
        }

        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }

        public void Move(int offset, Direktion direktion)
        {
            if(direktion == Direktion.LEFT)
            {
                x = x - offset;
            }
            else if (direktion == Direktion.RIGHT)
            {
                x = x + offset;
            }
            else if (direktion == Direktion.TOP)
            {
                y = y - offset;
            }
            else if (direktion == Direktion.BOTTOM)
            {
                y = y + offset;
            }                   
        }
        
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }

        public void Clear()
        {
            sym = ' ';
            Draw();
        }

        internal bool IsHit(Point p)
        {
            return p.x == this.x && p.y == this.y;
        }

        public override string ToString()//меняет значение имени объекта
        {
            return x + "," + y + "," + sym;
        }

        
    }
}
