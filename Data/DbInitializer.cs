using exercise22.Models;
using System;
using System.Linq;

namespace exercise22.Data
{
    public static class DbInitializer
    {
        public static void Initialize(InsuranceContext context)
        {

            if (context.PersonModel.Any())
            {
                return;   // DB has been seeded
            }

            var Person = new PersonModel[]
            {
                new PersonModel {ID = 0, FirstName="Rio Mae", LastName = "Panglimotan",Address="Sanciangko Street cebu city",Age = 90,DOB=DateTime.Parse("2019-09-01"),
                PolicyDetails="Medicare Blue PLUS"
                },
            };
            
            context.Person.AddRange(Person);
            context.SaveChanges();

        }
    }
}