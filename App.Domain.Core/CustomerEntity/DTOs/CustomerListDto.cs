namespace App.Domain.Core.CustomerEntity.DTOs;

public class CustomerListDto
{
    public int CustomerId { get; set; }
    public string FullName { get; set; }
    public string? ProfileImage { get; set; }
}
