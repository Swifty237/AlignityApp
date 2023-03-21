using System;

namespace AlignityApp.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int CommentedCraId { get; set; }
        public int CommentAuthorId { get; set; }
        public User CommentAuthor { get; set; }
        public DateTime CreationDate { get; set; }
        public string CommentItself { get; set; }
    }
}
