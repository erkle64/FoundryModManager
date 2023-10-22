
using System.Configuration;

namespace FoundryModManager
{
	public class ModsConfiguration
	{
		private string _name;
		private bool _isVanilla;
		private HashSet<string> _enabledMods;

		public string name => _name;
		public bool isVanilla => _isVanilla;

		public ModsConfiguration(string name, bool isVanilla, IList<string> modsToEnable)
		{
			_name = name;
			_isVanilla = isVanilla;
			_enabledMods = new(modsToEnable);
		}

		public ModsConfiguration(ConfigurationsData.Entry data)
		{
			_name = data.name ?? "unnamed";
			_isVanilla = false;
			_enabledMods = new(data.enabledMods ?? new string[0]);
		}

        public bool IsModEnabled(string name) => _enabledMods.Contains(name);

		public bool ToggleMod(string name, bool desiredState)
		{
			if (_isVanilla) return false;

			if (IsModEnabled(name))
			{
				if (!desiredState) _enabledMods.Remove(name);
			}
			else
			{
				if (desiredState) _enabledMods.Add(name);
            }

			return desiredState;
        }

		public ConfigurationsData.Entry CreateDataEntry()
		{
			return new ConfigurationsData.Entry()
			{
				name = _name,
				enabledMods = _enabledMods.ToArray()
			};
		}
    }
}
