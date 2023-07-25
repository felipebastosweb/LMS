using SQLite;

namespace CasaDaAprendizagemApp.Data.Models
{
    public enum LessonType
    {
        TextContent = 1,
        VideoURL = 2,
        EmbebedVideo = 5,
        HTMLContent = 10,
        YoutubeVideo = 50
    }

    public class Lesson : BaseModel
    {
        [Indexed]
        public int LessonTypeId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }

    public class VideoYoutube : Lesson
    {

    }
}
