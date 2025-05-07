using Microsoft.AspNetCore.Mvc.Testing;
using SimpleNotes.API.Models;
using System.Text;
using System.Text.Json;

namespace SimpleNotes.Tests
{
    public class NoteApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly WebApplicationFactory<Program> _factory;

        public NoteApiTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task Can_Create_And_Get_Note()
        {
            var noteJson = new StringContent(
                JsonSerializer.Serialize(new { Content = "Test Note" }),
                Encoding.UTF8,
                "application/json");



            // POST to create the note
            var createResponse = await _client.PostAsync("/api/Note", noteJson);
            createResponse.EnsureSuccessStatusCode();

            // GET all notes using the correct route
            var getResponse = await _client.GetAsync("/api/Note/GetAll");
            getResponse.EnsureSuccessStatusCode();

            // Deserialize the response
            var responseBody = await getResponse.Content.ReadAsStringAsync();
            var notes = JsonSerializer.Deserialize<List<Note>>(responseBody, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });


            // Assert the created note exists in the returned list
            Assert.Contains(notes, n => n.Content == "Test Note");
        }
    }
}

