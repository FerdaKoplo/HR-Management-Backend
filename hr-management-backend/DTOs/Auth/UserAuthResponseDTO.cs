namespace hr_management_backend.DTOs.Auth
{
    public class UserAuthResponseDTO
    {
        public string Token { get; set; }
        public UserDTO User { get; set; }
    }
}
