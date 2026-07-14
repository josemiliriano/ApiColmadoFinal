using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contract
{
    public interface IProviderAppService
    {
        public CDProvider AddProvider(ProviderDto dto);
        public List<CDProvider> GetAllProvider();
        public CDProvider UpdateProvider(int id, ProviderDto dto);
        public CDProvider GetProviderById(int id);
        public void DeleteProvider(int id);
        public bool SoftDelete(int id);
        public List<CDProvider> GetProviderNotDeleted();
    }
}
