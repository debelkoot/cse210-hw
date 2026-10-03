using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            // I created a list to store multiple YouTube videos.
            List<Video> videos = new List<Video>();
            // First video
            Video video1 = new Video(
                "C# Object-Oriented Programming Fundamentals",
                "TechWithTim",
                600);
            video1.AddComment(new Comment(
                "Alice",
                "This explanation helped me understand abstraction and encapsulation better."));
            video1.AddComment(new Comment(
                "Bob",
                "The examples made the class relationships easier to understand."));
            video1.AddComment(new Comment(
                "Charlie",
                "I would like to learn more about inheritance in the next lesson."));
            videos.Add(video1);
            // Second video
            Video video2 = new Video(
                "Useful VS Code Extensions for C# Developers",
                "CodeMaze",
                450);
            video2.AddComment(new Comment(
                "David",
                "These extensions improved my coding experience."));
            video2.AddComment(new Comment(
                "Eva",
                "Thank you for sharing these helpful tools."));
            video2.AddComment(new Comment(
                "Frank",
                "The explanation was simple and easy to follow."));
            video2.AddComment(new Comment(
                "Grace",
                "I installed these extensions after watching this video."));
            videos.Add(video2);
            // Third video
            Video video3 = new Video(
                "Building Web Applications with ASP.NET Core",
                "DevSolutions",
                1200);
            video3.AddComment(new Comment(
                "Hannah",
                "The explanation of dependency injection was very helpful."));
            video3.AddComment(new Comment(
                "Ian",
                "This is a great tutorial for beginners."));
            video3.AddComment(new Comment(
                "Jack",
                "I learned a lot about building web applications."));
            videos.Add(video3);
            // Fourth video
            Video video4 = new Video(
                "Learn Git and GitHub Basics",
                "GitMastery",
                1200);
            video4.AddComment(new Comment(
                "Karen",
                "I finally understand the difference between merge and rebase."));
            video4.AddComment(new Comment(
                "Leo",
                "The video was short and easy to understand."));
            video4.AddComment(new Comment(
                "Mia",
                "I will use these Git skills in my future projects."));
            videos.Add(video4);
            // Display information for every video in the list.
            foreach (Video video in videos)
            {
                video.DisplayVideoInfo();
            }
        }
    }
}
