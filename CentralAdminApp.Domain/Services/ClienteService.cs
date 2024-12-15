using CentralAdminApp.Domain.Dtos;
using CentralAdminApp.Domain.Entities;
using CentralAdminApp.Domain.Interfaces.Repositories;
using CentralAdminApp.Domain.Interfaces.Services;
using CentralAdminApp.Domain.Validations;
using FluentValidation;

namespace CentralAdminApp.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public ClienteResponse Add(ClienteRequest dto)
        {
            var cliente = new Cliente
            {
                Nome = dto.Nome,
                CpfCnpj = dto.CpfCnpj,
                Logradouro = dto.Logradouro,
                Numero = dto.Numero,
                Complemento = dto.Complemento,
                Bairro = dto.Bairro,
                Cidade = dto.Cidade,
                Uf = dto.Uf,
                Cep = dto.Cep,
                DataInclusao = DateTime.Now,
                DataAlteracao = DateTime.Now,
                Ativo = true
            };

            var validator = new ClienteValidator();
            var result = validator.Validate(cliente);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            if (dto.CpfCnpj.Length != 11 && dto.CpfCnpj.Length != 14)
                throw new ApplicationException("Não foi possível identificar se o cliente é Pessoa Física ou Jurídica. Verifique CPF/CNPJ informado.");

            if (_clienteRepository.Verify(dto.CpfCnpj, cliente.Id))
                throw new ApplicationException($"O {(dto.CpfCnpj.Length == 11 ? "CPF" : "CNPJ")} informado já está cadastrado para outro cliente.");

            _clienteRepository.Add(cliente);

            return GetResponse(cliente);
        }

        public ClienteResponse Update(int id, ClienteRequest dto)
        {
            var cliente = _clienteRepository.Get(id);

            if (cliente == null)
                throw new ApplicationException("Cliente não encontrado, verifique o ID informado.");

            cliente.Nome = dto.Nome;
            cliente.CpfCnpj = dto.CpfCnpj;
            cliente.Logradouro = dto.Logradouro;
            cliente.Numero = dto.Numero;
            cliente.Complemento = dto.Complemento;
            cliente.Bairro = dto.Bairro;
            cliente.Cidade = dto.Cidade;
            cliente.Uf = dto.Uf;
            cliente.Cep = dto.Cep;
            cliente.DataAlteracao = DateTime.Now;

            var validator = new ClienteValidator();
            var result = validator.Validate(cliente);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            if (dto.CpfCnpj.Length != 11 && dto.CpfCnpj.Length != 14)
                throw new ApplicationException("Não foi possível identificar se o cliente é Pessoa Física ou Jurídica. Verifique CPF/CNPJ informado.");

            if (_clienteRepository.Verify(dto.CpfCnpj, cliente.Id))
                throw new ApplicationException($"O {(dto.CpfCnpj.Length == 11 ? "CPF" : "CNPJ")} informado já está cadastrado para outro cliente.");

            _clienteRepository.Update(cliente);

            return GetResponse(cliente);
        }

        public ClienteResponse Delete(int id)
        {
            var cliente = _clienteRepository.Get(id);

            if (cliente == null)
                throw new ApplicationException("Cliente não encontrado, verifique o ID informado.");

            cliente.Ativo = false;
            cliente.DataAlteracao = DateTime.Now;

            _clienteRepository.Delete(cliente);

            return GetResponse(cliente);
        }

        public List<ClienteResponse> Get()
        {
            var response = new List<ClienteResponse>();

            var clientes = _clienteRepository.Get();

            foreach (var cliente in clientes)
            {
                response.Add(GetResponse(cliente));
            }

            return response;
        }

        public ClienteResponse Get(int id)
        {
            var cliente = _clienteRepository.Get(id);

            if (cliente == null)
                throw new ApplicationException("Cliente não encontrado, verifique o ID informado.");

            return GetResponse(cliente);
        }

        public ClienteResponse GetResponse(Cliente cliente)
        {
            return new ClienteResponse
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                CpfCnpj = cliente.CpfCnpj,
                Logradouro = cliente.Logradouro,
                Numero = cliente.Numero,
                Complemento = cliente.Complemento,
                Bairro = cliente.Bairro,
                Cidade = cliente.Cidade,
                Uf = cliente.Uf,
                Cep = cliente.Cep,
                DataInclusao = cliente.DataInclusao,
                DataAlteracao = cliente.DataAlteracao
            };
        }
    }
}