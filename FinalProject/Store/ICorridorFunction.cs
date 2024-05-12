﻿using FinalProject.DTO;

namespace FinalProject.Store
{
    public interface ICorridorFunction
    {
        List<Corridor> Get();
        Corridor Get(string id);
        Corridor Create(Corridor corridor);
        void Update(string id, Corridor corridor);
        void Remove(string id);
    }
}
