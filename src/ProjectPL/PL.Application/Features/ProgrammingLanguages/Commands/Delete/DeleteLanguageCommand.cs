using MediatR;
using PL.Application.Features.ProgrammingLanguages.Rules;
using PL.Application.Services.Repositories;
using PL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Application.Features.ProgrammingLanguages.Commands.Delete
{
    /// <summary>
    /// Deletes a ProgrammingLanguage record
    /// </summary>
    public class DeleteLanguageCommand : IRequest<int>
    {
        public int Id { get; set; }


        /// <summary>
        /// Handler of DeleteLanguageCommand
        /// </summary>
        public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, int>
        {
            private readonly IProgrammingLanguageRepository _repository;
            private readonly ProgrammingLanguageBusinessRules _businessRules;

            public DeleteLanguageCommandHandler(IProgrammingLanguageRepository repository, ProgrammingLanguageBusinessRules businessRules)
            {
                _repository = repository;
                _businessRules = businessRules;
            }

            public async Task<int> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage? programmingLanguage = await _repository.GetAsync(b => b.Id == request.Id);
                _businessRules.ShouldExist(programmingLanguage);

                await _repository.DeleteAsync(programmingLanguage);
                return request.Id;
            }
        }
    }
}
