using System.Linq;
using Exiled.API.Extensions;
using Exiled.API.Features;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;

namespace CustomRoleIcons;

public class RABadgeHandler : CustomEventsHandler 
{
    public override void OnPlayerRaPlayerListAddingPlayer(PlayerRaPlayerListAddingPlayerEventArgs ev) 
    {
        Log.Debug("----------");
        Log.Debug($"Player: {ev.Player}");
        Log.Debug($"Prefix:  {ev.Prefix}");
        Log.Debug($"Body: {ev.Body}");
        Log.Debug($"Target: {ev.Target}");
        Log.Debug($"Target Builder:  {ev.TargetBuilder}");
        
        var badgeInfo = Plugin.Instance.Config.Badges[ev.Player.UserGroup.GetKey()];
        string customBadge = "<link=RA_Admin><color=white>";
        
        foreach (var badgeIcon in badgeInfo.Icon) 
        {
            var inconIndex = badgeInfo.Icon.IndexOf(badgeIcon);

            if (badgeInfo.Color == null) 
            {
                customBadge += $"[<color=#FFFFFF>{badgeIcon}</color>]";
            } 
            else if (badgeInfo.Color.Count > 1) 
            {
                if (Plugin.colorMap.TryGetValue(badgeInfo.Color[inconIndex], out string hexColor))
                {
                    customBadge += $"[<color={hexColor}>{badgeIcon}</color>]";
                }
                else if (badgeInfo.Color[inconIndex].Contains('#'))
                {
                    customBadge += $"[<color={badgeInfo.Color[inconIndex]}>{badgeIcon}</color>]";
                }
                else
                    customBadge += $"[<color=#FFFFFF>{badgeIcon}</color>]"; 
            } 
            else 
            {
                if (Plugin.colorMap.TryGetValue(badgeInfo.Color[0], out string hexColor))
                {
                    customBadge += $"[<color={hexColor}>{badgeIcon}</color>]";
                }
                else if (badgeInfo.Color[0].Contains('#'))
                {
                    customBadge += $"[<color={badgeInfo.Color[0]}>{badgeIcon}</color>]";
                }
                else
                    customBadge += $"[<color=#FFFFFF>{badgeIcon}</color>]";
            }
        }
        
        customBadge += "</color></link> ";
        ev.Prefix = customBadge;
    }
}