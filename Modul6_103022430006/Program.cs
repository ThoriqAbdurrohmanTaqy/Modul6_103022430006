using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System;

namespace Modul6_103022430006
{
    class SayaMusicUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        private List<SayaMusicTrack> tracks;
        public SayaMusicUser(string username)
        {
            if (string.IsNullOrEmpty(username) || username.Length > 100)
            {
                throw new ArgumentException("Username must be non-null and have a maximum length of 100 characters.");
            }
            this.Id = new Random().Next(10000, 99999);
            this.Username = username;
            this.tracks = new List<SayaMusicTrack>();
        }
        public void AddTrack(SayaMusicTrack track)
        {
            if (track == null)
            {
                throw new ArgumentException("Track cannot be null.");
            }
            if (track.PlayCount >= int.MaxValue)
            {
                throw new ArgumentException("Track play count must be less than the maximum integer value.");
            }
            tracks.Add(track);
        }
        public void PrintAllTracks()
        {
            int maxprint = tracks.Count > 8 ? 8 : tracks.Count;
            Console.WriteLine($"User: {Username} (ID: {Id})");
            foreach (var track in tracks.Take(maxprint))
            {
                track.PrintTrackDetails();
            }

        
        }
    }
    
    

    class SayaMusicTrack
    {
        private int id;
        public string Title { get; set; }
        public int PlayCount { get; private set; }
        public SayaMusicTrack(string title)
        {
            this.id = new Random().Next(10000, 99999);
            this.Title = title;
            this.PlayCount = 0;
            if (title == null || title.Length > 200)
            {
                throw new ArgumentException("Track title must be non-null and have a maximum length of 200 characters.");
            }
        }

        public void IncreasePlayCount(int count)
        {
            PlayCount += count;
            if (count > 25000000)
            {
                throw new ArgumentException("Play count increase must not exceed 25,000,000.");
            }

            if (count < 0)
            {
                throw new ArgumentException("Play count must not be negative.");
            }
            try
            {
                checked
                {
                    PlayCount += count;
                }

            }
            catch (OverflowException)
            {
                throw new ArgumentException("Play count increase would cause an overflow.");
            }

        }
        public void PrintTrackDetails()
        {
            Console.WriteLine($"Track ID: {id}, Title: {Title}, Play Count: {PlayCount}");
        }
    }

    class program
    {
        static void Main(string[] args)
        {
            try
            {
                SayaMusicUser user1 = new SayaMusicUser("Thoriq Abdurrohman Taqy");
                SayaMusicTrack track1 = new SayaMusicTrack("Genjer-genjer");
                SayaMusicTrack track2 = new SayaMusicTrack("kunfu panda");
                user1.AddTrack(track1);
                user1.AddTrack(track2);
                track1.IncreasePlayCount(150);
                track2.IncreasePlayCount(200);
                user1.PrintAllTracks();
                SayaMusicTrack overflowtest = new SayaMusicTrack("Overflow Test");
                Console.WriteLine($"Total Play Count for '{overflowtest.Title}' before overflow test: {overflowtest.PlayCount}");
                Console.Write(overflowtest.ToString());
                Console.WriteLine();

                for (int i = 0; i < 100; i++)
                {
                    overflowtest.IncreasePlayCount(int.MaxValue);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }


    }

}