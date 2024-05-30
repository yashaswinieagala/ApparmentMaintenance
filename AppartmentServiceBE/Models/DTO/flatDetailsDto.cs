namespace AppartmentServiceBE.Models.DTO
{
    public class flatDetailsDto
    {
        public int flatId { get; set; }

        public int flatNo { get; set; }
        public int complexId { get; set; }
      

        public string ownerName { get; set; }
        public int size { get; set; }
        public string facing { get; set; }
        public int contactNumbers { get; set; }
        public string email { get; set; }
        public int occupants { get; set; }
        public bool selectedServices { get; set; }
    }
}
