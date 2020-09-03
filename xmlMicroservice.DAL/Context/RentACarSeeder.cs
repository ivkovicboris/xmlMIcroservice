﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xmlMicroservice.DAL.Entites;

namespace xmlMicroservice.DAL.Context
{
    public class RentACarSeeder
    {
        private readonly RentACarContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RentACarSeeder(RentACarContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            try
            {
                _context.Database.EnsureCreated();

                if (!_context.Users.Any())
                {
                    User admin = new User()
                    {
                        UserName = "Boka",
                        Email = "ivkovicboris95@gmail.com",
                        EmailConfirmed = true,
                    };


                    await _roleManager.CreateAsync(new IdentityRole("Agent"));
                    await _roleManager.CreateAsync(new IdentityRole("Client"));
                    await _roleManager.CreateAsync(new IdentityRole("Admin"));


                    var result = await _userManager.CreateAsync(admin, "Gaja1234!");
                    var result1 = await _userManager.AddToRoleAsync(admin, "Admin");
                    if (result != IdentityResult.Success)
                    {
                        throw new InvalidOperationException("Could not create new user in seeder");
                    }
                    admin.UserId = Guid.Parse(admin.Id);



                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception message: {0}", ex.Message);
            }
        }
    }
}
