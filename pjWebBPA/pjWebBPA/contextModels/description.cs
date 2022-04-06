using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pjWebBPA.contextModels
{
    [Table("description")]
    public class description
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public string ListDesc { get; set; }

        public int CateCourseId { get; set; }

        public List<CategoryCourse> listCategoryCourse = new List<CategoryCourse>();
    }
}