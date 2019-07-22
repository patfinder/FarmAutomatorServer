using VisitMeServer.API.Entities;
using VisitMeServer.API.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using log4net;
using Newtonsoft.Json;

namespace VisitMeServer.API
{
    public class AuthRepository : IDisposable
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(AuthRepository));

        private readonly AuthContext _ctx;
        private readonly UserStore<IdentityUser> _store;
        private readonly UserManager<IdentityUser> _userManager;

        [DebuggerStepThrough]
        public AuthRepository()
        {
            _ctx = new AuthContext();
            _store = new UserStore<IdentityUser>(_ctx);
            _userManager = new UserManager<IdentityUser>(_store);
        }

        public async Task<IdentityResult> RegisterUser(LoginModel user)
        {
            IdentityUser userIdentity = new IdentityUser
            {
                UserName = user.UserName,
                Id = user.Id,
            };

            var result = await _userManager.CreateAsync(userIdentity, user.Password);

            return result;
        }

        public async Task<IdentityResult> RemoveUser(IdentityUser userIdentity)
        {
            //IdentityUser userIdentity = new IdentityUser
            //{
            //    UserName = userName,
            //};

            var result = await _userManager.DeleteAsync(userIdentity);

            return result;
        }

        public IdentityUser FindByName(string userName)
        {
            return _userManager.FindByName(userName);
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public Client FindClient(string clientId)
        {
            var client = _ctx.Clients.Find(clientId);

            return client;
        }

        public async Task<bool> AddRefreshToken(RefreshToken token)
        {

            var existingToken = _ctx.RefreshTokens.SingleOrDefault(r => r.Subject == token.Subject && r.ClientId == token.ClientId);

            if (existingToken != null)
            {
                await RemoveRefreshToken(existingToken);
            }

            _ctx.RefreshTokens.Add(token);

            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveRefreshToken(string refreshTokenId)
        {
            var refreshToken = await _ctx.RefreshTokens.FindAsync(refreshTokenId);

            if (refreshToken != null)
            {
                _ctx.RefreshTokens.Remove(refreshToken);
                return await _ctx.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<bool> RemoveRefreshToken(RefreshToken refreshToken)
        {
            _ctx.RefreshTokens.Remove(refreshToken);
            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<RefreshToken> FindRefreshToken(string refreshTokenId)
        {
            var refreshToken = await _ctx.RefreshTokens.FindAsync(refreshTokenId);

            return refreshToken;
        }

        public List<RefreshToken> GetAllRefreshTokens()
        {
            return _ctx.RefreshTokens.ToList();
        }

        public async Task<IdentityUser> FindAsync(UserLoginInfo loginInfo)
        {
            IdentityUser user = await _userManager.FindAsync(loginInfo);

            return user;
        }

        public async Task<IdentityResult> CreateAsync(IdentityUser user)
        {
            var result = await _userManager.CreateAsync(user);

            return result;
        }

        public async Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login)
        {
            var result = await _userManager.AddLoginAsync(userId, login);

            return result;
        }

        public async Task<IdentityResult> SetRole(string userId, string role)
        {
            var user = _userManager.Users.First(u => u.Id == userId);

            // Remove all current roles
            var result = await _userManager.RemoveFromRolesAsync(userId, user.Roles.Select(r => r.RoleId).ToArray());

            if (!result.Succeeded)
            {
                Log.Error($"Auth.{nameof(SetRole)} errors: {JsonConvert.SerializeObject(result)}");
            }

            // Add new role
            result = await _userManager.AddToRoleAsync(userId, role);

            return result;
        }
        
        public async Task UpdatePassword(string userId, string password)
        {
            var iUser = _userManager.FindById(userId);

            if (iUser == null)
                return;

            // Set new password
            await _store.SetPasswordHashAsync(iUser, _userManager.PasswordHasher.HashPassword(password));
            await _store.UpdateAsync(iUser);
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}