using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace VemDeZap.Domain.Commands.Usuario.AdicionarUsuario.Notifications
{
    public class EnviarEmailDeAtivacaoDoUsuario : INotificationHandler<AdicionarUsuarioNotification>
    {
        public async Task Handle(AdicionarUsuarioNotification notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine("enviar email para o usuario" + notification.Usuario.PrimeiroNome);
        }
    }
}