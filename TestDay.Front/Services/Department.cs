using System.Collections.Generic;

namespace TestDay.Front.Services
{
    public class IDepartment
    {
        public string id { get; set; }
        public string Name { get; set; }

        public List<string> beds_ids { get; set; }
    }
}