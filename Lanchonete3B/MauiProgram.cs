using Lanchonete3B.Class;
using Lanchonete3B.Service;
using Lanchonete3B.Views;
using Microsoft.Extensions.Logging;

namespace Lanchonete3B
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();

#endif
            builder.Services.AddSingleton<IProdutoService, ProdutoService>();
            
            return builder.Build();
        }
    }
}
