using System;
using System.Threading;
using System.Threading.Tasks;
using FinanceApi.Domain.Entities;
using FinanceApi.Domain.Interfaces;
using MediatR;

namespace FinanceApi.Application.UseCases.Wallets.CreateWallet
{
    public class CreateWalletHandler : IRequestHandler<CreateWalletCommand, Guid>
    {
        private readonly IWalletRepository _repository;

        public CreateWalletHandler(IWalletRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
        {
            // 1. Cria a Entidade (A regra de negócio 'Nasce com saldo zero' está lá dentro)
            var wallet = new Wallet(request.Currency);

            // Aqui poderíamos validar se o usuário existe, etc.

            // 2. Persiste no Banco via Repositório
            await _repository.AddAsync(wallet, cancellationToken);

            // 3. Retorna o ID gerado para quem chamou
            return wallet.Id;
        }
    }
}