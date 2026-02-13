using MediatR;
using System;

namespace FinanceApi.Application.UseCases.Wallets.CreateWallet
{
    // IRequest<Guid> significa: "Eu sou um pedido que, quando terminar, devolve um GUID (o ID da carteira)"
    public class CreateWalletCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; } // Quem é o dono?
        public string Currency { get; set; } = "BRL"; // Qual a moeda? (Padrão Real)
    }
}