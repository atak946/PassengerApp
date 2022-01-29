using AutoMapper;
using Gozen.Application.Dtos;
using Gozen.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gozen.Application.Mapper
{
    public class AutoMapperConfiguration
    {
        public readonly IMapper Mapper;
        public AutoMapperConfiguration()
        {
            var config = new MapperConfiguration(cfg => Configuration(cfg));

            Mapper = config.CreateMapper();
        }

        private IMapperConfigurationExpression Configuration(IMapperConfigurationExpression mapper)
        {
            mapper.CreateMap<PassengerDto, Passenger>().ReverseMap();

            return mapper;
        }
    }
}
