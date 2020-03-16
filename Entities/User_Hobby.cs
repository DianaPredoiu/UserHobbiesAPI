using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApi.Entities
{
    [Table("User_Hobby")]
    public class User_Hobby
    {
        //ATTRIBUTES
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        [Column(Order = 0)]
        public int UserId { get; set; }

        [ForeignKey("Hobby")]
        [Column(Order = 1)]
        public int HobbyId { get; set; }

    }//CLASS User_Hobby

}//NAMESPACE WebApi.Entities
