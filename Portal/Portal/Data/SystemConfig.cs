using System;
using System.Collections.Generic;

namespace Portal.Data
{
    public partial class SystemConfig
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool? Status { get; set; }
    }
}
