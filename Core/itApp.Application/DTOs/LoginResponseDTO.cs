using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grammerGame.Application.DTOs
{
    public class LoginResponseDTO
    {
        public Token token { get; set; }
        public int userid { get; set; }
        public string username { get; set; }
    }
}
