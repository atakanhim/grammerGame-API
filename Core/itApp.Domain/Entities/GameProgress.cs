using grammerGame.Domain.Entities.Common;
using grammerGame.Domain.Entities.Identity;
using grammerGame.Domain.Enums;
using grammerGame.Domain.Enums.grammerGame.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grammerGame.Domain.Entities
{
    public class GameProgress:BaseEntity
    {
        public int TotalGamesPlayed { get; set; } = 0;
        public int TotalCorrectAnswers { get; set; } = 0;
        public int TotalIncorrectAnswers { get; set; } = 0;
        public int HighestStreak { get; set; } = 0;
        public int TotalScore { get; set; } = 0;
        public DateTime LastGameDate { get; set; } = DateTime.MinValue;
        public string Rank { get; set; } = RankMap.GetName(0);
        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }

}
