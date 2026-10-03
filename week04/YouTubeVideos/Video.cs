using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    // This class represents a YouTube video and manages its comments.
    public class Video
    {
        private string _title;
        private string _author;
        private int _lengthInSeconds;
        private List<Comment> _comments;

        // Creates a video and starts with an empty comment list.
        public Video(string title, string author, int lengthInSeconds)
        {
            _title = title;
            _author = author;
            _lengthInSeconds = lengthInSeconds;
            _comments = new List<Comment>();
        }

        // Adds a new comment to the video.
        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        // Returns the number of comments currently stored for the video.
        public int GetNumberOfComments()
        {
            return _comments.Count;
        }

        // Displays all video information and related comments.
        public void DisplayVideoInfo()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine($"Title: {_title}");
            Console.WriteLine($"Author: {_author}");
            Console.WriteLine($"Length: {_lengthInSeconds} seconds");
            Console.WriteLine($"Comments: {GetNumberOfComments()}");
            Console.WriteLine("\nUser Comments:");
            foreach (Comment comment in _comments)
            {
                comment.DisplayComment();
            }
            Console.WriteLine("==============================================\n");
        }
    }
}
