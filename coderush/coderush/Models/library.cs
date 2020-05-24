namespace coderush.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("librarys")]
    public partial class library
    {
        [Key]
        public int li_id { get; set; }

        [StringLength(150)]
        public string li_name { get; set; }

        [StringLength(150)]
        public string li_slug { get; set; }

        [StringLength(150)]
        public string li_image { get; set; }

        [Column(TypeName = "text")]
        public string li_summary { get; set; }

        [Column(TypeName = "text")]
        public string li_content { get; set; }

        public int? category_library_id { get; set; }

        public byte? li_status { get; set; }

        public DateTime? li_created_at { get; set; }

        public DateTime? li_updated_at { get; set; }

        public virtual category_librarys category_librarys { get; set; }
    }
}
