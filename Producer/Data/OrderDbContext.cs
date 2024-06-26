﻿using Microsoft.EntityFrameworkCore;
using Producer.Data;

public class OrderDbContext : DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options)
        : base(options)
    {
    }

    public DbSet<Order> Order { get; set; }
}
