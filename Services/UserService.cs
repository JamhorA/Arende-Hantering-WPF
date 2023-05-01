using Arende_hantering_wpf.Contexts;
using Arende_hantering_wpf.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Arende_hantering_wpf.Services;

internal class UserService : GenericService<UserEntity>
{
    private readonly DataContext _context = new DataContext();

    public override async Task<IEnumerable<UserEntity>> GetAllAsync()
    {
        return await _context.Users.Include(x => x.Address).Include(x => x.UserType).ToListAsync();
    }

    public override async Task<UserEntity> GetAsync(Expression<Func<UserEntity, bool>> predicate)
    {
        var item = await _context.Users.Include(x => x.Address).Include(x => x.UserType).FirstOrDefaultAsync(predicate);
        if (item != null)
            return item;
        return null!;
    }

    public override Task<UserEntity> SaveAsync(UserEntity entity, Expression<Func<UserEntity, bool>> predicate)
    {
        return base.SaveAsync(entity, predicate);
    }
}

    //public async Task<IEnumerable<UserEntity>> GetByEmailAsync()
    //{
    //     return await _context.Users.ToListAsync();
    //}

//    public override Task SaveAsync(UserEntity entity)
//    {
//        return base.SaveAsync(entity);
//    }
//}
