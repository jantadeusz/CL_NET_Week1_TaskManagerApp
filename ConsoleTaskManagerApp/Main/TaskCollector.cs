using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Main
{
    class TaskCollector
    {
        List<TaskModel> tasks = new List<TaskModel> { };
        string path = @"F:\Coderslab.NET\01_Podstawy\CL_NET_Week1_TaskManagerApp\tasks.csv";
        int idCounter = 0;
        // jezeli nie wczytalem ale dodaje do listy zadania to powinno sie append do pliku zrobic
        // jezeli wczytalem zadania z pliku
        public void AddTask(TaskModel taskModel)
        {
            tasks.Add(taskModel);
        }
        public void RemoveTask(int numToDel)
        {
            try
            {
                List<TaskModel> newTasksToWrite = new List<TaskModel> { };
                foreach (TaskModel tm in tasks)
                {
                    if (tm.Id != numToDel)
                    {
                        newTasksToWrite.Add(tm);
                    }
                }
                tasks = newTasksToWrite;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public int LoadTasks(ConsoleColor currentForeground)
        {
            string[] stringsFromFile = File.ReadAllLines(path);
            foreach (string s in stringsFromFile)
            {
                TaskModel taskFromString = TaskModel.ParseTaskModelFromString(s);
                tasks.Add(taskFromString);
                idCounter = taskFromString.Id;
            }
            File.Delete(path);
            File.Create(path).Close();
            ConsoleEx.WriteLine("Poprawnie załadowano zadania z pliku.", currentForeground);
            return idCounter;
        }
        public void ExportTasks(ConsoleColor currentForeground)
        {
            ConsoleEx.WriteLine("Zapis do pliku", currentForeground);
            List<string> stringsFromTasks = new List<string> { };
            foreach (TaskModel tm in tasks)
            {
                string tmp = tm.ToStringWithCommas();
                stringsFromTasks.Add(tmp);
            }
            File.AppendAllLines(path, stringsFromTasks.ToArray());
            tasks = new List<TaskModel> { };
        }
        public void ShowTasksAscendigDate(ConsoleColor currentForeground)
        {
            List<TaskModel> importantTasks = new List<TaskModel> { };
            List<TaskModel> otherTasks = new List<TaskModel> { };
            foreach (TaskModel taskModel in tasks)
            {
                if (taskModel.ImportantTask == true)
                {
                    importantTasks.Add(taskModel);
                }
                else
                {
                    otherTasks.Add(taskModel);
                }
            }
            int width = 20;
            string naglowek = "Id".PadLeft(width) + "|" +
                               "Description".PadLeft(width) + "|" +
                               "Start Date".PadLeft(width) + "|" +
                               "End Date".PadLeft(width) + "|" +
                               "WholeDayTask".PadLeft(width) + "|" +
                               "ImportantTask".PadLeft(width);

            ConsoleEx.WriteLine("==============================================", currentForeground);
            ConsoleEx.WriteLine("Zadania ważne: ", currentForeground);
            ConsoleEx.WriteLine(naglowek, currentForeground);
            IOrderedEnumerable<TaskModel> importantTasksOrdered = importantTasks.OrderBy(x => x.StartDate);
            foreach (TaskModel taskModel in importantTasksOrdered)
            {
                try
                {
                    TaskModel.ShowTaskInTable(taskModel, width, currentForeground);
                }
                catch (Exception e)
                {
                    ConsoleEx.WriteLine(e.ToString(), currentForeground);
                }
            }
            ConsoleEx.WriteLine("==============================================", currentForeground);
            ConsoleEx.WriteLine("Zadania pozostałe: ", currentForeground);
            ConsoleEx.WriteLine(naglowek, currentForeground);
            IOrderedEnumerable<TaskModel> otherTasksOrdered = otherTasks.OrderBy(x => x.StartDate);
            foreach (TaskModel taskModel in otherTasksOrdered)
            {
                try
                {
                    TaskModel.ShowTaskInTable(taskModel, width, currentForeground);
                }
                catch (Exception e)
                {
                    ConsoleEx.WriteLine(e.ToString(), currentForeground);
                }
            }
        }
    }
}