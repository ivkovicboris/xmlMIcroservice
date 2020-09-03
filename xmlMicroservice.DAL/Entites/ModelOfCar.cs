using System;
using System.Collections.Generic;
using System.Text;

namespace xmlMicroservice.DAL.Entites
{
    public class ModelOfCar
    {
        public Guid Id { get; set; }
        public Guid CarBrandId { get; set; }
        public CarBrand CarBrand { get; set; }
        public string Name { get; set; }
    }
}
