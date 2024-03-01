using System.Windows.Controls;
using Flow.Launcher.Plugin.GitProjectOpener.ViewModels;

namespace Flow.Launcher.Plugin.GitProjectOpener.Views
{
    /// <summary>
    /// Interaction logic for TogglTrackSettings.xaml.
    /// </summary>
    public partial class GitProjectOpenerSettings : UserControl
    {
        private readonly SettingsViewModel _viewModel;
        private readonly Settings _settings;

        /// <Summary>
        /// Initalises settings view.
        /// </Summary>
        public GitProjectOpenerSettings(SettingsViewModel viewModel)
        {
            this._viewModel = viewModel;
            this._settings = viewModel.Settings;
            this.DataContext = viewModel;
            this.InitializeComponent();
        }
    }
}