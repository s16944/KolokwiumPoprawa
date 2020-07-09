using System.Collections.Generic;

namespace KolokwiumPoprawa.Models
{
    public class City
    {
        public int IdCity { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
    }
}