using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupA.Application.DTOs.Requests
{
    public class CreateAlunoRequest
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Ra { get; set; }

        [Required]
        public string Cpf { get; set; }
    }
}
