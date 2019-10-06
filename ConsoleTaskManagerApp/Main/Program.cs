using System;
using System.Collections.Generic;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            List<TaskModel> tasksToWrite = new List<TaskModel> { };
            while (true)
            {
                Console.WriteLine("Witaj w aplikacji do zarządzania zadaniami. " +
                                "\nDostępne komendy:" +
                                "\nexit - wyjście z programu," +
                                "\nadd - dodanie zadania" +
                                "\ndel - usuwanie zadania" +
                                "\nsave - zapis do pliku" +
                                "\nshow - wczytuj zadania");
                command = Console.ReadLine();
                if (command == "exit")
                {
                    Console.WriteLine("Koniec programu.");
                    break;
                }
                if (command == "add")
                {
                    string taskDescription;
                    DateTime startTime;
                    // =========================================== pobranie opisu zadania
                    Console.WriteLine("Podaj opis zadania: ");
                    taskDescription = Console.ReadLine();
                    // =========================================== pobranie czasu rozpoczęcia
                    Console.WriteLine("Czy zadanie ma się rozpoczynać w chwili obecnej? Wpisanie {t} oznacza akceptację: ");
                    if (Console.ReadLine() == "t")
                    {
                        startTime = DateTime.Now;
                        Console.WriteLine("Jezeli t: " + startTime.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Przypisanie deklarowanej daty rozpoczęcia.");
                        DateTimeCatcher startCatcher = new DateTimeCatcher();
                        startTime = startCatcher.Catch();
                        Console.WriteLine("Jezeli n: " + startTime.ToString());
                    }
                    // =========================================== właściwe utworzenie zadania przez konstruktor
                    TaskModel task = new TaskModel(taskDescription, startTime.ToString());
                    Console.WriteLine("Utworzono nowe zadanie.");
                    // =========================================== ustalenie czasu trwania zadania -> czasu zakończenia
                    Console.WriteLine("Czy zadanie jest całodniowe? Wpisanie {t} oznacza potwierdzenie: ");
                    if (Console.ReadLine() == "t")
                    {
                        task.WholeDayTask = true;
                    }
                    else
                    {
                        Console.WriteLine("Zadanie na godziny. Podaj przewidywany czas trwania zadania: ");
                        DurationCatcher durationCatcher = new DurationCatcher();
                        int taskDurationInHours = durationCatcher.Catch();
                        DateTime endTime = startTime.AddHours((double)taskDurationInHours);
                        task.EndDate = endTime.ToString();
                    }
                    // =========================================== ustalenie ważności
                    Console.WriteLine("Czy zadanie ważne? Wpisanie {t} oznacza potwierdzenie: ");
                    if (Console.ReadLine() == "t")
                    {
                        task.ImportantTask = true;
                    }
                    // =========================================== ostatecznie dodanie gotowego zadania do listy
                    tasksToWrite.Add(task);
                    Console.WriteLine("Dodano zadanie do listy.");
                }
                if (command == "del")
                {
                    Console.WriteLine("Usuwanie zadania");
                }
            }
        }
    }
}
