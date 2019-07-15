using System;

namespace ModernStore.Infra.Data.Models
{
    public class CustomerRecord
    {
        public Guid Id { get; set; }
        public string Name_FirstName { get; set; }
        public string Name_LastName { get; set; }
        public string Email_Address { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Document_Number { get; set; }
        public string User_Login { get; set; }
        public string User_Active { get; set; }
        public string User_UserPassword_Password { get; set; }
        public string User_UserPassword_Salt { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
