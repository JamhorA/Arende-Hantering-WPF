using System.Collections.Generic;

namespace Arende_hantering_wpf.Models.Entities;

internal class StatusTypeEntity
{
    public int Id { get; set; }
    public string StatusName { get; set; } = null!;

    public ICollection<CaseEntity> Case { get; set; } = new HashSet<CaseEntity>();
}
