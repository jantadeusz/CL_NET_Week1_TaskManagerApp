using System;
using System.Collections.Generic;
using System.Text;

namespace Main
{
    class DurationCatcher
    {
        public int Catch()
        {
            int result;
            while (true)
            {
                Console.WriteLine("Podaj przewidywany czas trwania zadania: ");
                if (Int32.TryParse(Console.ReadLine(), out result))
                {
                    if (result > 0)
                    {
                        return result;
                    }
                    else
                    {
                        Console.WriteLine("Czas musi być >0. Spróbuj jeszcze raz.");
                    }
                }
                else
                {
                    Console.WriteLine("Złe dane. Spróbuj jeszcze raz.");
                }
            }
        }
    }
}
