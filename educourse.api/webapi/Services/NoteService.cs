

using webapi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using System.Security.Claims;

namespace webapi.Services
{
    public class NoteService
    {
        private readonly IMongoCollection<Note> _notes;

        public NoteService(INotesDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _notes = database.GetCollection<Note>(settings.NotesCollectionName);
        }

        public List<Note> Get() =>
            _notes.Find(note => true).ToList();

        
        public Note Get(string id) =>
        _notes.Find<Note>(note => note.Id == id).FirstOrDefault();
       
       
        public List<Note> MailGet(string email)
        {
            
            return _notes.Find(note => note.Email == email).ToList();
             
        } 
       
       

        public Note Create(Note note)
        {
            _notes.InsertOne(note);
            return note;
        }

        public void Update(string id, Note bookIn) =>
            _notes.ReplaceOne(note => note.Id == id, bookIn);

        public void Remove(Note bookIn) =>
            _notes.DeleteOne(note => note.Id == bookIn.Id);

        public void Remove(string id) =>
            _notes.DeleteOne(note => note.Id == id);
    }
}