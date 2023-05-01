using Arende_hantering_wpf.Contexts;
using Arende_hantering_wpf.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Arende_hantering_wpf.Services;

internal class AddressService : GenericService<AddressEntity>
{
    private readonly DataContext _context = new DataContext();
    public override async Task<IEnumerable<AddressEntity>> GetAllAsync()
    {
        return await _context.Addresses.ToListAsync();
    }
    public override async Task<AddressEntity> GetAsync(Expression<Func<AddressEntity, bool>> predicate)
    {
        var item = await _context.Addresses.FirstOrDefaultAsync(predicate, CancellationToken.None);
        if (item != null)
            return item;
        return null!;
    }
    public override async Task<AddressEntity> SaveAsync(AddressEntity entity)
    {
        var addressEntity = await GetAsync(x => x.StreetName == entity.StreetName && x.PostalCode == entity.PostalCode && x.City == entity.City);
        if(addressEntity == null)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        return addressEntity;
        
    }
}
