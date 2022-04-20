namespace DatabaseProvider
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("paymentType")]
    public partial class paymentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int payment_type_id { get; set; }

        [StringLength(50)]
        public string payment_type_name { get; set; }
    }
}
