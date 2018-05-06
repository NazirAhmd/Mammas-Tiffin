namespace MammasTiffin.Entities.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu.ItemImages")]
    public partial class ItemImage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItemImage()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string ImageName { get; set; }

        public int ImageSize { get; set; }

        [Required]
        public byte[] ImageData { get; set; }

        public DateTime DateAndTime { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersionStamp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item> Items { get; set; }
    }
}
