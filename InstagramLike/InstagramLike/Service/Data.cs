using InstagramLike.Model;

using System.Collections.Generic;
using System.Linq;

namespace InstagramLike.Service
{
    public class Data
    {

        public static IEnumerable<User> GetUsers()
        {
            return new User[]
            {
                new User{Id=1, Name="Jenny", Description="She loves IT", ImageUrl="https://placeimg.com/100/100/people/0"},
                new User{Id=2, Name="Lucy", Description="She loves it", ImageUrl="https://placeimg.com/100/100/people/1"},
                new User{Id=3, Name="Mark", Description="He loves Photography", ImageUrl="https://placeimg.com/100/100/people/2"},
                new User{Id=4, Name="Patrick", Description="He loves IT", ImageUrl="https://placeimg.com/100/100/people/3"},
                new User{Id=5, Name="Jeffrey", Description="He loves Music", ImageUrl="https://placeimg.com/100/100/people/4"}
            };
        }

        public static IEnumerable<Notification> GetNotifications()
        {
            return new Notification[]
            {
                new Notification
                {
                    Id=1, Message="Event 1 happened",
                    UserId=1, UserImage="https://placeimg.com/100/100/people/0"
                },
                new Notification
                {
                    Id=2, Message="Event 2 happened",
                    UserId=2, UserImage="https://placeimg.com/100/100/people/1"
                },
                new Notification
                {
                    Id=3, Message="Event 3 happened",
                    UserId=3, UserImage="https://placeimg.com/100/100/people/2"
                },
                new Notification
                {
                    Id=4, Message="Event 4 happened",
                    UserId=4, UserImage="https://placeimg.com/100/100/people/3"
                },
                new Notification
                {
                    Id=5, Message="Event 5 happened",
                    UserId=5, UserImage="https://placeimg.com/100/100/people/4"
                },
            };
        }
        public static User GetUser(User user) => GetUsers().SingleOrDefault(u => u.Id == user.Id);

        public static User GetUserById(int id) => GetUsers().SingleOrDefault(u => u.Id == id);

        public static User GetMyProfile()
        {
            return new User
            {
                Id = 100,
                Name = "Myself",
                Description = "I am the user of this app connected to my own account",
                ImageUrl = "https://placeimg.com/100/100/people/10"
            };
        }

        public object GetUserInfoForNotifs(int userId)
        {
            var u = GetUserById(userId);

            return new { UserId = u.Id, UserImage = u.ImageUrl };
        }
    }
}
