using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi
{
    public interface IProjectService
    {
        IEnumerable<Project> GetTeamProjects(int id);

        IEnumerable<Project> GetManagerProjects(int id);

        IEnumerable<Project> GetAll();

    }//INTERFACE IUserService
    public class ProjectService : IProjectService
    {
        private DataContext _context;

        //CONSTRUCTOR
        public ProjectService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Project> GetTeamProjects(int id)
        {
            var users = _context.Users;
            var timesheets = _context.Timesheets;
            var timesheetActivities = _context.TimesheetActivities;
            var projects = _context.Projects;

            var teamProjects = from ta in timesheetActivities
                        join t in timesheets on ta.IdTimesheet equals t.IdTimesheet
                        join p in projects on ta.IdProject equals p.IdProject
                        join u in users on t.IdUser equals u.IdUser
                        where u.IdTeam == id
                        select new Project
                        {
                            IdProject = p.IdProject,
                            ProjectName = p.ProjectName,
                            StartDate = p.StartDate,
                            EndDate = p.EndDate,
                            IsActive = p.IsActive
                        };

            return teamProjects;
        }

        public IEnumerable<Project> GetManagerProjects(int id)
        {
            var projects = _context.Projects;
            var projectManager = _context.ProjectManagers;

            var projectList = from pm in projectManager
                              join p in projects on pm.IdProject equals p.IdProject
                              where pm.IdProjectManager==id
                              select new Project
                              {
                                  IdProject = p.IdProject,
                                  ProjectName = p.ProjectName,
                                  StartDate = p.StartDate,
                                  EndDate = p.EndDate,
                                  IsActive = p.IsActive
                              };

            return projectList;
        }

        public IEnumerable<Project> GetAll()
        {
            return _context.Projects;
        }

    }
}
