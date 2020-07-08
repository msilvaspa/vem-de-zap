using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace VemDeZap.Domain.Commands.Usuario.AdicionarUsuario.Notifications
{
    public class AvisarAdministradores : INotificationHandler<AdicionarUsuarioNotification>
    {
        public async Task Handle(AdicionarUsuarioNotification notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Chamar o webservice que avisa usuario cadastrado " + notification.Usuario.PrimeiroNome);
        }
    }
}