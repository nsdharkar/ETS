using System;

namespace ETS.Models.Entity
{
    public class UserMenu
    {
        public string FormName { get; set; }
        public string DisplayFormName { get; set; }
        public int FormId { get; set; }
        public int ParentId { get; set; }
    }
}