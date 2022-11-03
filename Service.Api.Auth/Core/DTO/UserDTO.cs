using System.Collections.Generic;

namespace Service.Api.Auth.Core.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Token { get; set; }
        public RespDTO response { get; set; }
        
    }
}
