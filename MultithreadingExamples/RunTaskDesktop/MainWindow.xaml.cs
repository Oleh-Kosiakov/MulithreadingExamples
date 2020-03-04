using System.Threading.Tasks;
using System.Windows;

namespace RunTaskDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Task<string> GetFromInternet()
        {
            return Task.FromResult($"Hello from the Internet.");
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var output = await GetFromInternet();
            MessageBox.Show(output);
        }
    }
}
