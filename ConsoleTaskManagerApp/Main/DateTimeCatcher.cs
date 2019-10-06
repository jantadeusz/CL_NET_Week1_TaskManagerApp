using System;
using System.Collections.Generic;
using System.Text;

namespace Main
{
    class DateTimeCatcher
    {
        //private DateTime DT;

        public DateTime Catch()
        {
            DateTime result;
            while (true)
            {
                Console.WriteLine("Podaj czas w formacie {YYYY-MM-DDTHH:MM:SS}: ");
                string candidateTime = Console.ReadLine();
                if (DateTime.TryParse(candidateTime, out result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Z podanego tekstu nie udało się odczytać daty lub godziny. Spróbuj ponownie.");
                }
            }
        }
    }
}
