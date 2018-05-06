namespace MammasTiffin.Entities.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order.OrderDetails")]
    public partial class OrderDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderDetail()
        {
            OrderedItems = new HashSet<OrderedItem>();
        }

        public int Id { get; set; }

        public int CustomerId { get; set; }

        [Required]
        [StringLength(1)]
        public string IsActive { get; set; }

        [Required]
        [StringLength(1)]
        public string IsDelivered { get; set; }

        public DateTime DateAndTime { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersionStamp { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderedItem> OrderedItems { get; set; }
    }
}
