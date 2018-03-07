using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LexiconLMS.Models
{
    public class Document
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public int DocumentId { get; set; }
        public int ReferredDocId { get; set; }
        public DateTime ResponseDeadline { get; set; }
        public string Contents { get; set; }
    }
}