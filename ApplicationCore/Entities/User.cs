using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Column(TypeName = "DATETIME2")]
        public DateTime? DateOfBirth { get; set; }
        [Column(TypeName = "NVARCHAR(256)")]
        public string Email { get; set; } = string.Empty;
        [Column(TypeName = "NVARCHAR(128)")]
        public string FirstName { get; set; } = string.Empty;
        [Column(TypeName = "NVARCHAR(1024)")]
        public string HashedPassword { get; set; } = string.Empty;
        [Column(TypeName = "BIT")]
        public bool? isLocked { get; set; }
        [Column(TypeName = "NVARCHAR(128)")]
        public string LastName { get; set; } = string.Empty;
        [Column(TypeName = "NVARCHAR(16)")]
        public string? PhoneNumber { get; set; }
        [Column(TypeName = "NVARCHAR(MAX)")]
        public string? ProfilePictureUrl { get; set; }
        [Column(TypeName = "NVARCHAR(1024)")]
        public string Salt { get; set; } = string.Empty;

        //navigation prop
        public IEnumerable<Favorite> Favorites { get; set; } = new List<Favorite>();
        public IEnumerable<Review> Reviews { get; set; } = new List<Review>();
        public IEnumerable<Purchase> Purchases { get; set; } = new List<Purchase>();
        public IEnumerable<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
