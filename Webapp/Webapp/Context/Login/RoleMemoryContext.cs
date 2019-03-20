using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Webapp.Models.Data;

namespace Webapp.Context.Login
{
    public class RoleMemoryContext : IRoleStore<Role>
    {
        private List<Role> roles;

        public RoleMemoryContext()
        {
            roles = new List<Role>()
            {
                new Role()
                {
                    Id = 1,
                    Name = "admin",
                    CreatedDate = DateTime.Now
                },
                new Role()
                {
                    Id = 2,
                    Name = "patient",
                    CreatedDate = DateTime.Now
                },
                new Role()
                {
                    Id = 3,
                    Name = "doctor",
                    CreatedDate = DateTime.Now
                }
            };
        }

        public Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            
        }

        public Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                return Task.FromResult(roles.FirstOrDefault(r => r.Name == normalizedRoleName));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
