using System;
using System.Collections.Generic;
using System.IO;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleColor currentForeground = Console.ForegroundColor;
            int idCounter = 0;
            TaskCollector taskCollector = new TaskCollector();
            ConsoleEx.WriteLine("Witaj w aplikacji do zarządzania zadaniami.", currentForeground);
            string command;
            while (true)
            {
                ConsoleEx.WriteLine("\n==============================================================" +
                                "\nDostępne komendy:" +
                                "\n\t\texit - wyjście z programu wraz z zapisem zmian," +
                                "\n\t\tadd - dodanie nowego zadania" +
                                "\n\t\tdel - usuwanie wybranego zadania" +
                                "\n\t\tsave - zapis zadań do pliku tasks.csv" +
                                "\n\t\tshow - pokaż wszystkie zadania" +
                                "\n\t\tload - załaduj zadania z pliku tasks.csv" +
                                "\n\t\tcolor - zmiana koloru wyswietlanego tekstu", currentForeground);
                command = Console.ReadLine();
                if (command == "add")
                {
                    idCounter++;
                    TaskModel currentTask = TaskModel.CreateTask(idCounter);
                    taskCollector.AddTask(currentTask);
                    ConsoleEx.WriteLine("Dodano zadanie do listy.", currentForeground);
                }
                if (command == "del")
                {
                    ConsoleEx.WriteLine("Podaj numer zadania do usunięcia: ", currentForeground);
                    int numToDel = Int32.Parse(Console.ReadLine());
                    taskCollector.RemoveTask(numToDel);
                }
                if (command == "save" || command == "exit")
                {
                    taskCollector.ExportTasks(currentForeground);
                    if (command == "exit")
                    {
                        ConsoleEx.WriteLine("Koniec programu.", currentForeground);
                        break;
                    }
                }
                if (command == "show")
                {
                    //taskCollector.ShowTasksAscendingId(currentForeground);
                    taskCollector.ShowTasksAscendigDate(currentForeground);
                }
                if (command == "load")
                {
                    idCounter = taskCollector.LoadTasks(currentForeground);
                }
                if (command == "color")
                {
                    ConsoleEx.WriteLine("Wpisz numer sposrod dostepnych kolorow tekstu: " +
                        "\n\tWhite = 1, " +
                        "\n\tRed = 2," +
                        "\n\tBlue = 3," +
                        "\n\tYellow = 4," +
                        "\n\tGreen = 5", currentForeground);
                    string newColour = Console.ReadLine();
                    if (newColour == "1") { currentForeground = ConsoleColor.White; }
                    if (newColour == "2") { currentForeground = ConsoleColor.Red; }
                    if (newColour == "3") { currentForeground = ConsoleColor.Blue; }
                    if (newColour == "4") { currentForeground = ConsoleColor.Yellow; }
                    if (newColour == "5") { currentForeground = ConsoleColor.Green; }
                }
            }
        }
    }
}