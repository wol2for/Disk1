namespace Disk1.Models.bd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Zav80
    {
        public int ID { get; set; }

        [DisplayName("���")]
        [Required(ErrorMessage = "������� ���")]
        [StringLength(250)]
        public string FIO { get; set; }

        [DisplayName("������")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Gave { get; set; }

        [DisplayName("�������")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Got { get; set; }

        [DisplayName("���")]
        public int? Who { get; set; }

        [DisplayName("�������")]
        [StringLength(256)]
        public string Comment { get; set; }

        [StringLength(100)]
        public string WhoAdded { get; set; }
    }
}
