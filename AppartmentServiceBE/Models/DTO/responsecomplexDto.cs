using AppartmentServiceBE.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppartmentServiceBE.Models.DTO
{
    public class responsecomplexDto
    { 
        //public int Id { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int complexId { get; set; }

    //public virtual ICollection<ApartmentFlatsresponse> ComplexDetails { get; set; }

    public int noofFlats { get; set; }
}

//public class ApartmentFlatsresponse
//{
//    [Key]
//    public int flatId { get; set; }
//    public int flatNo { get; set; }

//    [ForeignKey("ComplexDetails")]
//    public int complexId { get; set; }

//    public string ownerPicture { get; set; }

//    public string ownerName { get; set; }
//    public int size { get; set; }
//    public string facing { get; set; }
//    public int contactNumbers { get; set; }
//    public string email { get; set; }
//    public int occupants { get; set; }
//    public bool selectedServices { get; set; }

//    public virtual complexDetails complexDetails { get; set; }
//}
    
        
}
