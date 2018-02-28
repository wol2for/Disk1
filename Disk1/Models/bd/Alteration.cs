namespace Disk1.Models.bd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Alteration")]
    public partial class Alteration
    {
        public int ID { get; set; }

        [DisplayName("ФИО")]
        [Required(ErrorMessage = "Введите ФИО")]
        [StringLength(250)]
        public string FIO { get; set; }

        [DisplayName("Отдала")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Gave { get; set; }

        [DisplayName("Забрала")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Got { get; set; }

        [DisplayName("Кто")]
        public int? Who { get; set; }

        [DisplayName("Заметка")]
        [StringLength(256)]
        public string Comment { get; set; }

        [StringLength(100)]
        public string WhoAdded { get; set; }
    }
}
