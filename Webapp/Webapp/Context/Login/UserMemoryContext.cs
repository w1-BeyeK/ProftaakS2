using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Webapp.Models.Data;

namespace Webapp.Context.Login
{
    public class UserMemoryContext : IUserStore<BaseAccount>, IUserPasswordStore<BaseAccount>, IUserEmailStore<BaseAccount>, IUserRoleStore<BaseAccount>
    {
        private readonly List<BaseAccount> accounts;

        public UserMemoryContext()
        {
            accounts = new List<BaseAccount>()
            {
                new Administrator(12, "kevinbeye", "k.beye@student.fontys.nl", "Kevin")
                {
                    Password = "AQAAAAEAACcQAAAAEDUhPAiD1wmdSduXLptdEQURGL9oocNf9T9nKEk4wdBZ9V/foWU1Saa4kd47qZBI6Q==",
                    NormalizedUserName = "KEVINBEYE"
                },
                new Patient(2, "stijn3ssens", "stijn@student.fontys.nl", "Kevin"),
                new Patient(3, "w@ng", "w@ng@student.fontys.nl", "Kevin"),
                new Patient(12, "patient", "patient", "patient")
                {
                    Password = "AQAAAAEAACcQAAAAEDUhPAiD1wmdSduXLptdEQURGL9oocNf9T9nKEk4wdBZ9V/foWU1Saa4kd47qZBI6Q==",
                    NormalizedUserName = "PATIENT"
                },
                new Doctor(11, "doctor", "doctor", "doctor")
                {
                    Password = "AQAAAAEAACcQAAAAEDUhPAiD1wmdSduXLptdEQURGL9oocNf9T9nKEk4wdBZ9V/foWU1Saa4kd47qZBI6Q==",
                    NormalizedUserName = "DOCTOR"
                },
                new Administrator(12, "admin", "admin", "admin")
                {
                    Password = "AQAAAAEAACcQAAAAEDUhPAiD1wmdSduXLptdEQURGL9oocNf9T9nKEk4wdBZ9V/foWU1Saa4kd47qZBI6Q==",
                    NormalizedUserName = "ADMIN"
                },
            };

        }

        public Task AddToRoleAsync(BaseAccount user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> CreateAsync(BaseAccount user, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                accounts.Add(user);
                return Task.FromResult(IdentityResult.Success);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Task<IdentityResult> DeleteAsync(BaseAccount user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            
        }

        public Task<BaseAccount> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            try
            {

                cancellationToken.ThrowIfCancellationRequested();

                BaseAccount account = accounts.FirstOrDefault(a => a.Email == normalizedEmail);
                return Task.FromResult(account);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<BaseAccount> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            try
            {

                cancellationToken.ThrowIfCancellationRequested();

                BaseAccount account = accounts.FirstOrDefault(a => a.Id == int.Parse(userId));
                return Task.FromResult(account);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Task<BaseAccount> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                return Task.FromResult(accounts.FirstOrDefault(a => a.UserName.ToUpper() == normalizedUserName));
            }
            catch(Exception)
            {
                throw;
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
            return Task.FromResult(user.Email);
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
                    user.Role
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
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(BaseAccount user, string roleName, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                return Task.FromResult(user.Role == roleName);
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

        public Task SetEmailAsync(BaseAccount user, string email, CancellationToken cancellationToken)
        {
            user.Email = email;
            return Task.FromResult(0);
        }

        public Task SetEmailConfirmedAsync(BaseAccount user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedEmailAsync(BaseAccount user, string Email, CancellationToken cancellationToken)
        {
            user.Email = Email;
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

        public Task<IdentityResult> UpdateAsync(BaseAccount user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
