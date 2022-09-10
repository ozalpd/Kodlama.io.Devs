using MediatR;
using PL.Application.Features.ProgrammingTechnologies.Rules;
using PL.Application.Services.Repositories;
using PL.Domain.Entities;

namespace PL.Application.Features.ProgrammingTechnologies.Commands.Delete
{
    /// <summary>
    /// Deletes a ProgrammingTechnology record
    /// </summary>
    public class DeleteTechnologyCommand : IRequest<int>
    {
        public int Id { get; set; }


        /// <summary>
        /// Handler of DeleteTechnologyCommand
        /// </summary>
        public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, int>
        {
            private readonly IProgrammingTechnologyRepository _repository;
            private readonly ProgrammingTechnologyBusinessRules _businessRules;

            public DeleteTechnologyCommandHandler(IProgrammingTechnologyRepository repository, ProgrammingTechnologyBusinessRules businessRules)
            {
                _repository = repository;
                _businessRules = businessRules;
            }

            public async Task<int> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
            {
                ProgrammingTechnology? programmingTechnology = await _repository.GetAsync(b => b.Id == request.Id);
                _businessRules.ShouldExist(programmingTechnology);

                await _repository.DeleteAsync(programmingTechnology);
                return request.Id;
            }
        }
    }
}
