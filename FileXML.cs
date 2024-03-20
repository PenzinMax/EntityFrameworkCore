using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Models
{
    public class FileXML
    {
        [Key] public int Id { get; set; }
        public required string File { get; set; }
        public required DateTime CreatedDate { get; set; }
        public DateTime ModDate { get; set; }
        public required int IdBank { get; set; }
        public virtual required Bank Banks { get; set; }
    }
}
