using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class CDProvider
    {
        [Key]
        public int IdProvider { get; set; }
        public string ProviderName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public char IsDelete { get; set; } = '0';
    }
}
