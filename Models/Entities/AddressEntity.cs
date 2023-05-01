using System.Collections.Generic;

namespace Arende_hantering_wpf.Models.Entities;

internal class AddressEntity
{
    public int Id { get; set; }
    public string StreetName { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;


    public ICollection<UserEntity> Users { get; set; } = new HashSet<UserEntity>();
}
