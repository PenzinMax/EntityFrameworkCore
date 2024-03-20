using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Models
{
    public class Bank
    {
        [Key] public int Id { get; set; }
        public required string Name { get; set; }
        public virtual ICollection<FileXML> FileXMLs { get; set; } = new List<FileXML>();
        
    }
}
