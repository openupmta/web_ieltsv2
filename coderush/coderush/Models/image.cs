namespace coderush.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("image")]
    public partial class image
    {
        [Key]
        public int im_id { get; set; }

        [StringLength(150)]
        public string im_image { get; set; }

        [StringLength(150)]
        public string im_title { get; set; }

        public byte? im_location { get; set; }

        public byte? im_status { get; set; }

        public DateTime? im_created_at { get; set; }

        public DateTime? im_updated_at { get; set; }
    }
}
