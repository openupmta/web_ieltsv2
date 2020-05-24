namespace coderush.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("course")]
    public partial class course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public course()
        {
            course_customer = new HashSet<course_customer>();
        }

        [Key]
        public int co_id { get; set; }

        [StringLength(150)]
        public string co_name { get; set; }

        [StringLength(150)]
        public string co_slug { get; set; }

        [StringLength(150)]
        public string co_image { get; set; }

        [Column(TypeName = "text")]
        public string co_content { get; set; }

        public byte? co_type { get; set; }

        public byte? co_status { get; set; }

        public DateTime? co_created_at { get; set; }

        public DateTime? co_updated_at { get; set; }

        public int? staff_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<course_customer> course_customer { get; set; }

        public virtual staff staff { get; set; }
    }
}
