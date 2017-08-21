using System;
using System.ComponentModel.DataAnnotations;

namespace ETS.Models.Entity
{
    public class UserMaster
    {
        public Int64 UserId { get;}
        public string FullName { get; set; }
        [Required(ErrorMessage = "User Name is Required.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is Required.")]
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public string EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
    }
}