using grammerGame.Domain.Entities.Common;
using grammerGame.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grammerGame.Domain.Entities
{
    public class SocialData:BaseEntity
    {
        public string[] Friends { get; set; } = new string[] { };
        public string[] FriendRequests { get; set; } = new string[] { };

        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
