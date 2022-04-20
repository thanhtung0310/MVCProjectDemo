namespace DatabaseProvider
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("employee")]
    public partial class employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int emp_id { get; set; }

        [StringLength(50)]
        public string emp_name { get; set; }

        [StringLength(50)]
        public string emp_position { get; set; }

        [Column(TypeName = "date")]
        public DateTime? emp_dob { get; set; }

        [StringLength(50)]
        public string emp_contact_number { get; set; }
    }
}
