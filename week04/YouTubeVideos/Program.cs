
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store the videos.
        List<Video> videos = new List<Video>();

        // First video
        Video video1 = new Video(
            "How to Stay Productive Every Day",
            "John Smith",
            600
        );

        video1.AddComment(new Comment("Mary", "This video is very helpful!"));
        video1.AddComment(new Comment("David", "I learned something new today."));
        video1.AddComment(new Comment("Grace", "Thanks for sharing these tips."));
        video1.AddComment(new Comment("Peter", "I will try these ideas."));

        videos.Add(video1);

        // Second video
        Video video2 = new Video(
            "Top 5 Travel Destinations in Africa",
            "Travel With Alex",
            850
        );

        video2.AddComment(new Comment("Sarah", "Africa has beautiful places."));
        video2.AddComment(new Comment("James", "Nigeria should be on this list."));
        video2.AddComment(new Comment("Linda", "I would love to visit Kenya."));
        
        videos.Add(video2);

        // Third video
        Video video3 = new Video(
            "Learn C# Programming for Beginners",
            "Code Academy",
            1200
        );

        video3.AddComment(new Comment("Michael", "This explanation is easy to understand."));
        video3.AddComment(new Comment("Angela", "I am learning C# now."));
        video3.AddComment(new Comment("Daniel", "Please make more tutorials."));
        video3.AddComment(new Comment("Faith", "Very useful lesson!"));

        videos.Add(video3);

        // Fourth video
        Video video4 = new Video(
            "Healthy Meals You Can Make at Home",
            "Healthy Living",
            720
        );

        video4.AddComment(new Comment("Emma", "These recipes look delicious."));
        video4.AddComment(new Comment("Chris", "I will try the first recipe."));
        video4.AddComment(new Comment("Ruth", "Thank you for the healthy ideas."));

        videos.Add(video4);

        // Display all videos and their comments.
        Console.WriteLine("          YOUTUBE VIDEO TRACKER");
        Console.WriteLine();

        foreach (Video video in videos)
        {
            video.Display();
        }

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("End of YouTube Video Tracker.");
    }
}
