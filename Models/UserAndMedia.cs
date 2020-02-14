using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ynov.TU.Mikado.Models
{
    [Table("Favourite")]
    public class Favourite
    {
        public int UserId { get; set; }
        public int MediaId { get; set; }
    }

    [Table("Borrow")]
    public class Borrow
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Media")]
        public int MediaId { get; set; }
        public DateTime BorrowDate { get; set; }
    }
}
