using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AybitCase.Models
{
    [Table("Enrollment")]
    public class Enrollment
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column("CreateDate")]
        public DateTime CreateDate { get; set; }

        [Column("UpdateDate")]
        public DateTime? UpdateDate { get; set; }


        [Column("Customers")]
        public virtual ICollection<Customer> Customers { get; set; }

    }
}
