namespace ServerApp.DTO
{
    public record ProductDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public double Price { get; init; }
        public int Stock { get; init; }
        public CategoryDto Category { get; init; }
    }
}
