﻿namespace AppartmentServiceBE.Models.DTO
{
    public class UserDetailsdto
    {
        public int userId { get; set; }


        public string userName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool isAdmin { get; set; }
    }
}
