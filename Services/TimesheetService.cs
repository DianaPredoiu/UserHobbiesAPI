using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi
{
    public interface ITimesheetService
    {
        IEnumerable<Timesheet> GetTimesheetById(int id,DateTime date);

        IEnumerable<Timesheet> GetAll();

        Timesheet Create(Timesheet timesheet);

    }//INTERFACE IUserService
    public class TimesheetService: ITimesheetService
    {
        private DataContext _context;

        //CONSTRUCTOR
        public TimesheetService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Timesheet> GetTimesheetById(int id, DateTime date)
        {
            var timesheets = _context.Timesheets;
            var timesheetActivities = _context.TimesheetActivities;
            var projects = _context.Projects;

            var timesheet = from t in timesheetActivities
                            join ts in timesheets on t.IdTimesheet equals ts.IdTimesheet
                            join p in projects on t.IdProject equals p.IdProject
                            where ts.IdUser == id && ts.Date == date
                            select new Timesheet
                            {
                                IdTimesheet = ts.IdTimesheet,
                                IdUser = ts.IdUser,
                                IdLocation = ts.IdLocation,
                                Date = ts.Date,
                                StartTime = ts.StartTime,
                                EndTime = ts.EndTime,
                                BreakTime = ts.BreakTime
                            };

            return timesheet;
        }

        public IEnumerable<Timesheet> GetAll()
        {
            return _context.Timesheets;
        }

        public Timesheet Create(Timesheet timesheet)
        {
            _context.Timesheets.Add(timesheet);
            _context.SaveChanges();

            return timesheet;
        }
    }
}
