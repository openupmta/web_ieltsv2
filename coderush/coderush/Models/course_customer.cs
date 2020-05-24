namespace coderush.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class course_customer
    {
        [Key]
        public int co_cu_id { get; set; }

        public int? customer_id { get; set; }

        public int? course_id { get; set; }

        public virtual course course { get; set; }

        public virtual customer customer { get; set; }
    }
}
