
namespace WebApi.Dtos
{
    public class UserDto
    {
        public int IdUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }

    }//CLASS UserDto

}//NAMESPACE WebApi.Dtos