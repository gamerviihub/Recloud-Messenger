using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.Server.DataBase.Models
{
    public class User
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int StatusId { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Patronymic { get; set; }
        public string? DeviceName { get; set; }
        public string? LastAddress { get; set; }

        public string? Phone { get; set; }
        public string? City { get; set; }
        public DateTime? BirthDay { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        [NotMapped]
        public bool IsRegistered { get; set; }
        [NotMapped]
        public bool IsRegisteredEnded { get; set; }
    }
}
