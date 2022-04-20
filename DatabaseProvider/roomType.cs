namespace DatabaseProvider
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("roomType")]
    public partial class roomType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int room_type_id { get; set; }

        [StringLength(50)]
        public string room_type_name { get; set; }
    }
}
