namespace coderush.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("introduce")]
    public partial class introduce
    {
        [Key]
        public int in_id { get; set; }

        [StringLength(150)]
        public string in_logo { get; set; }

        [StringLength(150)]
        public string in_address { get; set; }

        [StringLength(50)]
        public string in_phone { get; set; }

        [StringLength(150)]
        public string in_email { get; set; }

        [StringLength(150)]
        public string in_facebook { get; set; }

        [StringLength(250)]
        public string in_title { get; set; }

        [Column(TypeName = "text")]
        public string in_content { get; set; }

        public DateTime? in_created_at { get; set; }

        public DateTime? in_updated_at { get; set; }
    }
}
