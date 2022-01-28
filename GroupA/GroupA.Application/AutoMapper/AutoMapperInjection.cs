using AutoMapper;
using GroupA.Application.DTOs.Requests;
using GroupA.Application.DTOs.Responses;
using GroupA.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace GroupA.Application.AutoMapper
{
    public static class AutoMapperInjection
    {
        public static IServiceCollection RegisterAutoMapper(this IServiceCollection service)
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CreateAlunoRequest, Aluno>()
                 .ForMember(dest =>
                     dest.Id,
                     opt => opt.Ignore()
                 )
                 .ForMember(dest =>
                    dest.CreatedAt,
                    opt => opt.Ignore()
                )
                .ForMember(dest =>
                    dest.UpdatedAt,
                    opt => opt.Ignore());

                config.CreateMap<Aluno, AlunoResponse>();
            });

            var mapper = mapperConfig.CreateMapper();
            service.AddSingleton(mapper);
            return service;
        }
    }
}
