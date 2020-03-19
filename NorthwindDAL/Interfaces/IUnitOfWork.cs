using System;
using System.Collections.Generic;
using System.Text;
using NorthwindDAL.Entities;

namespace NorthwindDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Customer> Customers { get; }
        IRepository<Order> Orders { get; }
        IRepository<Product> Products { get; }
        IRepository<Supplier> Suppliers { get; }
        IRepository<Shipper> Shippers { get; }
        IRepository<Territory> Territories { get; }
        void Save();
    }
}
