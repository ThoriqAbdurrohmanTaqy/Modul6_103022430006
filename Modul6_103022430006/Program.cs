using System;
using System.Security.Cryptography.X509Certificates;

namespace Modul6_103022430006
{
    class SayaMusicUser
    {
        private int id;
        public string Username { get; set; }
        private List<SayaMusicTrack> uploadedTracks;
        public SayaMusicUser(string username)
        {
            this.id = new Random().Next(10000, 99999);
            this.Username = username;
            this.uploadedTracks = new List<SayaMusicTrack>();
        }
        public int GetTotalPlayCount()
        {
            int totalPlayCount = 0;
            foreach (var track in uploadedTracks)
            {
                totalPlayCount += track.PlayCount;
            }
            return totalPlayCount;
        }
        public void AddTrack(SayaMusicTrack track)
        {
            uploadedTracks.Add(track);
        }
        public void PrintAllTracks()
        {
            Console.WriteLine($"User: {Username}");
            for (int i = 0; i < uploadedTracks.Count; i++)
            {
                Console.WriteLine($"Track {i + 1} judul: {uploadedTracks[i].Title}");
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
        }
        public void IncreasePlayCount(int count)
        {
            PlayCount += count;
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
                SayaMusicUser user1 = new SayaMusicUser("Thoriq Abdurrohman Taqy");
                SayaMusicTrack track1 = new SayaMusicTrack("Genjer-genjer");
                SayaMusicTrack track2 = new SayaMusicTrack("kunfu panda");
                user1.AddTrack(track1);
                user1.AddTrack(track2);
                track1.IncreasePlayCount(150);
                track2.IncreasePlayCount(200);
                user1.PrintAllTracks();
                Console.WriteLine($"Total Play Count for {user1.Username}: {user1.GetTotalPlayCount()}");



        }


    }

}