﻿namespace CICD.Initialize.Database
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; } // virtual for lazy loading
    }
}