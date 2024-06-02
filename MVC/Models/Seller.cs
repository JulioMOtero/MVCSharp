using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MVC.Models
{
    public class Seller
    {
        public  int Id { get; set; }

        [Required(ErrorMessage ="{0} required")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Enter a Valid Email")]
        [Required(ErrorMessage = "{0} required")]
        public string Email { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "{0} required")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(100.0, 50000.0,ErrorMessage ="{0} must be from {1} to {2}")]
        [Required(ErrorMessage = "{0} required")]
        public Double BaseSalary { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public Department Department { get; set; }

        public int DepartmentId { get; set; }


        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller() { }

        public Seller(int id, string name, string email, DateTime birthday, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            Birthday = birthday;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sales)
        {

            Sales.Add(sales);
        }

        public void RemoveSales(SalesRecord sales)
        {
            Sales.Remove(sales);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sales => sales.Date>= initial && sales.Date<= final).Sum(sales => sales.Amount);
        }
    }
}
