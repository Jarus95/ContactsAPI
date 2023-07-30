namespace ContactsAPI.Dtos.Contacts
{
    public class UpdateContactRequestDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Adress { get; set; }
    }
}
