namespace VCard.Models
{
    public class RandomUserResponseModel
    {
        public List<RamdomUserModel> Results { get; set; }
    }
    public class RamdomUserModel
    {
        public Name Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Location Location { get; set; }
        public Id Id { get; set; }
    }
    public class Name
    {
        public string First { get; set; }
        public string Last { get; set; } 
    }

    public class Location
    {
        public string Country { get; set; } 
        public string City { get; set; }
    }

    public class Id
    {
        public string Value { get; set; }
    }

}
