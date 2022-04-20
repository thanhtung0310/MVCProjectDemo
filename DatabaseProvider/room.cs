namespace DatabaseProvider
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("room")]
    public partial class room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int room_id { get; set; }

        public int? room_number { get; set; }

        public int? room_type_id { get; set; }

        public int? room_status_id { get; set; }
    }
}
