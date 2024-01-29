using Microsoft.AspNetCore.SignalR;
using SignalIR.DataAccessLayer.Concrete;

namespace SignalIRApi.Hubs
{
    public class SignalRHub:Hub
    {
        SignalIRContext context = new SignalIRContext();

        public async Task SendCategoryCount()
        {
            var value = context.Categories.Count();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);
        }
    }
}
