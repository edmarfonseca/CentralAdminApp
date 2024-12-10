using CentralAdminApp.Domain.Dtos;
using CentralAdminApp.Domain.Entities;
using CentralAdminApp.Domain.Interfaces.Repositories;
using CentralAdminApp.Domain.Interfaces.Services;
using CentralAdminApp.Domain.Validations;
using FluentValidation;

namespace CentralAdminApp.Domain.Services
{
    public class SistemaService : ISistemaService
    {
        private readonly ISistemaRepository _sistemaRepository;

        public SistemaService(ISistemaRepository sistemaRepository)
        {
            _sistemaRepository = sistemaRepository;
        }

        public SistemaResponse Add(SistemaRequest dto)
        {
            var sistema = new Sistema
            {
                Nome = dto.Nome,
                Codigo = dto.Codigo,
                Url = dto.Url,
                DataInclusao = DateTime.Now,
                DataAlteracao = DateTime.Now,
                Ativo = true
            };

            var validator = new SistemaValidator();
            var result = validator.Validate(sistema);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            if (_sistemaRepository.Verify(dto.Codigo, sistema.Id))
                throw new ApplicationException("O código informado já está cadastrado para outro sistema.");

            _sistemaRepository.Add(sistema);

            return new SistemaResponse
            {
                Id = sistema.Id,
                Nome = sistema.Nome,
                Codigo = sistema.Codigo,
                Url = sistema.Url,
                DataInclusao = sistema.DataInclusao,
                DataAlteracao = sistema.DataAlteracao
            };
        }

        public SistemaResponse Update(int id, SistemaRequest dto)
        {
            var sistema = _sistemaRepository.Get(id);

            if (sistema == null)
                throw new ApplicationException("Sistema não encontrado, verifique o ID informado.");

            sistema.Nome = dto.Nome;
            sistema.Codigo = dto.Codigo;
            sistema.Url = dto.Url;
            sistema.DataAlteracao = DateTime.Now;

            var validator = new SistemaValidator();
            var result = validator.Validate(sistema);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            if (_sistemaRepository.Verify(dto.Codigo, sistema.Id))
                throw new ApplicationException("O código informado já está cadastrado para outro sistema.");

            _sistemaRepository.Update(sistema);

            return new SistemaResponse
            {
                Id = sistema.Id,
                Nome = sistema.Nome,
                Codigo = sistema.Codigo,
                Url = sistema.Url,
                DataInclusao = sistema.DataInclusao,
                DataAlteracao = sistema.DataAlteracao
            };
        }

        public SistemaResponse Delete(int id)
        {
            var sistema = _sistemaRepository.Get(id);

            if (sistema == null)
                throw new ApplicationException("Sistema não encontrado, verifique o ID informado.");

            sistema.Ativo = false;
            sistema.DataAlteracao = DateTime.Now;

            _sistemaRepository.Delete(sistema);

            return new SistemaResponse
            {
                Id = sistema.Id,
                Nome = sistema.Nome,
                Codigo = sistema.Codigo,
                Url = sistema.Url,
                DataInclusao = sistema.DataInclusao,
                DataAlteracao = sistema.DataAlteracao
            };
        }

        public List<SistemaResponse> Get()
        {
            var response = new List<SistemaResponse>();

            var sistemas = _sistemaRepository.Get();

            foreach (var item in sistemas)
            {
                response.Add(new SistemaResponse
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Codigo = item.Codigo,
                    Url = item.Url,
                    DataInclusao = item.DataInclusao,
                    DataAlteracao = item.DataAlteracao
                });
            }

            return response;
        }

        public SistemaResponse Get(int id)
        {
            var sistema = _sistemaRepository.Get(id);

            if (sistema == null)
                throw new ApplicationException("Sistema não encontrado, verifique o ID informado.");

            return new SistemaResponse
            {
                Id = sistema.Id,
                Nome = sistema.Nome,
                Codigo = sistema.Codigo,
                Url = sistema.Url,
                DataInclusao = sistema.DataInclusao,
                DataAlteracao = sistema.DataAlteracao
            };
        }
    }
}