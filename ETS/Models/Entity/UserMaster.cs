using System;

namespace ETS.Models.Entity
{
    public class UserMaster
    {
        public Int64 UserId { get;}
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
    }
}