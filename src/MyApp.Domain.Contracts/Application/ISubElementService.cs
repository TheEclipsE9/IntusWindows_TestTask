﻿using MyApp.Domain.Contracts.DTOs.SubElement;
using MyApp.Domain.Entities;

namespace MyApp.Domain.Contracts.Application
{
    public interface ISubElementService
    {
        SubElementDTO Get(int id);

        void Create(CreateSubElementDTO subElement);

        void Update(int id, UpdateSubElementDTO subElement);

        void Delete(int id);
    }
}
