namespace Thrifter.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductOwnership
    {
        public bool IsSelling { get; set; }

        [Key]
        [Column(Order = 0)]
        public DateTime BuyDate { get; set; }

        public double? OfferedPrice { get; set; }

        
        public string SellReason { get; set; }

        public int State { get; set; }

        public DateTime NotificationDate { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OwnerId { get; set; }

        public virtual Owner Owner { get; set; }

        public virtual Product Product { get; set; }
    }
}
