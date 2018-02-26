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

        [DisplayName("ФИО")]
        [Required]
        [StringLength(250)]
        public string FIO { get; set; }

        [DisplayName("Адрес")]
        [Required]
        [StringLength(250)]
        public string Address { get; set; }

        [DisplayName("Отадала")]
        public DateTime? Gave { get; set; }

        [DisplayName("Забрала")]
        public DateTime? Got { get; set; }

        [DisplayName("Заметка")]
        [StringLength(256)]
        public string Comment { get; set; }

        [StringLength(110)]
        public string WhoAdded { get; set; }

        [DisplayName("Кто")]
        public int? Who { get; set; }
    }
}
