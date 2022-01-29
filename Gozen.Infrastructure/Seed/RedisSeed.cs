using Gozen.Domain.Abstract;
using Gozen.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gozen.Infrastructure.Seed
{
    public class RedisSeed
    {
        private readonly IRedisService<List<Passenger>> service;
        private readonly List<string> _caseList;

        public RedisSeed(IRedisService<List<Passenger>> service)
        {
            this.service = service;
            _caseList = new List<string>() { "online", "offline", "usa", "uk" };
        }

        public void Seed()
        {
            foreach (string type in _caseList)
            {
                List<Passenger> passengers = new List<Passenger>();

                for (int i = 0; i < 10; i++)
                {
                    Passenger passenger = new Passenger()
                    {
                        Name = Faker.Name.First(),
                        Surname = Faker.Name.Last(),
                        Gender = i % 2 == 0 ? Domain.Enums.eGender.Male : Domain.Enums.eGender.Female,
                        IssueDate = DateTime.Now,
                        UniquePassengerId = Guid.NewGuid(),
                        DocumentNo = Faker.Identification.UsPassportNumber(),
                        DocumentType = i % 2 == 0 ? Domain.Enums.eDocumentType.Visa : Domain.Enums.eDocumentType.Pasaport
                    };     
                    
                    passengers.Add(passenger);
                }

                service.Set(type, passengers);
            }
        }
    }
}
