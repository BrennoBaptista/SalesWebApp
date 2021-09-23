using SalesWebApp.Data;
using SalesWebApp.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebApp.Services
{
    public class SellerService
    {
        private readonly SalesWebAppContext _context;

        public SellerService(SalesWebAppContext contex)
        {
            _context = contex;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }


    }
}