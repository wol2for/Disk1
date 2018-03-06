using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Disk1.Models.bd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Other")]
    public partial class Other
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string string1 { get; set; }

        [StringLength(250)]
        public string string2 { get; set; }

        [StringLength(250)]
        public string string3 { get; set; }

        [StringLength(250)]
        public string string4 { get; set; }

        [StringLength(250)]
        public string string5 { get; set; }

        [StringLength(250)]
        public string string6 { get; set; }
    }
}