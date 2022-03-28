using PictureProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PictureProject.Web.Models

{
    public class ViewImage
    {
        
            public  Image image { get; set; }
            public int id { get; set; }
            public string message { get; set; }
            public bool submittedCorrectPassword { get; set; }
            public bool alreadyHasAccess { get; set; }
        }
    }
