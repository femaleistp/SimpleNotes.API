using SimpleNotes.API.Models;
using System.Data;
namespace SimpleNotes.API.Interfaces
{
    public interface INoteService
    {
        IEnumerable<Note> GetAll(); //  Get all notes
        Note? GetById(int id);  // Get note by id
        Note Add(Note note); // Add a new note
        bool Update(Note note);  // 
        void Delete(int id); // Delete a note

    }
}
