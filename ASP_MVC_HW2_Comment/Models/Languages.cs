using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_MVC_HW2_Comment.Models
{
    public static class Languages
    {
        public static Dictionary<string, string> List { get; set; } = new Dictionary<string, string>();
        static Languages()
        {
            List.Add("русский", "ru");
            List.Add("english", "en");
        }
    }
}