namespace FinalProject.DTO
{
    public class Neighbor
    {
        public string Id { get; set; }
        public double Weight { get; set; }
        public Neighbor(string id, double weight)
        {
            this.Id = id;
            this.Weight = weight;
        }
    }
}
