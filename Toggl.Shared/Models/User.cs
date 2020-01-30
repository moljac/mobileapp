using System;

namespace Toggl.Shared.Models.DoNotUse
{
    public sealed class User
    {
        public long Id { get; }
        public string ApiToken { get; }
        public Workspace? DefaultWorkspace { get; }
        public Email Email { get; }
        public string Fullname { get; }
        public BeginningOfWeek BeginningOfWeek { get; }
        public string Language { get; }
        public string ImageUrl { get; }
        public string Timezone { get; }
        public DateTimeOffset At { get; }

        public User(
            long id,
            string apiToken,
            Workspace? defaultWorkspace,
            Email email,
            string fullname,
            BeginningOfWeek beginningOfWeek,
            string language,
            string imageUrl,
            string timezone,
            DateTimeOffset at)
        {
            Id = id;
            ApiToken = apiToken;
            DefaultWorkspace = defaultWorkspace;
            Email = email;
            Fullname = fullname;
            BeginningOfWeek = beginningOfWeek;
            Language = language;
            ImageUrl = imageUrl;
            Timezone = timezone;
            At = at;
        }
    }
}
