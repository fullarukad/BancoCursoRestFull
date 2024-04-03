using Application.DTOs;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace Application.Feautres.Clientes.Queries.GetAllClientes
{
    public class GetAllClientesQuery : IRequest<PagedResponse<List<ClienteDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public class GetAllClientesQueryHandler : IRequestHandler<GetAllClientesQuery, PagedResponse<List<ClienteDto>>>
        {
            private readonly IRepositoryAsync<Cliente> _repositoryAsync;
            private readonly IMapper _mapper;
            private readonly IDistributedCache _distrbutedCache;

            public GetAllClientesQueryHandler(IRepositoryAsync<Cliente> repositoryAsync, IMapper mapper, IDistributedCache distrbutedCache)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
                _distrbutedCache = distrbutedCache;
            }
            public async Task<PagedResponse<List<ClienteDto>>> Handle(GetAllClientesQuery request, CancellationToken cancellationToken)
            {
                var cacheKey = $"listadoClientes_{request.PageSize}_{request.PageNumber}_{request.Apellido}";
                string serializedListadoCLientes;
                var listadoClientes = new List<Cliente>();
                var redisListadoClientes = await _distrbutedCache.GetAsync(cacheKey);

                if (redisListadoClientes != null)
                {
                    serializedListadoCLientes = Encoding.UTF8.GetString(redisListadoClientes);
                    listadoClientes = JsonConvert.DeserializeObject<List<Cliente>>(serializedListadoCLientes);
                }
                else
                {
                    listadoClientes = await _repositoryAsync.ListAsync(new PagedClientesSpecifications(request.PageSize, request.PageNumber, request.Nombre, request.Apellido));
                    serializedListadoCLientes = JsonConvert.SerializeObject(listadoClientes);
                    redisListadoClientes = Encoding.UTF8.GetBytes(serializedListadoCLientes);

                    var options = new DistributedCacheEntryOptions()
                        .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                        .SetSlidingExpiration(TimeSpan.FromMinutes(2));

                    await _distrbutedCache.SetAsync(cacheKey, redisListadoClientes, options);
                }                
                var clientesDto = _mapper.Map<List<ClienteDto>>(listadoClientes);

                return new PagedResponse<List<ClienteDto>>(clientesDto,request.PageNumber,request.PageSize);
            }
        }
    }
}
