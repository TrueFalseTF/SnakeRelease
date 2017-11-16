using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake : Figure
    {
        
        Direktion direktion;

        public Snake (Point tail, int length, Direktion _direktion)
        {
            direktion = _direktion;
            pList = new List<Point>();
            for(int i = 0; i < length; i++)
            {
                Point p = new Point(tail);
                p.Move(i, i, direktion);
                pList.Add(p);
            }

        }

        internal void Move( int offsetHorizontal, int offsetVertical)
        {
            Point tail = pList.First();
            pList.Remove(tail);
            Point head = GetNextPoint(offsetHorizontal, offsetVertical);
            pList.Add(head);

            tail.Clear();
            head.Draw();
        }
                
        public Point GetNextPoint( int offsetHorizontal, int offsetVertical)
        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(offsetHorizontal, offsetVertical, direktion);
            return nextPoint;
        }
              
        public void HendleKey (ConsoleKey key)
        {            
            if (key == ConsoleKey.LeftArrow && direktion != Direktion.RIGHT)
            {
                direktion = Direktion.LEFT; 
            }
            else if (key == ConsoleKey.RightArrow && direktion != Direktion.LEFT)
            {
                direktion = Direktion.RIGHT;
            }
            else if (key == ConsoleKey.UpArrow && direktion != Direktion.BOTTOM)
            {
                direktion = Direktion.TOP;
            }
            else if (key == ConsoleKey.DownArrow && direktion != Direktion.TOP)
            {
                direktion = Direktion.BOTTOM;
            }

        }

        internal bool Eat(Point food, int offsetHorizontal, int offsetVertical)
        {
            Point head = GetNextPoint(offsetHorizontal, offsetVertical);
            if (head.IsHit(food))
            //if(head.x == food.x && head.y == food.y)
            {
                food.sym = head.sym;
                pList.Add(food);
                return true;
            }
            else
            {
                return false;
            }
           
        }
                
        public bool IsHitTail()
        {
            var head = pList.Last();
            for (int i = 0; i < pList.Count - 2; ++i)
            {
                if (head.IsHit(pList [i]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
