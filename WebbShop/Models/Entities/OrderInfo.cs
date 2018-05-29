using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace WebbShop.Models.Entities
{
    public class OrderInfo
    {
        [Key]
        public int OrderID { get; set; }

        [Required(ErrorMessage = "Firstname is required!")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Lastname is required!")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Postcode is required!")]
        [RegularExpression("[0-9]", ErrorMessage = "Use numbers only please")]
        public string PostCode { get; set; }

        [Required(ErrorMessage = "City is required!")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string City { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [RegularExpression("[0-9]", ErrorMessage = "Use numbers only please")]
        public string Phonenumber { get; set; }
    }
}