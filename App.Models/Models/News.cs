using System;
using System.Collections.Generic;

#nullable disable

namespace App.Models.Models
{
    public partial class News
    {
        public int NewsId { get; set; }
        public string NewsTitle { get; set; }
        public string NewsContent { get; set; }
        public DateTime? NewsCreateDate { get; set; }
        public int NewsStatus { get; set; }
    }
}
