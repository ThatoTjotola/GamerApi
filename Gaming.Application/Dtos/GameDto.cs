namespace Gaming.Application.Dtos
{
    public class GameDto
    {
        public string ?Name { get; set; }
        public string ?Genre { get; set; }
        public string ?Platform { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
    }
}
