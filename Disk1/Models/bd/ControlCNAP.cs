namespace Disk1.Models.bd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ControlCNAP")]
    public partial class ControlCNAP
    {
        public int ID { get; set; }

        public int IDCNAP { get; set; }

        [DisplayName("���")]
        [Required]
        [StringLength(250)]
        public string FIO { get; set; }

        [DisplayName("�����")]
        [Required]
        [StringLength(250)]
        public string Address { get; set; }

        [DisplayName("�������")]
        public DateTime? Gave { get; set; }

        [DisplayName("�������")]
        public DateTime? Got { get; set; }

        [DisplayName("�������")]
        [StringLength(256)]
        public string Comment { get; set; }

        [StringLength(110)]
        public string WhoAdded { get; set; }

        [DisplayName("���")]
        public int? Who { get; set; }
    }
}
