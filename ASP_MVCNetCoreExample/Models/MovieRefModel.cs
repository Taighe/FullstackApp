using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_MVCNetCoreExample.Models
{
    [Table("Favourites")]
    public class MovieRefModel
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public UserModel User { get; set; }

        public int UserId { get; set; }
    }
}