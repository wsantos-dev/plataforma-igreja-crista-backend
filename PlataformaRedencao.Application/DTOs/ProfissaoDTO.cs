namespace PlataformaRedencao.Application.DTOs
{
    /// <summary>
    /// Data transfer object for profession (occupation) data.
    /// </summary>
    public class ProfessionDTO
    {
        /// <summary>Profession id.</summary>
        public int Id { get; set; }

        /// <summary>Profession name.</summary>
        public string Name { get; set; } = null!;

        /// <summary>Official profession code (e.g. CBO), if any.</summary>
        public string? Code { get; set; }
    }
}
