namespace PL.Application.Features.ProgrammingLanguages.Dtos
{
    /// <summary>
    /// Response model of CreateLanguageCommand
    /// </summary>
    public class CreatedProgrammingLanguageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int DisplayOrder { get; set; }
    }
}
