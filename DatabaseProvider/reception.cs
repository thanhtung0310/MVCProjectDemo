namespace DatabaseProvider
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("reception")]
    public partial class reception
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int reception_id { get; set; }

        [StringLength(50)]
        public string customer_id { get; set; }

        public int? reservation_id { get; set; }

        public int? room_id { get; set; }

        public DateTime? check_in_date { get; set; }

        public DateTime? expected_check_out_date { get; set; }

        public DateTime? check_out_date { get; set; }
    }
}
