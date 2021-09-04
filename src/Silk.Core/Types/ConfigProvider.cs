﻿using System.IO;
using Config.Net;
using YumeChan.PluginBase.Tools;

namespace Silk.Core.Types
{
	public class ConfigProvider<T> : IConfigProvider<T> where T : class
	{
		public T InitConfig(string filename)
		{
			ConfigFile = new FileInfo($"./{filename}.json");

			return Configuration = new ConfigurationBuilder<T>().UseJsonFile(ConfigFile.ToString()).Build();
		}
		
		public T Configuration { get; set; }
		public FileInfo ConfigFile { get; private set; }
	}
}