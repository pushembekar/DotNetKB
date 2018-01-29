using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie.Models
{
    public class FileUpload
    {
        // Tile of the movie
        [Required]
        [Display(Name ="Title")]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        // Upload schedule for public
        [Required]
        [Display(Name = "Public Schedule")]
        public IFormFile UploadPublicSchedule { get; set; }

        // Upload schedule for private
        [Required]
        [Display(Name = "Private Schedule")]
        public IFormFile UploadPrivateSchedule { get; set; }
    }
}
