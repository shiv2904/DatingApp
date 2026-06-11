using System.Text.Json.Serialization;

namespace API.Entities
{
    public class Member
    {
        public string ID { get; set; } = null;
        public DateOnly DateOfBirth { get; set; }
        public string? ImageUrl { get; set; }
        public required string DisplayName { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        public required string Gender { get; set; }
        public string? Description { get; set; }
        public required string City { get; set; }
        public required string Country { get; set; }



        [JsonIgnore]
        public List<Photo> Photos { get; set; } = [];
        [JsonIgnore]
        public AppUser User { get; set; } = null!;

           



    }
}