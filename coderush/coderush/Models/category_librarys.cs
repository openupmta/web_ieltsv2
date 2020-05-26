namespace coderush.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class category_librarys
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public category_librarys()
        {
            librarys = new HashSet<library>();
        }

        [Key]

        public int ca_id { get; set; }

        [StringLength(150)]
        [Display(Name = "Tên thể loại")]
        [Required(ErrorMessage = "Tên thể loại không được để trống")]
        public string ca_name { get; set; }

        [StringLength(150)]
        public string ca_slug { get; set; }

        [StringLength(150)]
        [Display(Name = "Hình ảnh")]
        public string ca_icon { get; set; }
        [Display(Name = "Trạng thái")]
        public byte? ca_status { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? ca_created_at { get; set; }
        [Display(Name = "Ngày cập nhập")]
        public DateTime? ca_updated_at { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<library> librarys { get; set; }
    }
}
