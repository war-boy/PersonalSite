using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalSiteMVC.Models
{
    
    public class ProjectViewModel
    {
        

        [Required]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [UIHint("MultilineText")]
        public string Description { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "Demo Link")]
        public string URL { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "GitHub Link")]
        public string GitHub { get; set; }

        [Display(Name = "GitHub Link")]
        public string ProjectImage { get; set; }

        public string Category { get; set; }

        public ProjectViewModel(string projectName, string description, string url, string gitHub, string projectImage, string category)
        {
            ProjectName = projectName;
            Description = description;
            URL = url;
            GitHub = gitHub;
            ProjectImage = projectImage;
            Category = category;
        }
    }
}