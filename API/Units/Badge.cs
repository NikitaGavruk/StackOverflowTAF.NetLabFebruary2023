using System.Collections.Generic;

namespace API.Units
{
    public class Badge
    {
        public string BadgeType { get; set; }
        public int AwardCount { get; set; }
        public string Rank { get; set; }
        public int BadgeId { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
    }

    public class BadgesRoot
    {
        public List<Badge> Badges { get; set; }
        public bool HasMore { get; set; }
        public int QuotaMax { get; set; }
        public int QuotaRemaining { get; set; }
    }
}
