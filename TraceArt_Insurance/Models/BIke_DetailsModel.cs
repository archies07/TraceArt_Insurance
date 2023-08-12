using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TraceArt_Insurance.Models
{
    public class BIke_DetailsModel
    {
        public int PolicyNo { get; set; }
        [Required]
        public string BikeName { get; set; }
        [Required]
        public int RegistrationNo { get; set; }
    }
}