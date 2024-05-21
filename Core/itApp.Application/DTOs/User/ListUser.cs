using grammerGame.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grammerGame.Application.DTOs.User
{
    public class ListUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
 
    }
}

