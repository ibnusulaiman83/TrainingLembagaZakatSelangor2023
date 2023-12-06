using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TrainingLZS.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Nama Penuh")]
        public string Name { get; set; }
        [DisplayName("Emel")]
        public string Email { get; set; }
        [DisplayName("Alamat Surat Menyurat")]
        public string Address { get; set; }
        [DisplayName("No. Telefon")]
        public string PhoneNo { get; set; }

        [ForeignKey("Departments")]
        [DisplayName("Nama Jabatan")]
        public int DepartmentID { get; set; }
        public virtual Department Departments { get; set; }
    }
}
