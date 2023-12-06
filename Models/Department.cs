using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TrainingLZS.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Department Name")]
        public string Name { get; set; }
    }
}
