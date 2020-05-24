namespace coderush.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class blog
    {
        [Key]
        public int bl_id { get; set; }

        [StringLength(50)]
        public string bl_name { get; set; }

        [StringLength(50)]
        public string bl_slug { get; set; }

        [StringLength(150)]
        public string bl_image { get; set; }

        [Column(TypeName = "text")]
        public string bl_summary { get; set; }

        [Column(TypeName = "text")]
        public string bl_content { get; set; }

        public byte? bl_status { get; set; }

        public DateTime? bl_created_at { get; set; }

        public DateTime? bl_updated_at { get; set; }
    }
}
