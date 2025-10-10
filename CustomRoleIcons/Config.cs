using System;
using System.Collections.Generic;
using Exiled.API.Interfaces;

namespace CustomRoleIcons
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }
        public Dictionary<string, BadgeInfo> Badges { get; set; } = new Dictionary<string, BadgeInfo>
        {
            ["owner"] = new BadgeInfo { Icon = "💻", Color = "emerald" },
        };
    }
}

