namespace DTO
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int ServiceCategoryId { get; set; }
        public String ServiceCategoryName { get; set; }
        public int TokenId { get; set; }
    }
}
