namespace MammasTiffin.Entities.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu.Items")]
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            OrderedItems = new HashSet<OrderedItem>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string ItemName { get; set; }

        [Required]
        [StringLength(1)]
        public string IsVeg { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Required]
        public string Ingredients { get; set; }

        public DateTime DateAndTime { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersionStamp { get; set; }

        public int ImageId { get; set; }

        public virtual ItemImage ItemImage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderedItem> OrderedItems { get; set; }
    }
}
