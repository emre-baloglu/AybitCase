using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace AybitCase.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column("firstName")]
        public string FirstName { get; set; }

        [Column("lastName")]
        public string LastName { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        [Column("CreateDate")]
        public DateTime CreateDate { get; set; }

        [Column("UpdateDate")]
        public DateTime? UpdateDate { get; set; }

        [Column("IsActive")]
        public bool IsActive { get; set; }


        [Column("Branches")]
        public virtual ICollection<Branch> Branches { get; set; }


        // Consturctor için koşul belirlenmesi gerekiyor. Şube id si buna göre dahil edilecek.
        // Müşteri başlangıçta bir şubeye sahip olarak mı oluşturulacak ?
        // Sahış/Kurum olarak sadece müşteri mi oluşturulacak ?
        public Customer(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = BCrypt.Net.BCrypt.HashPassword(password);
            CreateDate = DateTime.UtcNow;
            IsActive = true;
        }

        public Customer(int id, string firstName, string lastName, string email, string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = BCrypt.Net.BCrypt.HashPassword(password);
            Console.WriteLine("PASS TEST");
            Console.WriteLine(password);
            IsActive = true;
        }

        public Customer(string email, string password)
        {
            Email = email;
            Password = BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}