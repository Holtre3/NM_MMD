using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NM_MMD.Models
{
    public class Dispensary
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Dispensary Name is a Required Field.")]
        [StringLength(200, MinimumLength = 4, ErrorMessage = "Dispensary Name Length Between 4 to 200 character")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Dispensary Address is a Required Field.")]
        [StringLength(200, MinimumLength = 4, ErrorMessage = "Dispensary Address Length Between 4 to 200 character")]
        public string Address { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "City Name is Required Field.")]
        [StringLength(200, MinimumLength = 4, ErrorMessage = "City Name Length Between 4 to 200 character")]
        public string City { get; set; }
        [StringLength(5)]
        public string State { get; set; }
        [StringLength(20)]
        public string Zip { get; set; }
        [Phone]
        public string Phone { get; set; }
        public string URL { get; set; }
        public string ImgPath { get; set; }
    }
}