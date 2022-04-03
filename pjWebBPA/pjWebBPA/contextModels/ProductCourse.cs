namespace pjWebBPA.contextModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductCourse")]
    public partial class ProductCourse
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(255)]
        public string ProductName { get; set; }

        [Required]
        public string ProductDescription { get; set; }

        [Required]
        [StringLength(255)]
        public string ProductShortDescription { get; set; }

        public int CategoryCourseId { get; set; }

        public int? Price { get; set; }

        public bool? isFree { get; set; }

        public string ProductImage { get; set; }

        public string UrlVideoYoutube { get; set; }

        public bool? BestSeller { get; set; }

        public bool? isHot { get; set; }

        public bool? isNew { get; set; }

        [StringLength(255)]
        public string Alias { get; set; }

        [StringLength(255)]
        public string MetaDesc { get; set; }

        [StringLength(255)]
        public string MetaKey { get; set; }

        public string Tags { get; set; }

        [StringLength(255)]
        public string FakeTitle { get; set; }

        public int? CountLession { get; set; }

        public int? CountWatch { get; set; }

        public int? CountBuy { get; set; }

        public bool? ProductGim { get; set; }

        public DateTime? CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public int? AuthorId { get; set; }

        public int? TeacherId { get; set; }

        public List<CategoryCourse> listCategoriesCourse = new List<CategoryCourse>();

        public List<Teacher> listTeacher = new List<Teacher>();

        public virtual Author Author { get; set; }

        public virtual CategoryCourse CategoryCourse { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
