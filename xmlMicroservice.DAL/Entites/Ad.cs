using System;
using System.Collections.Generic;
using System.Text;

namespace xmlMicroservice.DAL.Entites
{
    public class Ad
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }
        public int Price { get; set; }
        public bool Cdw { get; set; }
        public ICollection<AdAdRequest> AdAdRequests { get; set; }

    }
}
