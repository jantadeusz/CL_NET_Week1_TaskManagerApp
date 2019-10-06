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
        public TaskModel(string desc, string sd)
        {
            Description = desc;
            StartDate = sd;
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
