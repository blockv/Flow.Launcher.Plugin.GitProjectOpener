namespace Flow.Launcher.Plugin.GitProjectOpener.ViewModels
{
    /// <Summary>
    /// GUI settings logic.
    /// </Summary>
    public class SettingsViewModel : BaseModel
    {
        /// <Summary>
        /// Initalises settings view with defaults.
        /// </Summary>
        public SettingsViewModel(Settings settings)
        {
            this.Settings = settings;
        }

        /// <Summary>
        /// Gets the setting.
        /// </Summary>
        public Settings Settings { get; init; }

        /// <Summary>
        /// Handles updates to CommandTemplate setting.
        /// </Summary>
        public string CommandTemplate
        {
            // get => new string('*', this.Settings.CommandTemplate.Length);
            get => this.Settings.CommandTemplate;
            set
            {
                this.Settings.CommandTemplate = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Handles updates to BasePath setting.
        /// </summary>
        public string BasePath
        {
            get => this.Settings.BasePath;
            set
            {
                this.Settings.BasePath = value;
                this.OnPropertyChanged();
            }
        }
    }    
}

