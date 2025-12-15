using Microsoft.AspNetCore.SignalR;

namespace campo_santo_service.API.Hubs
{
    public class EspaciosHub : Hub
    {
        // Método opcional que los clientes pueden llamar
        public async Task Saludar(string nombre)
        {
            await Clients.All.SendAsync("RecibirSaludo", $"Hola {nombre}");
        }
    }
}
