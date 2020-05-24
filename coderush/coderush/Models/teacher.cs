namespace coderush.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class teacher
    {
        [Key]
        public int te_id { get; set; }

        [StringLength(150)]
        public string te_name { get; set; }

        public int? position_id { get; set; }

        [Column(TypeName = "text")]
        public string te_content { get; set; }

        [StringLength(150)]
        public string te_image { get; set; }

        public byte? te_status { get; set; }

        public DateTime? te_created_at { get; set; }

        public DateTime? te_updated_at { get; set; }

        public int? staff_id { get; set; }

        public virtual position position { get; set; }

        public virtual staff staff { get; set; }
    }
}
