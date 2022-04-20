namespace DatabaseProvider
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("reservation")]
    public partial class reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int resvervation_id { get; set; }

        public int? customer_id { get; set; }

        public DateTime? expected_check_in_date { get; set; }

        [StringLength(50)]
        public string expected_room_id { get; set; }

        public int? room_type_id { get; set; }

        [StringLength(50)]
        public string reservation_status { get; set; }
    }
}
