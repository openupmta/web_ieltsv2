using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace coderush.Areas.Admins.Models.EF.ViewModel
{
    public class CourseViewModel
    {
        public int co_id { get; set; }

        public string co_name { get; set; }

        public int? co_price { get; set; }

        public string co_image { get; set; }

        public string co_content { get; set; }

        public byte? co_type { get; set; }

        public byte? co_status { get; set; }

        public DateTime? co_created_at { get; set; }

        public DateTime? co_updated_at { get; set; }

        public int? teacher_id { get; set; }

        public string teacher_name { get; set; }
    }

}