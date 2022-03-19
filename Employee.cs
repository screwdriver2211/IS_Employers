using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
    public class Employee
    {
        protected string Name;
        protected string Surname;
        protected string Id;
        protected string Position;
        protected int HoursOfWork;
        protected string WorkOn;
        protected int SalaryForHour = 150;
        protected int Salary;
        private string Project = "Нет";

        public Employee(){}
        public Employee(string Name, string Surname, string Id, string Position, string WorkOn, int HoursOfWork)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Id = Id;
            this.Position = Position;
            this.WorkOn = WorkOn;
            this.HoursOfWork = HoursOfWork;
            this.Salary = HoursOfWork * SalaryForHour; 
        }
        public string Info()
        {
            string Info = $"{Surname} {Name} {Id} {Position} {WorkOn} {HoursOfWork} {Salary} {Project}";
            return Info;
        }
    }
}
