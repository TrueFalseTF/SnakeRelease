using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Write
    {
        

        public Write(ConsoleColor color)
        {             
            Console.ForegroundColor = color;
        }

        public void Menu( int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            WriteText("SNAKE2(Limited edition)", xOffset, yOffset);
            yOffset += 2;
            WriteText("Начать одиночную охоту", xOffset++ , yOffset++);
            yOffset++;
            WriteText("Начать охоту с другом", xOffset , yOffset++);
            yOffset++;
            WriteText("Настройки", xOffset + 5, yOffset++);
            VerticalLine LineL = new VerticalLine(yOffset - 8, yOffset, xOffset - 3, '|');
            LineL.Drow();
            VerticalLine LineR = new VerticalLine(yOffset - 8, yOffset, xOffset + 22, '|');
            LineR.Drow();
        }

        public void GameOver(int xOffset, int yOffset)
        {                         
            Console.SetCursorPosition(xOffset, yOffset);
            HorizontalLine LineT = new HorizontalLine (xOffset, xOffset + 28, yOffset, '=');
            LineT.Drow();
            WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset - 27, yOffset++);
            yOffset++;
            WriteText("Автор: Дмитрий Чёпоров", xOffset + 2, yOffset++);
            HorizontalLine LineB = new HorizontalLine(xOffset, xOffset + 28, yOffset++, '=');
            LineB.Drow();
        }

        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }        
    }
}