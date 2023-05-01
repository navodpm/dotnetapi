﻿using AdminService.DataAccessLayer.Context;
using AdminService.DataAccessLayer.Entities;
using AdminService.DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AdminService.DataAccessLayer.Repository.Impl
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly DefaultDBContext dbContext;

        public UserRepository(DefaultDBContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Role> CreateRoleAsync(Role role)
        {
            var result = await dbContext.Roles.AddAsync(role);
            return result.Entity;
        }

        public async Task<bool> DeleteRole(int id)
        {
            var result = await dbContext.Roles.FindAsync(id);
            if (result is not null)
            {
                result.IsActive = false;
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            var result = await dbContext.Roles.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<Role?> GetRolesByIdAsync(int id)
        {
            var result = await dbContext.Roles.FindAsync(id);
            return result;
        }


    }
}
