using System.Text;

namespace MusicHub
{
    using System;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();
                DbInitializer.ResetDatabase(context);

                Console.WriteLine(ExportSongsAboveDuration(context,4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Producers.First(p => p.Id == producerId).Albums
                .Select(a => new
                {
                    AlbumName=a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    AlbumPrice=a.Price,
                    Songs = a.Songs.Select(s => new
                    {
                        SongName=s.Name,
                        SongPrice = $"{s.Price:f2}",
                        SongWriterName = s.Writer.Name
                    })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.SongWriterName)
                })
                .OrderByDescending(a => a.AlbumPrice).ToList();


            StringBuilder result = new StringBuilder();

            foreach (var a in albums)
            {
                result.AppendLine($"-AlbumName: {a.AlbumName}");
                result.AppendLine($"-ReleaseDate: {a.ReleaseDate}");
                result.AppendLine($"-ProducerName: {a.ProducerName}");
                result.AppendLine("-Songs:");

                if (a.Songs.Any())
                {
                    int c = 1;
                    foreach (var s in a.Songs)
                    {
                        result.AppendLine($"---#{c++}");
                        result.AppendLine($"---SongName: {s.SongName}");
                        result.AppendLine($"---Price: {s.SongPrice}");
                        result.AppendLine($"---Writer: {s.SongWriterName}");
                    }
                }

                result.AppendLine($"-AlbumPrice: {a.AlbumPrice:f2}");

            }

            return result.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songsAboveDuration = context.Songs
                .AsEnumerable()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    SongName = s.Name,
                    SongWriterName = s.Writer.Name,
                    SongPerformers = s.SongPerformers.Select(p => $"{p.Performer.FirstName} {p.Performer.LastName}").OrderBy(x=>x).ToList(),
                    AlbumProducerName = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s=>s.SongName)
                .ThenBy(s=>s.SongWriterName)
                .ToList();

            StringBuilder result = new StringBuilder();

            int counter = 1;
            foreach (var s in songsAboveDuration)
            {
                result.AppendLine($"-Song #{counter++}");
                result.AppendLine($"---SongName: {s.SongName}");
                result.AppendLine($"---Writer: {s.SongWriterName}");

                if (s.SongPerformers.Any())
                {
                    foreach (var p in s.SongPerformers)
                    {
                        result.AppendLine($"---Performer: {p}");
                    }
                }
                
                result.AppendLine($"---AlbumProducer: {s.AlbumProducerName}");
                result.AppendLine($"---Duration: {s.Duration}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
