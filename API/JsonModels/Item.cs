using System.Collections.Generic;

namespace API.Units
{

    public class Item
    {
        public Item(string badge_type, int award_count, string rank, int badge_id, string link, string name)
        {
            this.badge_type = badge_type;
            this.award_count = award_count;
            this.rank = rank;
            this.badge_id = badge_id;
            this.link = link;
            this.name = name;
        }

        public string badge_type { get; set; }
        public int award_count { get; set; }
        public string rank { get; set; }
        public int badge_id { get; set; }
        public string link { get; set; }
        public string name { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Item item &&
                   badge_type == item.badge_type &&
                   award_count == item.award_count &&
                   rank == item.rank &&
                   badge_id == item.badge_id &&
                   link == item.link &&
                   name == item.name;
        }

        public override int GetHashCode()
        {
            int hashCode = 478854773;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(badge_type);
            hashCode = hashCode * -1521134295 + award_count.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(rank);
            hashCode = hashCode * -1521134295 + badge_id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(link);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            return hashCode;
        }
    }
    public class Root
    {
        public List<Item> items { get; set; }
        public bool has_more { get; set; }
        public int quota_max { get; set; }
        public int quota_remaining { get; set; }
    }

}
