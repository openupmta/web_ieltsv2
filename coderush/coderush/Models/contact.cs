namespace coderush.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class contact
    {
        [Key]
        public int co_id { get; set; }

        [StringLength(150)]
        public string co_name { get; set; }

        [StringLength(150)]
        public string co_icon { get; set; }

        [StringLength(150)]
        public string co_link { get; set; }

        public byte? co_status { get; set; }

        public DateTime? co_created_at { get; set; }

        public DateTime? co_updated_at { get; set; }
    }
}
