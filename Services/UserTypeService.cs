using Arende_hantering_wpf.Contexts;
using Arende_hantering_wpf.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Arende_hantering_wpf.Services;

internal class UserTypeService : GenericService<UserTypeEntity>
{
    private readonly DataContext _context = new DataContext();
    public override async Task<IEnumerable<UserTypeEntity>> GetAllAsync()
    {
        return await _context.UserTypes.ToListAsync();
    }
    public override async Task<UserTypeEntity> GetAsync(Expression<Func<UserTypeEntity, bool>> predicate)
    {
        var item = await _context.UserTypes.FirstOrDefaultAsync(predicate, CancellationToken.None);
        if (item != null)
            return item;
        return null!;
    }
    public override async Task<UserTypeEntity> SaveAsync(UserTypeEntity entity)
    {
       
        _context.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
