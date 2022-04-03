namespace pjWebBPA.contextModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetail
    {
        [Key]
        public int OrderDetailsId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int? OrderNumber { get; set; }

        public int? Quanlity { get; set; }

        public int? Discount { get; set; }

        public int? SubTotal { get; set; }

        public int? Total { get; set; }

        public DateTime? CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public virtual Order Order { get; set; }
    }
}
