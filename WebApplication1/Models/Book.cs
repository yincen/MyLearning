using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public long PersonId { get; set; }

        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
    }
}