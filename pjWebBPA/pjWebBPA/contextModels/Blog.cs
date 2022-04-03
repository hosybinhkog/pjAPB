namespace pjWebBPA.contextModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Blog")]
    public partial class Blog
    {
        public int BlogId { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        public string ContentBlog { get; set; }

        [StringLength(250)]
        public string ShortContent { get; set; }

        public string ThumBlog { get; set; }

        [StringLength(250)]
        public string Author { get; set; }

        public int AccountId { get; set; }

        [StringLength(255)]
        public string Tag { get; set; }

        public int CategoryBlogId { get; set; }

        public bool? isHot { get; set; }

        public bool? isNewfeed { get; set; }

        public string imageAuthor { get; set; }

        public DateTime? CreateAt { get; set; }

        public List<CategoryBlog> listCategories = new List<CategoryBlog>();

        public virtual CategoryBlog CategoryBlog { get; set; }

        public virtual CustomerUser CustomerUser { get; set; }
    }
}
