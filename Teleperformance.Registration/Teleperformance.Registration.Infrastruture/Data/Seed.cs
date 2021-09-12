using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Teleperformance.Registration.Domain.Entities;

namespace Teleperformance.Registration.Infrastruture.Data
{
    public static class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using AppDbContext context = serviceProvider.GetRequiredService<AppDbContext>();
            context.Database.EnsureCreated();

            if (!context.Companies.Any())
            {
                var CompanyList = new[]
                {
                    new Company{
                        IdentificationType = 1,
                        IdentificationNumber = "900674336",
                        CompanyName = "MORUMBI",
                        FirstName = "Bruce",
                        SecondName = "Joseph",
                        FirstLastname = "Wayne",
                        SecondLastname = "Smith",
                        Email = "Bruce.Wayne@gmail.com",
                        SendMessage=true,
                        SendEmail=true
                    },
                    new Company{
                        IdentificationType = 1,
                        IdentificationNumber = "811033098",
                        CompanyName = "IMPORTECNICAL S.A.S.",
                        FirstName = "Clark",
                        SecondName = "Joseph",
                        FirstLastname = "Kent",
                        SecondLastname = "Contreras",
                        Email = "Clark.Kent@gmail.com",
                        SendMessage=false,
                        SendEmail=false
                    },

                };
                context.Companies.AddRangeAsync(CompanyList);
                context.SaveChanges();
            }
        }
    }
}
