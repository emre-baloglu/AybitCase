using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AybitCase.Models
{
    [Table("Branch")]
    public class Branch
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column("BranchName")]
        public string BranchName { get; set; }

        [Column("CityName")]
        public string CityName { get; set; }

        [Column("DistrictName")]
        public string DistrictName { get; set; }

        [Column("BranchPhone")]
        public string BranchPhone { get; set; }



        //[Column("CustomerId")]
        //public int CostumerId { get; set; }

        //[Column("Customer")]
        //public Customer Customer { get; set; }
    }



    //public class BranchEntityConfiguration : IEntityTypeConfiguration<Branch>
    //{
    //    public void Configure(EntityTypeBuilder<Branch> builder)
    //    {
    //        builder.Property(p => p.BranchName).HasColumnType("nvarchar(30)");
    //        builder.Property(p => p.CityName).HasColumnType("nvarchar(30)");
    //        builder.Property(p => p.DistrictName).HasColumnType("nvarchar(30)");
    //        builder.Property(p => p.BranchPhone).HasColumnType("nvarchar(30)");

    //        builder.HasOne(x => x.Customer)
    //               .WithMany(x => x.Branches)
    //               .HasForeignKey(x => x.CostumerId);
    //    }
    //}
}
