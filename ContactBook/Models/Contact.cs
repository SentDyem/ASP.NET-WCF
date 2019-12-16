using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactBook.Models
{
    public class Contact
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Display(Name = "Электронная почта")]
        [EmailAddress (ErrorMessage = "Некорректный адрес электронной почты")]
        public string Email { get; set; }
    }
}