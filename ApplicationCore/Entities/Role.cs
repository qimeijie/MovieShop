using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class Role
    {
        public int Id { get; set; }
        [Column(TypeName = "NVARCHAR(20)")]
        public string Name { get; set; } = string.Empty;

        //navigation prop
        public IEnumerable<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
