using System;
using System.Collections.Generic;
using System.Text;

namespace Main
{
    public static class ConsoleEx
    {
        public enum TextColour
        {
            White = 1,
            Red = 2,
            Blue = 3,
            Yellow = 4,
            Green = 5
        }  
        // nie mam pomyslu jak to zrobic zeby kolor bral sie z enuma w program.cs 
        // a nie z przypisania currentForeground w metodzie statycznej
        public static void WriteLine(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
        }
        public static void Write(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
        }
    }
}