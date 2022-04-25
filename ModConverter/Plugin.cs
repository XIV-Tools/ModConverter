// © Mod Converter.
// Licensed under the MIT license.

namespace ModConverter;

using System;
using Dalamud.Game.Command;
using Dalamud.Game.Gui;
using Dalamud.IoC;
using Dalamud.Logging;
using Dalamud.Plugin;

public sealed class Plugin : IDalamudPlugin
{
	public Plugin()
	{
		try
		{
			Configuration = PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
			////CommandManager.AddCommand((s, t) => ConfigurationInterface.Show(), "/customize", "Opens the customize+ configuration window");
		}
		catch (Exception ex)
		{
			PluginLog.Error(ex, "Error instantiating plugin");
		}
	}

	[PluginService] [RequiredVersion("1.0")] public static DalamudPluginInterface PluginInterface { get; private set; } = null!;
	[PluginService] [RequiredVersion("1.0")] public static CommandManager CommandManager { get; private set; } = null!;
	[PluginService] [RequiredVersion("1.0")] public static ChatGui ChatGui { get; private set; } = null!;

	public static Configuration Configuration { get; private set; } = null!;

	public string Name => "Mod Converter";

	public void Dispose()
	{
		Files.Dispose();
		CommandManagerExtensions.Dispose();
	}
}
