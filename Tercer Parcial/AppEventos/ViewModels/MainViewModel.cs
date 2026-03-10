using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using AppEventos.Models;
using AppEventos.Services;

namespace AppEventos.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Partido> Partidos { get; set; } = new();
        private ApiService _apiServices = new();

        public async Task CargaPartidos()
        {
            var lista = await _apiServices.ObtenerPartidosAsync();
            Partidos.Clear();

            foreach(var partido in lista)
            {
                Partidos.Add(partido);
            }
        }
    }
}
