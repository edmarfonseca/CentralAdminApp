using CentralAdminApp.Domain.Dtos;
using CentralAdminApp.Domain.Entities;
using CentralAdminApp.Domain.Helpers;
using CentralAdminApp.Domain.Interfaces.Repositories;
using CentralAdminApp.Domain.Interfaces.Services;
using CentralAdminApp.Domain.Validations;
using FluentValidation;

namespace CentralAdminApp.Domain.Services
{
    public class UfService : IUfService
    {
        private readonly IUfRepository _ufRepository;

        public UfService(IUfRepository ufRepository)
        {
            _ufRepository = ufRepository;
        }

        public UfResponse Add(UfRequest dto)
        {
            var uf = new Uf
            {
                Id = GenerateIdHelper.NewIdFromGuid(),
                Sigla = dto.Sigla,
                Descricao = dto.Descricao,
                DataInclusao = DateTime.Now,
                DataAlteracao = DateTime.Now,
                Ativo = true
            };

            var validator = new UfValidator();
            var result = validator.Validate(uf);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            if (_ufRepository.Verify(uf.Sigla, uf.Id))
                throw new ApplicationException("A sigla informada já está cadastrada para outra UF.");

            _ufRepository.Add(uf);

            return GetResponse(uf);
        }

        public UfResponse Update(int id, UfRequest dto)
        {
            var uf = _ufRepository.Get(id);

            if (uf == null)
                throw new ApplicationException("UF não encontrada.");

            uf.Sigla = dto.Sigla;
            uf.Descricao = dto.Descricao;
            uf.DataAlteracao = DateTime.Now;

            var validator = new UfValidator();
            var result = validator.Validate(uf);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            if (_ufRepository.Verify(uf.Sigla, uf.Id))
                throw new ApplicationException("A sigla informada já está cadastrada para outra UF.");

            _ufRepository.Update(uf);

            return GetResponse(uf);
        }

        public UfResponse Delete(int id)
        {
            var uf = _ufRepository.Get(id);

            if (uf == null)
                throw new ApplicationException("UF não encontrada.");
           
            uf.Ativo = false;
            uf.DataAlteracao = DateTime.Now;
            
            _ufRepository.Delete(uf);

            return GetResponse(uf);
        }

        public List<UfResponse> Get()
        {
            var response = new List<UfResponse>();

            var ufs = _ufRepository.Get();

            foreach (var uf in ufs)
            {
                response.Add(GetResponse(uf));
            }

            return response;
        }

        public UfResponse Get(int id)
        {
            var uf = _ufRepository.Get(id);

            if (uf == null)
                throw new ApplicationException("UF não encontrada.");

            return GetResponse(uf);
        }

        public UfResponse GetResponse(Uf uf)
        {
            return new UfResponse
            {
                Id = uf.Id,
                Sigla = uf.Sigla,
                Descricao = uf.Descricao,
                DataInclusao = uf.DataInclusao,
                DataAlteracao = uf.DataAlteracao
            };
        }
    }
}