﻿using LibApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.MembershipTypes.Any())
                {
                    Console.WriteLine("Database already seeded");
                    return;
                }

                context.MembershipTypes.AddRange(
                    new MembershipType
                    {
                        Id = 1,
                        Name = "test",
                        SignUpFee = 0,
                        DurationInMonths = 0,
                        DiscountRate = 0,
                    },
                    new MembershipType
                    {
                        Id = 2,
                        Name = "test2",
                        SignUpFee = 30,
                        DurationInMonths = 1,
                        DiscountRate = 10,
                    },
                    new MembershipType
                    {
                        Id = 3,
                        Name = "test3",
                        SignUpFee = 90,
                        DurationInMonths = 3,
                        DiscountRate = 15,
                    },
                    new MembershipType
                    {
                        Id = 4,
                        Name = "test4",
                        SignUpFee = 300,
                        DurationInMonths = 12,
                        DiscountRate = 20,
                    }
                 );
                context.SaveChanges();
            }
        }
    }
}
