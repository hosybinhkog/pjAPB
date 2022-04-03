namespace pjWebBPA.contextModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAccount")]
    public partial class UserAccount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserAccount()
        {
            CategoryBlogs = new HashSet<CategoryBlog>();
        }

        [Key]
        public int userId { get; set; }

        [Required]
        [StringLength(250)]
        public string email { get; set; }

        [Required]
        [StringLength(250)]
        public string password { get; set; }

        [Required]
        [StringLength(255)]
        public string displayName { get; set; }

        [StringLength(1000)]
        public string avatar { get; set; }

        public int? phone { get; set; }

        public int? age { get; set; }

        public DateTime? createAt { get; set; }

        public DateTime? updateAt { get; set; }

        public int? RoleId { get; set; }

        public DateTime? LastLogin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CategoryBlog> CategoryBlogs { get; set; }

        public virtual Role Role { get; set; }
    }
}
