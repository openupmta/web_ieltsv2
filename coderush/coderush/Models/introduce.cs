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
        [Display(Name = "Logo")]
        public string in_logo { get; set; }

        [StringLength(150)]
        [Display(Name = "Địa chỉ")]
        public string in_address { get; set; }

        [StringLength(50)]
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string in_phone { get; set; }

        [StringLength(150)]
        [Display(Name = "Email")]
        public string in_email { get; set; }

        [StringLength(150)]
        [Display(Name = "Facebook")]
        [Required(ErrorMessage = "Facebook không được để trống")]
        public string in_facebook { get; set; }

        [StringLength(250)]
        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        public string in_title { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Nội dung")]
        [Required(ErrorMessage = "Nội dung không được để trống")]
        public string in_content { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? in_created_at { get; set; }
        [Display(Name = "Cập nhập")]
        public DateTime? in_updated_at { get; set; }
    }
}
