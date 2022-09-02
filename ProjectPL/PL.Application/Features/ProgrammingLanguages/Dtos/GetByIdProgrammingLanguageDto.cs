﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Application.Features.ProgrammingLanguages.Dtos
{
    /// <summary>
    /// Response model of GetByIdLanguageCommand
    /// </summary>
    public class GetByIdProgrammingLanguageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
