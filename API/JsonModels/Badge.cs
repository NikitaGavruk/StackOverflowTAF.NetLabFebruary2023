using System.Collections.Generic;

namespace API.Units {

    public class Item {
        public string badge_type { get; set; }
        public int award_count { get; set; }
        public string rank { get; set; }
        public int badge_id { get; set; }
        public string link { get; set; }
        public string name { get; set; }
    }
    public class Root {
        public List<Item> items { get; set; }
        public bool has_more { get; set; }
        public int quota_max { get; set; }
        public int quota_remaining { get; set; }
    }

}
