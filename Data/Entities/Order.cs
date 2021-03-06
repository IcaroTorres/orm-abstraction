﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Entities
{
    public class Order
    {
        public Order() { }
        public Guid Id { get; set; } = System.Guid.NewGuid();
        public Order(Customer costumer, ICollection<OrderProduct> orderProducts)
        {
            Customer = costumer;
            OrderProducts = orderProducts;
        }
        public Order(Guid costumerId, ICollection<OrderProduct> orderProducts)
        {
            CustomerId = costumerId;
            OrderProducts = orderProducts;
        }
        public decimal TotalAmount => OrderProducts.Sum(product => product.AmountValue);
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public DateTime PaymentDate { get; private set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

        public Order SetPaymentDate()
        {
            PaymentDate = DateTime.UtcNow;
            return this;
        }
        public Order SetPaymentDate(DateTime date)
        {
            PaymentDate = date;
            return this;
        }
    }
}
