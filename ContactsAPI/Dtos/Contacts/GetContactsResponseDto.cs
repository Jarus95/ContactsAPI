namespace ContactsAPI.Dtos.Contacts
{
    public class GetContactsResponseDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Adress { get; set; }
    }
}
