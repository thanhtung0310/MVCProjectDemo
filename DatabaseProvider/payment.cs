namespace DatabaseProvider
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("payment")]
    public partial class payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int payment_id { get; set; }

        public int? payment_type_id { get; set; }

        public int? reception_id { get; set; }

        public decimal? payment_amount { get; set; }

        public DateTime? payment_date { get; set; }
    }
}
