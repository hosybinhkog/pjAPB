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
        public int id { get; set; }

        public string Description { get; set; }

        public string Listdesc { get; set; }

        public int CategoryCourseId { get; set; }


    }
}