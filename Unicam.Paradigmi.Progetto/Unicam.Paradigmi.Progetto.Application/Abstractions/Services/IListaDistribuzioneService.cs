﻿using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Progetto.Application.Abstractions.Services
{
    public interface IListaDistribuzioneService
    {
        Task AddListaAsync(ListaDistribuzione lista);
    }
}