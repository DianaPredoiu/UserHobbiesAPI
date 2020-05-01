using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class TimesheetView
    {
        public DateTime Date { get; set; }

        
        public DateTime StartTime { get; set; }

       
        public DateTime EndTime { get; set; }


        public DateTime BreakTime { get; set; }

        public string Location { get; set; }

        public string Project { get; set; }

        public float WorkedHours { get; set; }

        public string Comments { get; set; }

        public int IdUser { get; set; }
    }
}
