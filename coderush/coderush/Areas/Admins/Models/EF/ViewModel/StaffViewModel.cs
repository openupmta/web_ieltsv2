using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace coderush.Areas.Admins.Models.EF.ViewModel
{
    public class StaffViewModel
    {
        public int sta_id { get; set; }
        public string sta_email { get; set; }
        public string sta_fullname { get; set; }
        public string sta_username { get; set; }
        public string sta_password { get; set; }

        public int? group_role_id { get; set; }
        public string group_role_name { get; set; }
        public string sta_image { get; set; }

        public DateTime? sta_created_at { get; set; }

        public DateTime? sta_update_at { get; set; }

    }
}