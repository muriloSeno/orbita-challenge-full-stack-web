using GroupA.Application.DTOs.Requests;
using GroupA.Application.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupA.Application.Interfaces.ApplicationServices
{
    public interface IAlunoApplicationService
    {
        Task<List<AlunoResponse>> GetAlunos();

        Task<AlunoResponse> GetAlunoById(int alunoId);

        Task DeleteAlunoById(int alunoId);

        Task<AlunoResponse> CreateAluno(CreateAlunoRequest aluno);

        Task<AlunoResponse> UpdateAluno(int alunoId, CreateAlunoRequest aluno); 
    }
}
