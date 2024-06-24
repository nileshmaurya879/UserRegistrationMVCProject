namespace RegistartionProject001.Models
{
    public class tblUserRegistartion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int SateId { get; set; }
        public int CityId { get; set; }
    }
}
