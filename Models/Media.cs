using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ynov.TU.Mikado.Models
{
    [Table("Media")]
    public class Media
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MediaCategory Category{ get; set; }
    }

    public enum MediaCategory
    {
        Book,
        Movie,
        Music
    }
}
