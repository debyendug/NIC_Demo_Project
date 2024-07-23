using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NIC_Demo_Project.Models
{
    [Table("NIC_EmpMain")]
    public class NIC_EmpMain
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]

        public int EMId { get; set; }
        public string? Name { get; set; }
        public string? Phno { get; set; }
        public int? Pin { get; set; }
        public int? Class { get; set; }
        public decimal? Markes { get; set; }
        public string? Activate { get; set; }
    }
}
