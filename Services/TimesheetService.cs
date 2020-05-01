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
        IEnumerable<TimesheetView> GetTimesheetById(int id);

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

        public IEnumerable<TimesheetView> GetTimesheetById(int id)
        {
            var timesheets = _context.Timesheets;
            var timesheetActivities = _context.TimesheetActivities;
            var projects = _context.Projects;
            var locations = _context.Locations;

            var timesheet = from t in timesheetActivities
                            join ts in timesheets on t.IdTimesheet equals ts.IdTimesheet
                            join l in locations on ts.IdLocation equals l.IdLocation
                            join p in projects on t.IdProject equals p.IdProject                          
                            where ts.IdUser == id
                            select new TimesheetView
                            {
                                Location=l.LocationName,
                                Project=p.ProjectName,
                                IdUser=ts.IdUser,
                                Date = ts.Date,
                                StartTime = ts.StartTime,
                                EndTime = ts.EndTime,
                                BreakTime = ts.BreakTime,
                                WorkedHours=t.WorkedHours,
                                Comments=t.Comments
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
