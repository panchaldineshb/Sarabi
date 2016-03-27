using CICD.Infrastructure.Abstraction;

namespace CICD.Infrastructure.Domain
{
    public class Video : IEntity<int>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public int YearReleased { get; set; }

        public decimal RetailPrice { get; set; }

        public decimal RentalPrice { get; set; }

        public int RentalDays { get; set; }

        public void Rent(int customerId)
        {
        }
    }
}