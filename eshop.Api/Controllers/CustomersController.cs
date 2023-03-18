using eshop.Domain.Customers.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace eshop.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ICustomerRepostiory _customerRepository;

    public CustomersController(ICustomerRepostiory customerRepository)
    {
        _customerRepository = customerRepository;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _customerRepository.GetAsync(new Domain.Customers.ValueObjects.CustomerId(id)));
    }
}
