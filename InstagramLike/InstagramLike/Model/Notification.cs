namespace InstagramLike.Model
{
    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        public string UserImage { get; set; }
    }
}
