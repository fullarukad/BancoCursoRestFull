using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Feautres.Clientes.Queries.GetClienteById
{
    public class GetClienteByIdQuery : IRequest<Response<ClienteDto>>
    {
        public int Id { get; set; }
        public class GetClienteByIdQueryHandler : IRequestHandler<GetClienteByIdQuery, Response<ClienteDto>>
        {
            private readonly IRepositoryAsync<Cliente> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetClienteByIdQueryHandler(IRepositoryAsync<Cliente> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<ClienteDto>> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
            {
                var cliente = await _repositoryAsync.GetByIdAsync(request.Id);

                if (cliente == null)
                {
                    throw new KeyNotFoundException($"Registro no encontrado con el ID {request.Id}");
                }
                else
                {
                    var dto = _mapper.Map<ClienteDto>(cliente);
                    return new Response<ClienteDto>(dto);
                }
            }
        }
    }
}
