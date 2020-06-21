using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace coderush.Areas.Admins.Models.EF.ViewModel
{
    public class TeacherViewModel
    {
        public int te_id { get; set; }

        public string te_name { get; set; }

        public string te_content { get; set; }

        public string te_image { get; set; }

        public byte? te_status { get; set; }

        public DateTime? te_created_at { get; set; }

        public DateTime? te_updated_at { get; set; }

        public int? position_id { get; set; }

        public int? staff_id { get; set; }

        public string position_name { get; set; }

        public string staff_name { get; set; }
    }
}