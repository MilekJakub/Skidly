﻿using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Skidly.Domain.Aggregates;
using Skidly.Infrastructure.EntityFramework.Contexts;
using Skidly.Infrastructure.Identity;

namespace Skidly.Infrastructure.EntityFramework;

public static class Seeder
{
    public static async Task Seed(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        
        var writeDbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();
        var identityDbContext = scope.ServiceProvider.GetService<ApplicationIdentityDbContext>();
        var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
        var roleManager = scope.ServiceProvider.GetService<RoleManager<Role>>();

        if (writeDbContext == null
            || identityDbContext == null
            || userManager == null
            || roleManager == null)
        {
            throw new ExternalException("Error occured while trying to seed data. Cannot get required services.");
        }

        await identityDbContext.Database.MigrateAsync();
        await identityDbContext.Database.EnsureCreatedAsync();
        
        await writeDbContext.Database.MigrateAsync();
        await writeDbContext.Database.EnsureCreatedAsync();
        
        if (await roleManager.Roles.AnyAsync() == false)
        {
            await roleManager.CreateAsync(new Role() { Name = "Administrator"});
            await roleManager.CreateAsync(new Role() { Name = "User" });
        }

        if (await userManager.Users.AnyAsync() == false)
        {
            ApplicationUser admin = new()
            {
                 Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                 Email = "admin@localhost",
                 NormalizedEmail = "ADMIN@LOCALHOST",
                 UserName = "Administrator",
                 NormalizedUserName = "ADMINISTRATOR",
                 EmailConfirmed = true
            };                
            
            await userManager.CreateAsync(admin, "SuperSecret@1"); 
            await userManager.AddToRoleAsync(admin, "Administrator");
            
            
            ApplicationUser standard = new()
            {
                 Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                 Email = "user@localhost",
                 NormalizedEmail = "USER@LOCALHOST",
                 UserName = "milekjakub",
                 NormalizedUserName = "USER@LOCALHOST.COM",
                 EmailConfirmed = true
            };                
            
            await userManager.CreateAsync(standard, "SuperSecret@1"); 
            await userManager.AddToRoleAsync(standard, "User");
        }
            
        await identityDbContext.SaveChangesAsync();
    }
}