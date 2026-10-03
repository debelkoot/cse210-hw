using System;

namespace YouTubeVideos
{
    // This class represents a single comment made by a user on a video.
    public class Comment
    {
        private string _commenterName;
        private string _commentText;
        // Constructor to create a comment with a person's name and message.
        public Comment(string commenterName, string commentText)
        {
            _commenterName = commenterName;
            _commentText = commentText;
        }
        // Returns the name of the person who wrote the comment.
        public string GetCommenterName()
        {
            return _commenterName;
        }
        // Returns the comment message.
        public string GetCommentText()
        {
            return _commentText;
        }
        // Displays the comment in a simple format.
        public void DisplayComment()
        {
            Console.WriteLine($"  - {_commenterName}: \"{_commentText}\"");
        }
    }
}
