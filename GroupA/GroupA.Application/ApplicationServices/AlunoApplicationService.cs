using AutoMapper;
using GroupA.Application.DTOs.Requests;
using GroupA.Application.DTOs.Responses;
using GroupA.Application.Interfaces;
using GroupA.Application.Interfaces.ApplicationServices;
using GroupA.Application.Interfaces.Services;
using GroupA.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroupA.Application.ApplicationServices
{
    public class AlunoApplicationService : IAlunoApplicationService
    {
        private readonly IAlunoService _service;
        private readonly IMapper _mapper;

        public AlunoApplicationService(IAlunoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<AlunoResponse> CreateAluno(CreateAlunoRequest aluno)
        {
            var createdAluno = await _service.CreateAluno(_mapper.Map<Aluno>(aluno));

            return _mapper.Map<AlunoResponse>(createdAluno);
        }

        public Task DeleteAlunoById(int alunoId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<AlunoResponse>> GetAlunos()
        {
            throw new System.NotImplementedException();
        }

        public Task<AlunoResponse> GetAlunoById(int alunoId)
        {
            throw new System.NotImplementedException();
        }

        public Task<AlunoResponse> UpdateAluno(int alunoId, CreateAlunoRequest product)
        {
            throw new System.NotImplementedException();
        }
    }
}
