namespace DatabaseProvider
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("customer")]
    public partial class customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int customer_id { get; set; }

        [StringLength(50)]
        public string customer_first_name { get; set; }

        [StringLength(50)]
        public string customer_last_name { get; set; }

        [StringLength(100)]
        public string customer_address { get; set; }

        [StringLength(50)]
        public string customer_contact_number { get; set; }
    }
}
