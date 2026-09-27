using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");
    }
}
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("C# Abstraction Explained in 10 Minutes", "Code Academy", 600);
        video1.AddComment(new Comment("Alice", "Great explanation of classes!"));
        video1.AddComment(new Comment("Bob", "This made abstraction so easy to understand."));
        video1.AddComment(new Comment("Charlie", "Thanks for the clear code examples!"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Top 10 VS Code Shortcuts Every Developer Needs", "DevTips", 420);
        video2.AddComment(new Comment("Diana", "The Ctrl+D trick saved me hours!"));
        video2.AddComment(new Comment("Ethan", "Super helpful video, subscribed!"));
        video2.AddComment(new Comment("Fiona", "I had no idea shortcut #4 existed."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Build a Web App with HTML, CSS & JavaScript", "Tech With Tim", 1200);
        video3.AddComment(new Comment("George", "Awesome project! Everything worked smoothly."));
        video3.AddComment(new Comment("Hannah", "Can you make a part 2 with backend database integration?"));
        video3.AddComment(new Comment("Ian", "Best tutorial I've found all week."));
        video3.AddComment(new Comment("Julia", "Love the step-by-step breakdown."));
        videos.Add(video3);

        // Iterate through videos and display details
        foreach (Video video in videos)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine($"Title:              {video.Title}");
            Console.WriteLine($"Author:             {video.Author}");
            Console.WriteLine($"Length (seconds):   {video.LengthInSeconds}");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.Name}: \"{comment.Text}\"");
            }

            Console.WriteLine();
        }
    }
}
