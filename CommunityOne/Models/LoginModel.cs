using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CommunityOne.Models
{
    public class LoginModel
    {

        [Required]
        [Display(Name = "Username")]
        [DataType(DataType.Text)]
        public string UsrName { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string UsrPass { get; set; }
        public bool UsrIsLog { get; set; }
        public bool UsrStatus { get; set; }
        public string UsrFname { get; set; }
        public string UsrLName { get; set; }
        public string UsrMName { get; set; }

    }
}