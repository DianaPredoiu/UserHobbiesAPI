using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IQueryService
    {
        IEnumerable<Hobby> getList(int id);

    }//INTERFACE IQueryService
    public class QueryService : IQueryService
    {
        //CONTEXT
        private DataContext _context;

        //CONTRUCTOR
        public QueryService(DataContext context)
        {
            _context = context;
        }

        //GET HOBBIES LIST FOR SPECIFIED USER
        public IEnumerable<Hobby> getList(int id)
        {
            var users = _context.Users;
            var hobbies = _context.Hobbies;
            var user_hobbies = _context.User_Hobbies;

            var userHobbiesList = from uh in user_hobbies
                                  join u in users on uh.UserId equals u.IdUser
                                  join h in hobbies on uh.HobbyId equals h.IdHobby
                                  where uh.UserId==id
                                  select new Hobby
                                  {
                                      HobbyName= h.HobbyName,
                                      _HobbyType = h._HobbyType
                                  };

            return userHobbiesList;
        }

    }//CLASS QueryService

}//NAMENSPACE WebApi.Services
