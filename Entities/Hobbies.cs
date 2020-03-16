using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApi.Entities
{
    [Table("Hobbies")]
    public class Hobby
    {
        //ATTRIBUTES
        [Key]
        [Column(Order = 1)]
        public int IdHobby { get; set; }

        [Required]
        [StringLength(50)]
        public string HobbyName { get; set; }


        public HobbyType _HobbyType { get; set; }

    }//CLASS Hobby
    public enum HobbyType
    {
        Outdoor = 1,

        Indoor = 0

    }//ENUM HobbyType

}//NAMESPACE WebApi.Entities
