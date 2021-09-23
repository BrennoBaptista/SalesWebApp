using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebApp.Models.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Seller assossiation .*
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        { }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime inicialDate, DateTime finalDate)
        {
            return Sellers.Sum(s => s.TotalSales(inicialDate, finalDate));
        }
    }
}