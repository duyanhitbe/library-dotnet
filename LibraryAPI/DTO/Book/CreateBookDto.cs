namespace LibraryAPI.DTO.Category;

public class CreateBookDto
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public DateTime PublicationDate { get; set; }
}