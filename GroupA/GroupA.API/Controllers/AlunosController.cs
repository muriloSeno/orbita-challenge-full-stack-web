using GroupA.Application.DTOs.Requests;
using GroupA.Application.DTOs.Responses;
using GroupA.Application.Interfaces.ApplicationServices;
using GroupA.Application.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroupA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoApplicationService _aplicationService;

        public AlunosController(IAlunoApplicationService applicationService)
        {
            _aplicationService = applicationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AlunoResponse>>> GetAlunos()
        {
            return Ok(await _aplicationService.GetAlunos());
        }

        [HttpGet("GetAlunoById")]
        public async Task<ActionResult> GetAlunoById([FromQuery] int id)
        {
            try
            {
                var aluno = await _aplicationService.GetAlunoById(id);
                return Ok(aluno);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateAlunoRequest request)
        {
            var aluno = await _aplicationService.CreateAluno(request);
            return Ok(aluno);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromQuery] int id, [FromBody] CreateAlunoRequest request)
        {
            try
            {
                var aluno = await _aplicationService.UpdateAluno(id, request);
                return Ok(aluno);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                await _aplicationService.DeleteAlunoById(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
