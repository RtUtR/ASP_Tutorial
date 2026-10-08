namespace ASp_Tutorial._4Day.Entitiy
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public bool IsMarried { get; set; }
        public DateTimeOffset RegisterDate { get; set; }= DateTimeOffset.UtcNow;
    }
}
