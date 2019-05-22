using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Webapp.Models.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Webapp.Interfaces;
using System.Data;

namespace Webapp.Context.Login
{
    public class MSSQLUserContext : IUserStore<BaseAccount>, IUserPasswordStore<BaseAccount>, IUserEmailStore<BaseAccount>, IUserRoleStore<BaseAccount>
    {
        private readonly IHandler handler;
        private readonly IParser parser;

        private readonly string _connectionString;
        public MSSQLUserContext(IConfiguration configuration, IHandler handler, IParser parser)
        {
            _connectionString = configuration.GetConnectionString("Development");
            this.handler = handler;
            this.parser = parser;
        }



        /// <summary>
        /// Create a user in de DB. The userId (in de database) must be set to auto increment. 
        /// The password is hashed automatically.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IdentityResult> CreateAsync(BaseAccount user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        ///Delete the user from the database (or make the user obsolete)
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IdentityResult> DeleteAsync(BaseAccount user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //nothing to do.
        }


        /// <summary>
        /// Finding a user by Email in the database
        /// </summary>
        /// <param name="normalizedEmail"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<BaseAccount> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            try
            {
                string query = "select * from [PTS2_Account] where email = @email";
                var result = handler.ExecuteSelect(query, normalizedEmail) as DataTable;

                if (!parser.TryParse(result.Rows[0], out BaseAccount account))
                    throw new NullReferenceException("Account not found");

                return Task.FromResult(account);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Finding a user by id in the datbase
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<BaseAccount> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            try
            {
                string query = "select * from [PTS2_Account] where id = @id";
                var result = handler.ExecuteSelect(query, userId) as DataTable;

                if (!parser.TryParse(result.Rows[0], out BaseAccount account))
                    throw new NullReferenceException("Account not found");

                return Task.FromResult(account);
            }
            catch
            {
                throw;
            }
        }

        public Task<BaseAccount> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            string query = "select * from [PTS2_Account] where email = @email";
            BaseAccount account = default(BaseAccount);

            try
            {
                var result = handler.ExecuteSelect(query, normalizedUserName) as DataTable;

                if (!parser.TryParse(result.Rows[0], out account))
                    throw new NullReferenceException("Account not found");
                return Task.FromResult(account);
            }
            catch
            {
                return Task.FromResult(account);
            }
        }

        public Task<string> GetEmailAsync(BaseAccount user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(BaseAccount user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedEmailAsync(BaseAccount user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedEmail);
        }

        public Task<string> GetNormalizedUserNameAsync(BaseAccount user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedUserName);
        }

        public Task<string> GetPasswordHashAsync(BaseAccount user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Password);
        }

        public Task<IList<string>> GetRolesAsync(BaseAccount user, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                IList<string> roles = new List<string>
                {
                    user.GetRole()
                };

                return Task.FromResult(roles);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<string> GetUserIdAsync(BaseAccount user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(BaseAccount user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public Task<IList<BaseAccount>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(BaseAccount user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Password != null);
        }

        public Task<bool> IsInRoleAsync(BaseAccount user, string roleName, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();                

                return Task.FromResult(user.IsInRole(roleName));

            }
            catch (Exception)
            {

                throw;
            }

        }

        public Task RemoveFromRoleAsync(BaseAccount user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task AddToRoleAsync(BaseAccount user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(BaseAccount user, string email, CancellationToken cancellationToken)
        {
            user.Email = email;
            return Task.FromResult(0);
        }

        public Task SetEmailConfirmedAsync(BaseAccount user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedEmailAsync(BaseAccount user, string normalizedEmail, CancellationToken cancellationToken)
        {
            user.NormalizedEmail = normalizedEmail;
            return Task.FromResult(0);
        }

        public Task SetNormalizedUserNameAsync(BaseAccount user, string normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizedUserName = normalizedName;
            return Task.FromResult(0);
        }

        public Task SetPasswordHashAsync(BaseAccount user, string passwordHash, CancellationToken cancellationToken)
        {
            user.Password = passwordHash;
            return Task.FromResult(0);
        }

        public Task SetUserNameAsync(BaseAccount user, string userName, CancellationToken cancellationToken)
        {
            user.UserName = userName;
            return Task.FromResult(0);
        }
        /// <summary>
        /// Update user in database
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IdentityResult> UpdateAsync(BaseAccount user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
