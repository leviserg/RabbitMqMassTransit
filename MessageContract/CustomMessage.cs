namespace MessageContract
{
    public class CustomMessage
    {
        public string Content { get; set; }
        public string Title { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedAtUtc { get; set; }

        public CustomMessage(string title)
        {
            Title = title;
            Id = new Guid();
            Content = GenerateRandomString(title.Length);
            CreatedAtUtc = DateTime.UtcNow;
        }

        public override string ToString()
        {
            return $"\t{Title} : \t{Content},\t {Id.ToString()}\t : {CreatedAtUtc.ToString("HH:mm:ss")}";
        }

        private static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
