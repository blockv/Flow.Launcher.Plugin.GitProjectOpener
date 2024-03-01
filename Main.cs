using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IO;
using System.Windows.Controls;
using Flow.Launcher.Plugin;
using Flow.Launcher.Plugin.GitProjectOpener.ViewModels;
using Flow.Launcher.Plugin.GitProjectOpener.Views;


// https://github.com/Flow-Launcher/plugin-samples/tree/master/HelloWorldCSharp
// https://www.flowlauncher.com/docs/#/develop-dotnet-plugins
namespace Flow.Launcher.Plugin.GitProjectOpener
{
    /// <summary>
    /// Main Plugin FLow.Launcher.Plugin.GitProjectOpener
    /// </summary>
    public class Main : IPlugin, ISettingProvider
    {
        private static SettingsViewModel _viewModel;
        private PluginInitContext _context;
        private Settings _settings;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void Init(PluginInitContext context)
        {
            _context = context;
            this._settings = context.API.LoadSettingJsonStorage<Settings>();
            Main._viewModel = new SettingsViewModel(this._settings);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<Result> Query(Query query)
        {
            List<Result> results = new List<Result>();
            if (query.Search.Length >= 3)
            {
                string[] allDirectories = Directory.GetDirectories(_settings.BasePath, ".git", SearchOption.AllDirectories);
                
                foreach (var directory in allDirectories)
                {
                    var parentDirectory = Directory.GetParent(directory);
                    if (directory.Contains(query.Search)) {
                        var result = new Result
                        {
                            Title = parentDirectory?.Name,
                            SubTitle = directory,
                            Action = c =>
                            {
                                var cmd = _settings.CommandTemplate.Replace("{{DIRECTORY}}", parentDirectory?.FullName);
                                _context.API.ShowMsg(cmd);
                                _context.API.ShellRun(cmd);
                                return true;
                            },
                            IcoPath = "Images/app.png"
                        };
                        results.Add(result);
                    }
                }
            }

            return results;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Control CreateSettingPanel()
        {
            return new GitProjectOpenerSettings(Main._viewModel!);
        }
        

        
        
    }
}