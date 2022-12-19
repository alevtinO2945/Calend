using System.ComponentModel.DataAnnotations;

namespace Calend.Models
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
