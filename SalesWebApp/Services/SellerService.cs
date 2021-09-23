﻿using Microsoft.EntityFrameworkCore;
using SalesWebApp.Data;
using SalesWebApp.Models.Entities;
using SalesWebApp.Services.Exceptions;
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

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if (!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found.");
            }

            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

    }
}