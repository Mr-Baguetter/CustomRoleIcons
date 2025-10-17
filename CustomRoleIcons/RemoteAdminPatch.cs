using Exiled.API.Extensions;
using Exiled.API.Features;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;

namespace CustomRoleIcons;

public class RABadgeHandler : CustomEventsHandler {
    public override void OnPlayerRaPlayerListAddingPlayer(PlayerRaPlayerListAddingPlayerEventArgs ev) {
        Log.Debug("----------");
        Log.Debug($"Player: {ev.Player}");
        Log.Debug($"Prefix:  {ev.Prefix}");
        Log.Debug($"Body: {ev.Body}");
        Log.Debug($"Target: {ev.Target}");
        Log.Debug($"Target Builder:  {ev.TargetBuilder}");
        
        var badgeInfo = Plugin.Instance.Config.Badges[ev.Player.UserGroup.GetKey()];
        string customIcon = badgeInfo.Icon;
        string badgeColor = badgeInfo.Color;

        if (Plugin.colorMap.TryGetValue(badgeColor, out string hexcolor)) {
            string customBadge = $"<link=RA_Admin><color=white>[<color={hexcolor}>{customIcon}</color>]</color></link> ";
            ev.Prefix = customBadge;
        }
    }
}