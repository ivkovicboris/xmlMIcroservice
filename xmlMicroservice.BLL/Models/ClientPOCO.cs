﻿using System;
using System.Collections.Generic;
using System.Text;

namespace xmlMicroservice.BLL.Models
{
    public class ClientPOCO
    {
        public Guid ClientId { get; set; }
        public string Jmbg { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
