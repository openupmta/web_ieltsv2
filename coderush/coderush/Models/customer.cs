namespace coderush.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public customer()
        {
            course_customer = new HashSet<course_customer>();
        }

        [Key]
        public int cu_id { get; set; }

        [StringLength(50)]
        public string cu_mobile { get; set; }

        [StringLength(50)]
        public string cu_email { get; set; }

        [StringLength(50)]
        public string cu_fullname { get; set; }

        [StringLength(10)]
        public string cu_address { get; set; }

        public byte? cu_status { get; set; }

        [Column(TypeName = "text")]
        public string cu_note { get; set; }

        public DateTime? cu_created_at { get; set; }

        public DateTime? cu_updated_at { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<course_customer> course_customer { get; set; }
    }
}
