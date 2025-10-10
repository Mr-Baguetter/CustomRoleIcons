using Exiled.API.Enums;
using Exiled.API.Features;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PlayerList;

namespace CustomRoleIcons
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "CustomRoleIcons";
        public override string Author => "Mr. Baguetter";
        public override Version RequiredExiledVersion { get; } = new(9, 9, 2);
		public override Version Version { get; } = new(1, 0, 0);
		internal Harmony _harmony;
        public override PluginPriority Priority => PluginPriority.Default;
        public static Plugin Instance;

        public override void OnEnabled()
        {
            Instance = this;

            _harmony = new Harmony($"com.mrbaguetter.customroleicons-{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}");
            _harmony.PatchAll();

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;

            _harmony.UnpatchAll();
            _harmony = null;
            base.OnDisabled();
        }

        public static IReadOnlyDictionary<string, string> colorMap = new Dictionary<string, string>()
        {
            ["pink"] = "#FF96DE",
            ["red"] = "#C50000",
            ["brown"] = "#944710",
            ["silver"] = "#A0A0A0",
            ["light_green"] = "#32CD32",
            ["crimson"] = "#DC143C",
            ["cyan"] = "#00B7EB",
            ["aqua"] = "#00FFFF",
            ["deep_pink"] = "#FF1493",
            ["tomato"] = "#FF6448",
            ["yellow"] = "#FAFF86",
            ["magenta"] = "#FF0090",
            ["blue_green"] = "#4DFFB8",
            ["orange"] = "#FF9966",
            ["lime"] = "#BFFF00",
            ["green"] = "#228B22",
            ["emerald"] = "#50C878",
            ["carmine"] = "#960018",
            ["nickel"] = "#727472",
            ["mint"] = "#98FB98",
            ["army_green"] = "#4B5320",
            ["pumpkin"] = "#EE7600",
        };
    }
}
