namespace Disk1.Models.bd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Online")]
    public partial class Online
    {
        public int ID { get; set; }

        [DisplayName("���")]
        [StringLength(250)]
        public string FIO { get; set; }

        [DisplayName("�������")]
        public DateTime? Got { get; set; }

        [DisplayName("�������")]
        [StringLength(256)]
        public string Comment { get; set; }

        [StringLength(100)]
        public string WhoAdded { get; set; }
    }
}
