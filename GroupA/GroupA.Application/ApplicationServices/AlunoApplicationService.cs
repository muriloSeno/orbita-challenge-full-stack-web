
using AutoMapper;
using GroupA.Application.DTOs.Requests;
using GroupA.Application.DTOs.Responses;
using GroupA.Application.Interfaces;
using GroupA.Application.Interfaces.ApplicationServices;
using GroupA.Application.Interfaces.Services;
using GroupA.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
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

        public async Task DeleteAlunoById(int alunoId)
        {
            await _service.DeleteAlunoById(alunoId);
        }

        public async Task<List<AlunoResponse>> GetAlunos()
        {
            var alunos = await _service.GetAlunos();
            return alunos.Select(p => _mapper.Map<AlunoResponse>(p)).ToList();
        }

        public async Task<AlunoResponse> GetAlunoById(int alunoId)
        {
            var aluno = await _service.GetAlunoById(alunoId);
            return _mapper.Map<AlunoResponse>(aluno);
        }

        public async Task<AlunoResponse> UpdateAluno(int alunoId, CreateAlunoRequest aluno)
        {
            var updatedAluno = await _service.UpdateAluno(alunoId, _mapper.Map<Aluno>(aluno));
            return _mapper.Map<AlunoResponse>(updatedAluno);
        }
    }
}
