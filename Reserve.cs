namespace api_net
{
    public class Reserve
    {
        public int id { get; set; }
        public string dateIn { get; set; } = string.Empty;
        public string dateOut { get; set; } = string.Empty;
        public string allDates { get; set; } = string.Empty;
        public string roomName { get; set; } = string.Empty;
        public int personsCount { get; set; } = 0;
        public string animals { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
    }
}
