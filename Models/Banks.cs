using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyFinance.Models
{
    public class Banks
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="This field is required.")]
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Logo Image")]
        public string LogoImage { get; set; }
        [DisplayName("Created At")]
        public string CreatedAt { get; set; }
        [DisplayName("Updated At")]
        public string UpdatedAt { get; set; }
        public ICollection<LoanProduct> LoanProducts { get; set; }
    }
}