// © Mod Converter.
// Licensed under the MIT license.

namespace ModConverter;

using System;
using Dalamud.Configuration;

[Serializable]
public class Configuration : IPluginConfiguration
{
	public int Version { get; set; } = 0;
	public bool Enable { get; set; } = true;

	public void Save()
	{
		Plugin.PluginInterface.SavePluginConfig(this);
	}
}