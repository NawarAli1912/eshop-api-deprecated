﻿namespace eshop.Persistence.Repositories.Customers.DAOs;
public class CustomerDao
{
    public Guid Id { get; set; } = default!;

    public string Email { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
}
