using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TraceArt_Insurance.Models
{
    public class Users
    {
        public int PolicyNo { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Name should be in between 5 and 20")]
        public string Name { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression("^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "RegistrationNo is Required")]
        public string RegistrationNo { get; set; }

        [Required(ErrorMessage = "Please Select a Plan")]
        public string SelectPlan { get; set; }

        [Required(ErrorMessage = "Please Select Plan Tenure")]
        public string SelectPlanTenure { get; set; }
    }
}