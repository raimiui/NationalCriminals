using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Document
    {
        public string FileName { get; set; }
        public Stream Content { get; set; }
    }
}
