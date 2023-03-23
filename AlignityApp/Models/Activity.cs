using System;

namespace AlignityApp.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
		public int Duration { get; set; }
		public ActivityTypes Type { get; set; }
        public ActivityPlace Place { get; set; }
        public string Description { get; set; }
        public int CraId { get; set; }
        public virtual Cra Cra { get; set; }
    }

    public enum ActivityTypes
    {
        SERVICE,
        TRAINING,
        HOLIDAYS,
        RTT,
        INTERCONTRACT
    }

    public enum ActivityPlace
    {
        INTERNAL,
        EXTERNAL
    }
}
