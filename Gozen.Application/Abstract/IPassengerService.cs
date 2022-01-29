using Gozen.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gozen.Application.Abstract
{
    public interface IPassengerService
    {
        public Task<List<PassengerDto>> Read(string type);
        public Task<PassengerDto> Read(Guid id, string type);
        public Task Create(PassengerDto dto, string type);
        public Task Update(PassengerDto dto, string type);
        public Task Delete(Guid id, string type);
    }
}
