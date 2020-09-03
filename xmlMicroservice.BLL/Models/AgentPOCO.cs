﻿using System;
using System.Collections.Generic;
using System.Text;

namespace xmlMicroservice.BLL.Models
{
    public class AgentPOCO
    {
        public Guid AgentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pib { get; set; }
        public string BankAccNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
