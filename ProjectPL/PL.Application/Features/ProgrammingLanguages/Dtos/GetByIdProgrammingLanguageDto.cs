namespace PL.Application.Features.ProgrammingLanguages.Dtos
{
    /// <summary>
    /// Response model of GetByIdLanguageQuery
    /// </summary>
    public class GetByIdProgrammingLanguageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
