namespace Thrifter.DAL
{
    using Newtonsoft.Json;
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

        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public string Tags { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty("Price")]
        public double AvgOriginalPrice { get; set; }

        [JsonProperty]
        public double AvgOfferedPrice { get; set; }

        [JsonProperty]
        public string ImageLink { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOwnership> ProductOwnerships { get; set; }
    }
}
