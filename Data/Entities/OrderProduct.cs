﻿using System;

namespace Data.Entities
{
    public class OrderProduct
    {
        protected OrderProduct() { }
        public OrderProduct(Product product, int count)
        {
            Product = product;
            Count = count;
            AmountValue = Product.AmountValue;
            Product.UpdateStoreCountTo(Math.Abs(Count));
        }
        public OrderProduct(Product product, int count, decimal amountValue)
        {
            Product = product;
            Count = count;
            Product.UpdateStoreCountTo(Math.Abs(Count));

            if (amountValue <= 0)
                throw new ArgumentException($"{nameof(amountValue)} cannot be zero or negative.", nameof(amountValue));

            AmountValue = amountValue;
        }
        public Guid Id { get; set; } = System.Guid.NewGuid();
        public decimal AmountValue { get; private set; }
        public int Count { get; private set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }

        public OrderProduct UpdateOrderCountTo(int count)
        {
            if ((Count + count) < 0)
                throw new ArgumentException("Given count is bigger than available");

            Count += Math.Abs(count);
            return this;
        }
    }
}
