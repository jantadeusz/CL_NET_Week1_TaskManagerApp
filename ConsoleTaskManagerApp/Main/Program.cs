using System;
using System.Collections.Generic;
using System.IO;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"F:\Coderslab.NET\01_Podstawy\CL_NET_Week1_TaskManagerApp\tasks.txt";
            int idCounter = 0;
            List<TaskModel> tasksToWrite = new List<TaskModel> { };
            // przy otwarciu programu wszystkie dane z pliku tekstowego sa parsowane i wciagane jako zadania na liste, 
            string[] stringsFromFile = File.ReadAllLines(path);
            foreach (string s in stringsFromFile)
            {
                TaskModel taskFromString = TaskModel.ParseTaskModelFromString(s);
                tasksToWrite.Add(taskFromString);
                idCounter = taskFromString.Id;
            }
            // po wczytaniu zadan do listy plik jest czyszczony
            File.Delete(path);
            File.Create(path).Close();
            // w tej chwili zadania istieja tylko na liscie
            Console.WriteLine("Witaj w aplikacji do zarządzania zadaniami.");
            string command;
            while (true)
            {
                Console.WriteLine("\n==============================================================" +
                                "\nDostępne komendy:" +
                                "\t\t\nexit - wyjście z programu wraz z zapisem zmian (zalecana komenda)," +
                                "\t\t\nadd - dodanie nowego zadania" +
                                "\t\t\ndel - usuwanie wybranego zadania" +
                                "\t\t\nsave - zapis zadań do pliku tekstowego (niezalecana komenda - mozliwa utrata danych" +
                                "\t\t\nshow - pokaż wszystkie zadania");
                command = Console.ReadLine();
                if (command == "add")
                {
                    idCounter++;
                    TaskModel currentTask = TaskModel.AddTask(idCounter);
                    tasksToWrite.Add(currentTask);
                    Console.WriteLine("Dodano zadanie do listy.");
                }
                if (command == "del")
                {
                    Console.WriteLine("Podaj numer zadania do usunięcia: ");
                    try
                    {
                        List<TaskModel> newTasksToWrite = new List<TaskModel> { };
                        int numToDel = Int32.Parse(Console.ReadLine());
                        foreach (TaskModel tm in tasksToWrite)
                        {
                            if (tm.Id != numToDel)
                            {
                                newTasksToWrite.Add(tm);
                            }
                        }
                        tasksToWrite = newTasksToWrite;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                if (command == "save" || command == "exit")
                {
                    Console.WriteLine("Zapis do pliku");
                    List<string> stringsFromTasks = new List<string> { };
                    foreach (TaskModel tm in tasksToWrite)
                    {
                        string tmp = tm.ToString();
                        stringsFromTasks.Add(tmp);
                    }
                    File.WriteAllLines(path, stringsFromTasks.ToArray());
                    tasksToWrite = new List<TaskModel> { };
                    if (command == "exit")
                    {
                        Console.WriteLine("Koniec programu.");
                        break;
                    }
                }
                if (command == "show")
                {
                    Console.WriteLine("Zadania z listy: ");
                    foreach (TaskModel tm in tasksToWrite)
                    {
                        Console.WriteLine(tm.ToString());
                    }
                }
            }
        }
    }
}