using Xamarin.Forms.Platform.UWP;

namespace App1_Mimica.UWP
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new App1_Mimica.App());
        }
    }
}
