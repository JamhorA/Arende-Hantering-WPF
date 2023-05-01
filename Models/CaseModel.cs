using System.Collections.Generic;
using System;

namespace Arende_hantering_wpf.Models;

internal class CaseModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Status { get; set; } = null!;
    public int StatusTypeId { get; set; } = 1;
    public UserModel User { get; set; } = null!;
    public ICollection<CommentModel> Comments { get; set; } = new List<CommentModel>();
}
