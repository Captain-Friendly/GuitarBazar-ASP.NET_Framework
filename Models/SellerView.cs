using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace GuitarBazar.Models
{
    [MetadataType(typeof(SellerView))]
    public partial class Seller
    {
    }

    public class SellerView
    {
        [Display(Name = "Name"), Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email"), Required(ErrorMessage = "Required")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone"), Required(ErrorMessage = "Required")]
        public int Phone { get; set; }

    }
}