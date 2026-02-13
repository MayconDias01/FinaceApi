using FinanceApi.Application.UseCases.Wallets.CreateWallet;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinanceApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalletsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WalletsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWalletCommand command)
        {
            // Envia o comando para o MediatR achar o Handler
            var id = await _mediator.Send(command);

            // Retorna 201 Created com o ID da carteira
            return CreatedAtAction(nameof(Create), new { id }, new { id, command.Currency });
        }
    }
}