using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinance.Models
{
    public class LoanProduct
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Loan Type")]
        public int TypeId { get; set; }
        [DisplayName("Bank")]
        public int BankId { get; set; }
        [DisplayName("Interest Rate")]
        [Required(ErrorMessage = "This field is required.")]
        public string InterestRate { get; set; }
        [DisplayName("Summary")]
        public string Summary { get; set; }
        [DisplayName("Financial Min")]
        [Required(ErrorMessage = "This field is required.")]
        public string FinancialMin { get; set; }
        [DisplayName("Financial Max")]
        [Required(ErrorMessage = "This field is required.")]
        public string FinancialMax { get; set; }
        [DisplayName("Tenure Min")]
        [Required(ErrorMessage = "This field is required.")]
        public string TenureMin { get; set; }
        [DisplayName("Tenure Max")]
        [Required(ErrorMessage = "This field is required.")]
        public string TenureMax { get; set; }
        [DisplayName("Age Min")]
        [Required(ErrorMessage = "This field is required.")]
        public string AgeMin { get; set; }
        [DisplayName("Age Max")]
        [Required(ErrorMessage = "This field is required.")]
        public string AgeMax { get; set; }
        [DisplayName("Created At")]
        public string CreatedAt { get; set; }
        [DisplayName("Updated At")]
        public string UpdatedAt { get; set; }
        [ForeignKey("BankId")]
        public Banks Banks { get; set; }
        [ForeignKey("TypeId")]
        public LoanTypes LoanTypes { get; set; }
    }
}
