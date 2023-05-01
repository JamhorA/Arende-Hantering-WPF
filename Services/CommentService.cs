using Arende_hantering_wpf.Contexts;
using Arende_hantering_wpf.Models;
using Arende_hantering_wpf.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Arende_hantering_wpf.Services;

internal class CommentService : GenericService<CommentEntity>
{
    private readonly DataContext _context = new DataContext();

    internal async Task SaveAsync(CommentAddModel model)
    {
        var commentEntity = new CommentEntity()
        {
            Comment = model.Comment,
        };

        var userEntity = await _context.Users.FirstOrDefaultAsync(x => x.Id == model.User.Id);
        var caseEntity = await _context.Cases.FirstOrDefaultAsync(x => x.Id == model.Case.Id);
        if (userEntity != null)
            commentEntity.UserId = userEntity.Id;
        if (caseEntity != null)
            commentEntity.CaseId = caseEntity.Id;

        _context.Add(commentEntity);
        await _context.SaveChangesAsync();
     }
  
}
