using SimpleNotes.API.Interfaces;
using SimpleNotes.API.Models;

namespace SimpleNotes.API.Services
{
    public class NoteService : INoteService
    {
        private readonly List<Note> _notes = new List<Note>();
        private int _nextId = 1; // To keep track of the next ID to assign
        public IEnumerable<Note> GetAll()
        {
            return _notes;
        }
        public Note? GetById(int id)
        {
            return _notes.FirstOrDefault(n => n.Id == id);
        }

        public Note Add(Note note)
        {
            note.Id = _nextId++;
            _notes.Add(note);
            return note;
        }

        public bool Update(Note note)
        {
            var existingNote = GetById(note.Id);
            if (existingNote != null)
            {
                existingNote.Content = note.Content;
                return true;
            }

            return false;
        }

        public void Delete(int id)
        {
            var note = GetById(id);
            if (note != null)
            {
                _notes.Remove(note);
            }
        }
    }
}
