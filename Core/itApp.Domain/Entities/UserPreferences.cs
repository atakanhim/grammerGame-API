using grammerGame.Domain.Entities.Common;
using grammerGame.Domain.Entities.Identity;
using grammerGame.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grammerGame.Domain.Entities
{
    public class UserPreferences:BaseEntity
    {
        public string PreferredLanguage { get; set; } = "English"; // Varsayılan dil
        public string NotificationPreferences { get; set; } = "{}"; 
        public Theme Theme { get; set; } = Theme.System; 
        // İlişkili Kullanıcı
        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
