﻿using MyApp.Domain.Contracts.DTOs.Window;
using MyApp.Domain.Entities;

namespace MyApp.Domain.Contracts.Application
{
    public interface IWindowService
    {
        WindowDTO Get(int id);

        List<WindowDTO> GetAllByOrderId(int orderId);

        WindowDTO Create(CreateWindowDTO windowDTO);

        WindowDTO Update(int id, UpdateWindowDTO windowDTO);

        void Delete(int id);
    }
}
