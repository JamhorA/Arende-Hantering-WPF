using System.Collections.Generic;
using System;

namespace Arende_hantering_wpf.Models.Entities;

internal class CaseEntity
{
    public CaseEntity()
    {
        var _datetime = DateTime.Now;


        Id = Guid.NewGuid();
        Created = _datetime;
        Modified = _datetime;
        //StatusTypeId = 1;
    }
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Guid UserId { get; set; }
    public int StatusTypeId { get; set; }

    public UserEntity User { get; set; } = null!;

    public StatusTypeEntity StatusType { get; set; } = null!;
    
    public ICollection<CommentEntity> Comments { get; set; } = new HashSet<CommentEntity>();
}
