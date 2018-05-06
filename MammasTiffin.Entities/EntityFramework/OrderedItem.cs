namespace MammasTiffin.Entities.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order.OrderedItems")]
    public partial class OrderedItem
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ItemId { get; set; }

        public int Quantity { get; set; }

        public DateTime DateAndTime { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersionStamp { get; set; }

        public virtual Item Item { get; set; }

        public virtual OrderDetail OrderDetail { get; set; }
    }
}
