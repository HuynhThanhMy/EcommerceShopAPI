using EcommerceWebAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace EcommerceWebAPI.Repositories
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> SignInAsync(SignInModel model);
    }
}
