using Arende_hantering_wpf.Contexts;
using Arende_hantering_wpf.Models.Entities;
using Arende_hantering_wpf.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace Arende_hantering_wpf.Services;

internal class CaseService : GenericService<CaseEntity>
{
    private readonly DataContext _context = new DataContext();
   
    public async Task SaveAsync(CaseAddModel model)
    {
        
        var caseEntity = new CaseEntity()
        {
            Title = model.Title,
            Description = model.Description,
            StatusTypeId = 1,
        };
        if (model.User != null)
        {
            //check user
            var userEntity = await _context.Users.FirstOrDefaultAsync(x => x.Email == model.User.Email);

            if (userEntity != null)
                caseEntity.UserId = userEntity.Id;
                
                
            else
            {
                //check address
                var adressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.StreetName == model.User.StreetName);
                if (adressEntity == null)
                {
                    adressEntity = new AddressEntity()
                    {
                        StreetName = model.User.StreetName,
                        PostalCode = model.User.PostalCode,
                        City = model.User.City,
                    };
                    _context.Addresses.Add(adressEntity);
                    await _context.SaveChangesAsync();
                };
                    userEntity = new UserEntity
                {
                    FirstName = model.User.FirstName,
                    LastName = model.User.LastName,
                    Email = model.User.Email,
                    PohoneNumber = model.User.PhoneNumber,
                    UserTypeId = (await _context.UserTypes.FirstOrDefaultAsync(X => X.TypeName == model.User.UserType))!.Id,
                    AddressId = (await _context.Addresses.FirstOrDefaultAsync(x => x.StreetName == model.User.StreetName))!.Id,
                };

                _context.Add(userEntity);
                await _context.SaveChangesAsync();

                caseEntity.UserId = userEntity.Id;


            }

        }
        _context.Add(caseEntity);
        await _context.SaveChangesAsync();
    }
    public async Task<IEnumerable<CaseEntity>> GetCasesAsync()
    {
        return await _context.Cases.ToListAsync();
    }

    public override async Task<IEnumerable<CaseEntity>> GetAllAsync()
    {
        return await _context.Cases.Include(x => x.User).Include(x => x.StatusType).ToListAsync();
    }

    public override async Task<CaseEntity> GetAsync(Expression<Func<CaseEntity, bool>> predicate)
    {
        var item = await _context.Cases
            .Include(x => x.User)
            .Include(x => x.User).ThenInclude(x => x.Address)
            .Include(x => x.User).ThenInclude(x => x.UserType)
            .Include(x => x.StatusType)
            .Include(x => x.Comments)
            .FirstOrDefaultAsync(predicate);
        if (item != null)
            return item;
        return null!;
    }

    internal Task GetAsync(object id)
    {
        throw new NotImplementedException();
    }

    //internal Task SaveAsync(CaseModel caseModel)
    //{
    //    throw new NotImplementedException();
    //}

    //public override async Task<CaseEntity> SaveAsync(CaseEntity entity, Expression<Func<CaseEntity, bool>> predicate)
    //{

    //}

    //internal async Task SaveUpdateAsync(CaseAddModel caseModel)
    //{
    //    var caseEntity = new CaseEntity()
    //    {
    //        StatusTypeId = caseModel.StatusTypeId,
    //    };
    //    _context.Add(caseEntity);
    //    await _context.SaveChangesAsync();
    //}
    internal async Task SaveUpdateAsync(CaseModel caseModel)
    {
        var caseEntity = await _context.Cases.FindAsync(caseModel.Id);
        if (caseEntity != null)
        {
            caseEntity.StatusTypeId = caseModel.StatusTypeId;
            await _context.SaveChangesAsync();
        }
    }
    internal async Task DeleteAsync(CaseModel caseModel)
    {
        var caseEntity = await _context.Cases.FirstOrDefaultAsync(x => x.Id == caseModel.Id);
        if (caseEntity != null)
        {
            _context.Cases.Remove(caseEntity);
            await _context.SaveChangesAsync();
        }
    }

}
