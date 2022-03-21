using System;
using System.ComponentModel.DataAnnotations;

namespace GuitarBazar.Models
{
    [MetadataType(typeof(GuitarView))]
    public partial class Guitar
    {
        public Guitar()
        {
            AddDate=DateTime.Now;
        }
    }
    public class GuitarView 
    {
        [Display(Name = "Maker"), Required(ErrorMessage = "Required")]
        public string Maker { get; set; }

        [Display(Name = "Model"), Required(ErrorMessage = "Required")]
        public string Model { get; set; }

        [Display(Name = "Description"), Required(ErrorMessage = "Required")]
        public string Description { get; set; }

        [Display(Name = "Year"), Required(ErrorMessage = "Required")]
        public string Year { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "AddDate"), Required(ErrorMessage = "Required")]
        public string AddDate { get; set; }

        [Display(Name = "ConditionId"), Required(ErrorMessage = "Required")]
        public string ConditionId { get; set; }

        [Display(Name = "GuitarTypeId"), Required(ErrorMessage = "Required")]
        public string GuitarTypeId { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "ImageURL"), Required(ErrorMessage = "Required")]
        public string ImageURL { get; set; }
    }
}