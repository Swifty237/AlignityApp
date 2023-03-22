using System;

namespace AlignityApp.Models
{
    public class Observation
    {
        public int Id { get; set; }
        public int ObsCraId { get; set; }
        public Cra ObsCra { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public DateTime CreationDate { get; set; }
        public string Message { get; set; }
    }
}
