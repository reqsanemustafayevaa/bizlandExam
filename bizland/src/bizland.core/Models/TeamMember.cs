using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bizland.core.Models
{
    public class TeamMember:BaseEntity
    {
        [Required]
        [StringLength(60)]
        public string FullName { get; set; }
        [Required]
        [StringLength(60)]
        public string Profession { get; set; }
       
        [StringLength(60)]
        public string InstaUrl { get; set; }
        [StringLength(60)]
        public string FbUrl { get; set; }
        [StringLength(60)]
        public string LinkEdinUrl { get; set; }
        [StringLength(60)]
        public string TwitterUrl { get; set;}
        [StringLength(100)]
        public string? ImageUrl {  get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
