using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaroFiber.Core.Models.ViewModels
{
    public class MemberLoginViewModel
    {
        [Required, Display(Name = "Användarnamn")]
        public string Username { get; set; }

        [Required, Display(Name = "Lösenord"), DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Kom ihåg mig")]
        public bool RememberMe { get; set; }
    }
}
