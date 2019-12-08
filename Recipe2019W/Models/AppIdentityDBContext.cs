﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Recipe2019W.Models
{
    public class AppIdentityDbContext: IdentityDbContext<IdentityUser>  //Identity user is the default class to identify users
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options) { } //Call Base Constructor
    }
}
