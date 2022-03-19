using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
    class Boss : Employee
    {
        new private int SalaryForHour =  350;
        private string Project;
        public Boss(string Name, string Surname, string Id, string Position, string WorkOn, int HoursOfWork, string Project)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Id = Id;
            this.Position = Position;
            this.WorkOn = WorkOn;
            this.HoursOfWork = HoursOfWork;
            this.Salary = HoursOfWork * SalaryForHour;
            this.Project = Project;
        }
        new public string Info()
        {
            string Info = $"{Surname} {Name} {Id} {Position} {WorkOn} {HoursOfWork} {Salary} {Project}";
            return Info;
        }
    }
}
