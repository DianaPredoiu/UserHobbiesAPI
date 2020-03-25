using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    [Table("Users")]
    public class User
    {

        //ATTRIBUTES
        [Key]
        [Column(Order = 0)]
        public int IdUser { get; set; }

        [Required]
        [StringLength(25)]
        public string Username { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsActive { get; set; }

    }//CLASS User

}//NAMESPACE WebApi.Entities


