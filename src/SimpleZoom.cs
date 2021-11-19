using System;
using System.Reflection;
using DuckGame;

[assembly: AssemblyTitle("Simple Zoom")]
[assembly: AssemblyCompany("|GREEN|klof44")]
[assembly: AssemblyDescription("Allows you to control zoom")]
[assembly: AssemblyVersion("0.1.0.0")]

namespace DuckGame.SimpleZoom
{
    public class SimpleZoom : DisabledMod
    {
		public override Priority priority => Priority.Monitor;
        protected override void OnPreInitialize()
		{
			base.OnPreInitialize();
		}
		protected override void OnPostInitialize()
		{
			new SimpleUpdate();
			try
			{
				HarmonyLoader.Loader.harmonyInstance.PatchAll();
				DevConsole.Log("Patched everything successfully!");
			}
			catch (Exception)
			{
				string[] message =
				{
					"There was an error while patching!",
					"This will lead to malfunctions and/or crashes."

				};

				foreach (string s in message)
				{
					DevConsole.Log(s);
				}
			}
			base.OnPostInitialize();
		}
	}
}
