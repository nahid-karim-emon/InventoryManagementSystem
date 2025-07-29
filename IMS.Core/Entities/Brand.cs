using IMS.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Entities
{
    public class Brand : ISoftDeletable, IEntityWithName
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public bool isDelete { get; set; } = false;
    }
}
