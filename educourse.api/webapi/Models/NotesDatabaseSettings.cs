
namespace webapi.Models
{
    public class NotesDatabaseSettings : INotesDatabaseSettings
    {
        public string NotesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface INotesDatabaseSettings
    {
        string NotesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
