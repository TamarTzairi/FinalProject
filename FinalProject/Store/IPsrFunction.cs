﻿using FinalProject.DTO;

namespace FinalProject.Store
{
    public interface IPsrFunction
    {

        List<ProtectedSpaceRoom> Get();
        ProtectedSpaceRoom Get(string id);
        ProtectedSpaceRoom Create(ProtectedSpaceRoom psr);
        void Update(string id, ProtectedSpaceRoom psr);
        void Remove(string id);
    }
}
