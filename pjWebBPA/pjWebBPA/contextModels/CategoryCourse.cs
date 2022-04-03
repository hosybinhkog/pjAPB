namespace pjWebBPA.contextModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CategoryCourse")]
    public partial class CategoryCourse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CategoryCourse()
        {
            ProductCourses = new HashSet<ProductCourse>();
        }

        public int CategoryCourseId { get; set; }

        [Required]
        [StringLength(255)]
        public string CategoryCourseName { get; set; }

        public int? ParentId { get; set; }

        public string TitleCategoryCourse { get; set; }

        public int? Levels { get; set; }

        public string CategoryImage { get; set; }

        public int? Ordering { get; set; }

        public bool? Published { get; set; }

        [StringLength(250)]
        public string Alias { get; set; }

        [StringLength(250)]
        public string MetaDesc { get; set; }

        public string UrlCourse { get; set; }

        [StringLength(250)]
        public string Cover { get; set; }

        public string SchemaMarkup { get; set; }

        [StringLength(255)]
        public string MetaKey { get; set; }

        public int? LevelClass { get; set; }
        public int? Price { get; set; }

        public bool? isFree { get; set; }

        public bool? isHot { get; set; }

        public bool? isNew { get; set; }

        public bool? isFondend { get; set; }

        public int? TeacherId { get; set; }

        public List<Teacher>  listTeacher  = new List<Teacher>();

        public DateTime? CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductCourse> ProductCourses { get; set; }
    }
}
