using System;
using System.Collections.Generic;
using System.Text;

namespace Main
{
    public class TaskModel
    {

        //=======================================================
        public int Id { get; }
        private string _description = null;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        //=======================================================
        private string _startDate = null;
        public string StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }
        //=======================================================
        private string _endDate = null;
        public string EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }
        //=======================================================
        private bool _wholeDayTask = false;
        public bool WholeDayTask
        {
            get { return _wholeDayTask; }
            set { _wholeDayTask = value; }
        }
        //=======================================================
        private bool _importantTask = false;
        public bool ImportantTask
        {
            get { return _importantTask; }
            set { _importantTask = value; }
        }
        public TaskModel() { }
        public TaskModel(int idNumber, string desc, string sd)
        {
            Id = idNumber;
            Description = desc;
            StartDate = sd;
        }
        public static TaskModel AddTask(int identityNumber)
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
            }
            else
            {
                Console.WriteLine("Przypisanie deklarowanej daty rozpoczęcia.");
                DateTimeCatcher startCatcher = new DateTimeCatcher();
                startTime = startCatcher.Catch();
            }
            // utworzenie zadania przez konstruktor
            TaskModel thisTask = new TaskModel(identityNumber, taskDescription, startTime.ToString());
            // dodawanie nowych informacji
            Console.WriteLine("Czy zadanie jest całodniowe? Wpisanie {t} oznacza potwierdzenie: ");
            if (Console.ReadLine() == "t")
            {
                thisTask.WholeDayTask = true;
            }
            else
            {
                DurationCatcher durationCatcher = new DurationCatcher();
                int taskDurationInHours = durationCatcher.Catch();
                DateTime endTime = startTime.AddHours((double)taskDurationInHours);
                thisTask.EndDate = endTime.ToString();
            }
            // =========================================== ustalenie ważności
            Console.WriteLine("Czy zadanie ważne? Wpisanie {t} oznacza potwierdzenie: ");
            if (Console.ReadLine() == "t")
            {
                thisTask.ImportantTask = true;
            }
            Console.WriteLine("Utworzono nowe zadanie.");
            return thisTask;
        }

        public string ToString()
        {
            return Id + "|" + Description + "|" + StartDate + "|" + WholeDayTask + "|" + ImportantTask + "|" + EndDate;
        }

        public static TaskModel ParseTaskModelFromString(string taskFromFile)
        {
            TaskModel tm = new TaskModel();
            string[] taskInfo = taskFromFile.Split('|');
            try
            {
                int id = Int32.Parse(taskInfo[0]);
                string description = taskInfo[1];
                DateTime startDate = DateTime.Parse(taskInfo[2]);
                tm = new TaskModel(id, description, startDate.ToString());
                if (taskInfo.Length > 3)
                {
                    bool wholeDayTask = bool.Parse(taskInfo[3]);
                    tm.WholeDayTask = wholeDayTask;
                }
                if (taskInfo.Length > 4)
                {
                    bool importantTask = bool.Parse(taskInfo[4]);
                    tm.ImportantTask = importantTask;
                }
                if (taskInfo.Length > 5)
                {
                    if (!String.IsNullOrWhiteSpace(taskInfo[5]))
                    {
                        DateTime endDate = DateTime.Parse(taskInfo[5]);
                        tm.EndDate = endDate.ToString();
                    }
                }
                return tm;
            }
            catch (Exception e)
            {
                Console.WriteLine("Blad odczytu danych z pliku. Tresc błędu: " + e);
            }
            return tm;
        }
    }
}
/*
Encja TaskModel musi zawierać następujące atrybuty.
Opis - Wymagany.
Datę Rozpoczęcia - Wymagana.
Datę Zakończenia - Niewymagana, jeśli zadanie jest całodniowe.
Flaga Zadanie Całodniowe - Niewymagana, domyślnie zadanie nie jest całodniowe.
Flagę Zadanie Ważne - Niewymagana, domyślnie zadanie nie jest ważne.
Jeśli flaga zadanie całodniowe jest ustawiona, data zakończenia nie jest wymagana.
*/
