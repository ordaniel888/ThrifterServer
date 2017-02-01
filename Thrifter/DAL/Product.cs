namespace Thrifter.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            ProductOwnerships = new HashSet<ProductOwnership>();
        }

        public int Id { get; set; }

        [Required]
        public string Tags { get; set; }

        [Required]
        public string Name { get; set; }

        public double AvgOriginalPrice { get; set; }

        public double AvgOfferedPrice { get; set; }

        public string ImageLink { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOwnership> ProductOwnerships { get; set; }
    }
}
