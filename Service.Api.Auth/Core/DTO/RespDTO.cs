using System.Collections.Generic;

namespace Service.Api.Auth.Core.DTO
{
    public class RespDTO
    {
        public bool OK { get; set; }
        public string Message { get; set; }
        public List<string> listErrors { get; set; } = null;
    }
}
