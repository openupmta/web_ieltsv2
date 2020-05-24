namespace coderush.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public staff()
        {
            courses = new HashSet<course>();
            teachers = new HashSet<teacher>();
        }

        [Key]
        [Display(Name ="Mã nhân sự")]
        public int sta_id { get; set; }

        [StringLength(150)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email không được để trống")]
        public string sta_email { get; set; }

        [StringLength(150)]
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Họ và tên không được để trống")]
        public string sta_username{ get; set; }
        [StringLength(150)]
        [Display(Name = "Họ và tên ")]
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        public string sta_fullname { get; set; }

        [StringLength(150)]
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string sta_password { get; set; }
        [Display]
        
        public int? group_role_id { get; set; }

        [StringLength(150)]
        [Display(Name = "Ảnh đại diện")]
        public string sta_image { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? sta_created_at { get; set; }
        [Display(Name = "Ngày cập nhật")]
        public DateTime? sta_update_at { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<course> courses { get; set; }

        public virtual group_role group_role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<teacher> teachers { get; set; }
    }
}
