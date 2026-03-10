using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using AppEventos.Models;

namespace AppEventos.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        // Constructor
        public ApiService() 
        {
            _httpClient = new HttpClient();
        }

        public async Task <List<Partido>> ObtenerPartidosAsync()
        {
            var url = "https://www.scorebat.com/video-api/v3/free-feed/?token=MjIwMDMzXzE3NzMxMDM2NjFfYThiYjQ5NTM1ZWQzZDgzNDk1N2RjOTBlMmNkNDU2OTZlMTZkZWViNw==\r\n ";
            var respuesta = await _httpClient.GetFromJsonAsync<ApiResponse>(url);

            if (respuesta?.Response == null)
                return new List<Partido>();

            return respuesta.Response.Select(p => new Partido
            {
                Titulo = p.Title,
                Fecha = p.Date,
                Liga = p.Competition,
                Miniatura = p.Thumbnail,
                VideoURL = p.MatchViewURL,
            }).ToList();
        }

        private class ApiResponse
        {
            public List<MatchInfo> Response { get; set; }
        }

        private class MatchInfo
        {
            public string Title { get; set; }
            public string Date { get; set; }
            public string Competition { get; set; }
            public string Thumbnail { get; set; }
            public string MatchViewURL { get; set; }
        }
    }
}
