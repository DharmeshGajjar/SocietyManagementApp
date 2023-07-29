using System;
using System.Collections.Generic;

#nullable disable

namespace SocietyManagementApi.Models
{
    public partial class ClientMaster
    {
        public long ClientId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string EmailId { get; set; }
        public int? MobileNumber { get; set; }
        public string ContactPerson { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Splash { get; set; }
        public string Logo { get; set; }
    }
}
