using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Giftos.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[]? ProfilePicture { get; set; }


        public string Country { get; set; } = "Jordan";
        public string City { get; set; } = "Amman";

        public string? Street { get; set; }
        public string? Building { get; set; }

    }
}
