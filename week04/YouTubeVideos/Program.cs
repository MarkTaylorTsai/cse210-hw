using System;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Learning C#", "Mark", 420);
        video1.AddComment(new Comment("Amy", "Great video!"));
        video1.AddComment(new Comment("John", "Very helpful."));
        video1.AddComment(new Comment("Peter", "Thanks for sharing."));

        Video video2 = new Video("How to Build a Web App", "Sarah", 600);
        video2.AddComment(new Comment("Mike", "I learned a lot."));
        video2.AddComment(new Comment("Emma", "Nice explanation."));
        video2.AddComment(new Comment("David", "Can you make part 2?"));

        Video video3 = new Video("Object Oriented Programming", "Alex", 540);
        video3.AddComment(new Comment("Chris", "This made OOP easier."));
        video3.AddComment(new Comment("Anna", "Good examples."));
        video3.AddComment(new Comment("Tom", "Very clear lesson."));

        List<Video> videos = new List<Video>();

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}