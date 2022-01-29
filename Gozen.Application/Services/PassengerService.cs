using Gozen.Application.Abstract;
using Gozen.Application.Dtos;
using Gozen.Application.Mapper;
using Gozen.Domain.Abstract;
using Gozen.Domain.Exceptions;
using Gozen.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gozen.Application.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly IRedisService<List<Passenger>> _redisService;

        public PassengerService(IRedisRepository repository)
        {
            _redisService = repository.GetRepository<List<Passenger>>();
        }

        public async Task Create(PassengerDto dto, string type)
        {
            var caseData = await Read(type);

            if (!dto.UniquePassengerId.HasValue)
                dto.UniquePassengerId = Guid.NewGuid();

            if (caseData == null)
                caseData = new List<PassengerDto>() { dto };
            else
            {
                if (caseData.Any(o => o.UniquePassengerId == dto.UniquePassengerId))
                {
                    throw new UniqueIdAlreadyTakenException($"UniquePassengerId = {dto.UniquePassengerId}, already in use");
                }

                caseData.Add(dto);
            }

            await _redisService.SetAsync(type, ConvertListToEntity(caseData));
        }

        public async Task Delete(Guid id, string type)
        {
            var passengerList = await Read(type);

            var passenger = passengerList.FirstOrDefault(f => f.UniquePassengerId == id);

            if(passenger == null)
            {
                throw new NullReferenceException("No passenger found!");
            }
            
            passengerList.Remove(passenger);

            await _redisService.SetAsync(type, ConvertListToEntity(passengerList));
        }

        public async Task<List<PassengerDto>> Read(string type)
        {
            return ConvertListToDto(await _redisService.GetAsync(type));
        }

        public async Task<PassengerDto> Read(Guid id, string type)
        {
            var result = await Read(type);

            return result.FirstOrDefault(w => w.UniquePassengerId == id);
        }

        public async Task Update(PassengerDto dto, string type)
        {
            if (!dto.UniquePassengerId.HasValue)
            {
                throw new ArgumentNullException(nameof(dto), "UniquePassengerId cannot be null!");
            }

            List<PassengerDto> data = await Read(type);

            PassengerDto passenger = data.FirstOrDefault(f => f.UniquePassengerId == dto.UniquePassengerId);

            if (passenger == null)
            {
                throw new NullReferenceException(nameof(dto), new Exception("No passenger found!"));
            }

            int passengerIndex = data.FindIndex(f => f.UniquePassengerId == dto.UniquePassengerId);

            passenger.Name = dto.Name;
            passenger.Surname = dto.Surname;
            passenger.IssueDate = dto.IssueDate;
            passenger.DocumentNo = dto.DocumentNo;
            passenger.DocumentType = dto.DocumentType;
            passenger.Gender = dto.Gender;

            data[passengerIndex] = passenger;

            await _redisService.SetAsync(type, ConvertListToEntity(data));
        }

        #region Object Mapper
        private List<PassengerDto> ConvertListToDto(List<Passenger> passengers)
        {
            return ObjectMapper.Map<List<Passenger>, List<PassengerDto>>(passengers);
        }

        private List<Passenger> ConvertListToEntity(List<PassengerDto> passengers)
        {
            return ObjectMapper.Map<List<PassengerDto>, List<Passenger>>(passengers);
        }

        private PassengerDto ConvertToDto(Passenger passenger)
        {
            return ObjectMapper.Map<Passenger, PassengerDto>(passenger);
        }

        private Passenger ConvertToEntity(PassengerDto passenger)
        {
            return ObjectMapper.Map<PassengerDto, Passenger>(passenger);
        }
        #endregion
    }
}
