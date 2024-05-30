using AppartmentServiceBE.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppartmentServiceBE.Models.DTO
{
    public class requestComplexDto
    {

        //public int Id { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int complexId { get; set; }

       // public virtual ICollection<ApartmentFlatsrequest> ComplexDetails { get; set; }

        public int noofFlats { get; set; }
    }

    //public class ApartmentFlatsrequest
    //{
    //    [Key]
    //    public int flatId { get; set; }
      
    //}
}
