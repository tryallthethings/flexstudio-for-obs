using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Flexstudio_for_OBS
{
    public class sett : INotifyPropertyChanged
    {
        private static readonly string ConfigFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "config.cfg");

        private static sett _instance;
        public static sett ing => _instance ?? (_instance = new sett());

        private Dictionary<string, string> _settings;

        public event PropertyChangedEventHandler PropertyChanged;

        public string this[string key]
        {
            get => _settings.ContainsKey(key) ? _settings[key] : null;
            set
            {
                _settings[key] = value;
                Save();
                OnPropertyChanged(key);
            }
        }

        private sett()
        {
            _settings = new Dictionary<string, string>();
            Load();
        }

        protected void OnPropertyChanged(string key)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(key));
        }

        public void Load()
        {
            if (File.Exists(ConfigFilePath))
            {
                var lines = File.ReadAllLines(ConfigFilePath);
                _settings.Clear();

                foreach (var line in lines)
                {
                    var parts = line.Split('=');
                    if (parts.Length == 2)
                    {
                        _settings[parts[0]] = parts[1];
                    }
                }
            }
            else
            {
                // config.cfg not found. Creating a new with default values
                SetDefaultValues();
                File.CreateText(ConfigFilePath).Dispose();
                Save();
            }
        }

        public void Save()
        {
            var lines = _settings.Select(kvp => $"{kvp.Key}={kvp.Value}").ToList();
            File.WriteAllLines(ConfigFilePath, lines);
        }

        public bool HasKeyWithValue(string key)
        {
            return _settings.ContainsKey(key) && !string.IsNullOrEmpty(_settings[key]);
        }

        private void SetDefaultValues()
        {
            _settings["autoMapDefaultDrive"] = "False";
            _settings["autoRemoveDefaultDrive"] = "True";
            _settings["autoStartDefaultOBS"] = "False";
            _settings["isDebug"] = "False";
        }
    }
}
