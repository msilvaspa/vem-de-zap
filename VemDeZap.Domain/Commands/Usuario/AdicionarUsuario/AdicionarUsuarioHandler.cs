using System.Threading;
using System.Threading.Tasks;
using MediatR;
using prmToolkit.NotificationPattern;
using VemDeZap.Domain.Interfaces.Repositories;

namespace VemDeZap.Domain.Commands.Usuario.AdicionarUsuario
{
    public class AdicionarUsuarioHandler : Notifiable, IRequestHandler<AdicionarUsuarioRequest, Response>
    {
        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly IMediator _mediator;

        public AdicionarUsuarioHandler(IRepositoryUsuario repositoryUsuario, IMediator mediator)
        {
            _repositoryUsuario = repositoryUsuario;
            _mediator = mediator;
        }

        public async Task<Response> Handle(AdicionarUsuarioRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                AddNotification("Request", "Informe os dados do usuário");
                return new Response(this);
            }

            if (_repositoryUsuario.Existe(x => x.Email == request.Email))
            {
                AddNotification("Email", "Email já cadastrado no sistema.");
            }

            var usuario = new Entities.Usuario(request.PrimeiroNome, request.UltimoNome, request.Email, request.Senha);
            AddNotifications(usuario);
            if (IsInvalid())
            {
                return new Response(this);
            }

            usuario = _repositoryUsuario.Adicionar(usuario);

            var response = new Response(this, usuario);

            var adicionarUsuarioNotification = new AdicionarUsuarioNotification(usuario);

            await _mediator.Publish(adicionarUsuarioNotification);

            return await Task.FromResult(response);
        }
    }
}