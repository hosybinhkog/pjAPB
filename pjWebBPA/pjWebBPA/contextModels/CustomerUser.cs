namespace pjWebBPA.contextModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerUser")]
    public partial class CustomerUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerUser()
        {
            Blogs = new HashSet<Blog>();
            Orders = new HashSet<Order>();
        }

        [Key]
        public int CustomerId { get; set; }

        [StringLength(255)]
        [Display(Name = "Dispay name")]
        [Required(ErrorMessage="Display name is required")]
        public string DisplayName { get; set; }

        public string DisplayImage { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email ph?i ðúng format")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public int? Code { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(50)]
        public string District { get; set; }

        public DateTime? CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public bool? isActive { get; set; }

        public bool? isVIP { get; set; }

        public int? AddressID { get; set; }

        public DateTime? LastLogin { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Password is required!")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        public virtual Address Address1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Blog> Blogs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
