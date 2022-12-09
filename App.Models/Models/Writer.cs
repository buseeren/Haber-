using System;
using System.Collections.Generic;

#nullable disable

namespace App.Models.Models
{
    public partial class Writer
    {
        public int WriterId { get; set; }
        public string WriteName { get; set; }
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }
        public int WriterStatus { get; set; }
    }
}
