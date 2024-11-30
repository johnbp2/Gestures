using Colore;
using Colore.Native;
using System.Threading.Tasks;

namespace JohnBPearson.Windows.Forms
{
    public static class RazerChnromaFacade
    {

    public static async Task<IChroma> getInstance() {
            var instance = await Colore.ColoreProvider.CreateNativeAsync();
            return instance;

    }

    }
}
