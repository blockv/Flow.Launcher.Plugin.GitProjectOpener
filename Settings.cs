namespace Flow.Launcher.Plugin.GitProjectOpener {

    /// <summary>
    /// 
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// 
        /// </summary>
        public string CommandTemplate { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string BasePath { get; set; } = "C:\\";
        
        /// <summary>
        /// 
        /// </summary>
        public class CommandArgument
        {
#nullable disable
            /// <summary>
            /// 
            /// </summary>
            public string Argument { get; init; }
            /// <summary>
            /// 
            /// </summary>
            public string Interpolation { get; init; }
            /// <summary>
            /// 
            /// </summary>
            public int Score { get; init; }
#nullable enable
        }
    }
}