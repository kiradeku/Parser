using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Threading.Tasks;

namespace AvaloniaApplication1
{
    public class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public async Task<string> GetPath()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filters.Add(new FileDialogFilter() { Name = "Text", Extensions = { "txt" } });

            string[] result = await dialog.ShowAsync(this);
            return string.Join(" ", result);
        }

        public async void OnClickCommand (object sender, RoutedEventArgs args)
        {
            string _path = await GetPath();
        }
    }
}
