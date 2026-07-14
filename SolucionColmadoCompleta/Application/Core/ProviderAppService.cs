using Application.Contract;
using Application.DTOs;
using Domain.Entities;
using Infraestructure.Eceptions;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core
{
    public class ProviderAppService : IProviderAppService
    {
        private readonly GeneralRepository<CDProvider> _repository;
        public ProviderAppService(GeneralRepository<CDProvider> repository)
        {
            _repository = repository;
        }

        public CDProvider AddProvider(ProviderDto dto)
        {
            try
            {
                var exist = _repository.Exists(p => p.ProviderName.ToLower() == dto.ProviderName.ToLower());
                if (exist)
                {
                    throw new AlreadyExistsException("Proveedor", dto.ProviderName);
                }
                var NewProvider = new CDProvider
                {
                    ProviderName = dto.ProviderName,
                    ContactName = dto.ContactName,
                    Address = dto.Address,
                    City = dto.City,
                    Country = dto.Country,
                    Phone = dto.Phone
                };
                return _repository.Add(NewProvider);

            }
            catch (AlreadyExistsException e)
            {
                throw new(e.Message);
            }
        }

        public void DeleteProvider(int id)
        {
            var provider = _repository.GetById(id);
            if (provider != null)
            {
                _repository.Deleter(provider);
            }
        }

        public List<CDProvider> GetAllProvider()
        {
            return _repository.GetAll();
        }

        public CDProvider GetProviderById(int id)
        {
            return _repository.GetById(id);
        }

        public List<CDProvider> GetProviderNotDeleted()
        {
            return _repository.GetAll().Where(p => p.IsDelete == '0').ToList();
        }

        public bool SoftDelete(int id)
        {
            var provider = _repository.GetById(id);
            if (provider == null)
            {
                return false;
            }
            provider.IsDelete = '1';
            return true;
        }

        public CDProvider UpdateProvider(int id, ProviderDto dto)
        {
            var provider = _repository.GetById(id);
            if (provider != null)
            {
                provider.ProviderName = dto.ProviderName;
                provider.ContactName = dto.ContactName;
                provider.Address = dto.Address;
                provider.City = dto.City;
                provider.Country = dto.Country;
                provider.Phone = dto.Phone;
            }
            return provider;
        }
    }
}
