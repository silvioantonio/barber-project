using AutoMapper;
using MeuBarbeiro.API.Data.ValueObjects;
using MeuBarbeiro.API.Models.Appointment;
using MeuBarbeiro.API.Models.Provider;
using MeuBarbeiro.API.Models.ProviderHour;
using MeuBarbeiro.API.Models.User;
using MeuBarbeiro.API.Models.Worker;

namespace MeuBarbeiro.API.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration((config) =>
            {
                config.CreateMap<UserVO, User>();
                config.CreateMap<User, UserVO>();

                config.CreateMap<ProviderVO, Provider>();
                config.CreateMap<Provider, ProviderVO>();

                config.CreateMap<ProviderHourVO, ProviderHour>();
                config.CreateMap<ProviderHour, ProviderHourVO>();

                config.CreateMap<AddressVO, Address>();
                config.CreateMap<Address, AddressVO>();

                config.CreateMap<ProviderOpeningHoursVO, ProviderOpeningHours>();
                config.CreateMap<ProviderOpeningHours, ProviderOpeningHoursVO>();

                config.CreateMap<AppointmentVO, Appointment>();
                config.CreateMap<Appointment, AppointmentVO>();

                config.CreateMap<WorkerVO, Worker>();
                config.CreateMap<Worker, WorkerVO>();
            });
            return mappingConfig;
        }
    }
}
