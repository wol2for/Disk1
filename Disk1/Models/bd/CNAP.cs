namespace Disk1.Models.bd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CNAP")]
    public partial class CNAP
    {
        public int ID { get; set; }

        [DisplayName("ФИО")]
        [Required(ErrorMessage = "Введите ФИО")]
        [StringLength(250)]
        public string FIO { get; set; }

        [DisplayName("Адрес")]
        [Required(ErrorMessage = "Введите адрес")]
        [StringLength(250)]
        public string Address { get; set; }

        [DisplayName("Отадала")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Gave { get; set; }

        [DisplayName("Забрала")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Got { get; set; }

        [DisplayName("Заметка")]
        [StringLength(256)]
        public string Comment { get; set; }

        [StringLength(100)]
        public string WhoAdded { get; set; }

        [DisplayName("Кто")]
        public int? Who { get; set; }

        public virtual Who Who1 { get; set; }
    }
}
