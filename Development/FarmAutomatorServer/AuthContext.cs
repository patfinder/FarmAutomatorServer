﻿using VisitMeServer.API.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Diagnostics;

namespace VisitMeServer.API
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        [DebuggerStepThrough]
        public AuthContext() : base("AuthContext")
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}