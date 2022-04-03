namespace pjWebBPA.contextModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StaticPage")]
    public partial class StaticPage
    {
        [Key]
        [Column("StaticPage")]
        public int StaticPage1 { get; set; }

        [StringLength(255)]
        public string StaticPageName { get; set; }

        public string StaticPageDescription { get; set; }

        public bool? Pulished { get; set; }

        public string Image { get; set; }

        [StringLength(250)]
        public string MetaDesc { get; set; }

        [StringLength(250)]
        public string MetaKey { get; set; }

        [StringLength(255)]
        public string Alias { get; set; }

        public int? Ordering { get; set; }

        public DateTime? CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }
    }
}
