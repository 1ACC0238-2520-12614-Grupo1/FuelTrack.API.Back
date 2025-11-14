using FuelTrack.API.Back.Domain.Enums;
using FuelTrack.API.Back.Domain.Entities;

namespace FuelTrack.API.Back.Infrastructure;

public static class FakeDataSeeder
{
    public static List<Company> Companies { get; } = new();
    public static List<User> Users { get; } = new();
    public static List<Order> Orders { get; } = new();
    public static List<Tariff> Tariffs { get; } = new();

    static FakeDataSeeder()
    {
        // Companies
        var clientCompany = new Company
        {
            Id = Guid.NewGuid(),
            Name = "Cliente Demo S.A.C.",
            TaxId = "20123456789",
            Type = UserRole.Client
        };

        var supplierCompany = new Company
        {
            Id = Guid.NewGuid(),
            Name = "Proveedor FuelTrack S.A.",
            TaxId = "20987654321",
            Type = UserRole.Supplier
        };

        Companies.Add(clientCompany);
        Companies.Add(supplierCompany);

        // Users
        var clientUser = new User
        {
            Id = Guid.NewGuid(),
            Email = "client@fueltrack.com",
            PasswordHash = "123456", // solo demo
            FullName = "Cliente Demo",
            Role = UserRole.Client,
            CompanyId = clientCompany.Id,
            Company = clientCompany
        };

        var supplierUser = new User
        {
            Id = Guid.NewGuid(),
            Email = "supplier@fueltrack.com",
            PasswordHash = "123456", // solo demo
            FullName = "Proveedor Demo",
            Role = UserRole.Supplier,
            CompanyId = supplierCompany.Id,
            Company = supplierCompany
        };

        Users.Add(clientUser);
        Users.Add(supplierUser);

        // Tariffs demo
        Tariffs.Add(new Tariff
        {
            Id = Guid.NewGuid(),
            SupplierCompanyId = supplierCompany.Id,
            Zone = "Lima Norte",
            PriceCents = 450,
            FreightCents = 1500,
            WindowsCsv = "8-12,12-16"
        });

        Tariffs.Add(new Tariff
        {
            Id = Guid.NewGuid(),
            SupplierCompanyId = supplierCompany.Id,
            Zone = "Lima Sur",
            PriceCents = 460,
            FreightCents = 1800,
            WindowsCsv = "8-12,16-20"
        });

        // Order demo
        Orders.Add(new Order
        {
            Id = Guid.NewGuid(),
            ClientCompanyId = clientCompany.Id,
            SupplierCompanyId = supplierCompany.Id,
            VolumeLiters = 5000,
            Zone = "Lima Norte",
            Window = "8-12",
            TotalPriceCents = 5000 * 450 + 1500,
            Status = OrderStatus.OnRoute,
            CreatedAt = DateTime.UtcNow.AddHours(-5)
        });
    }
}