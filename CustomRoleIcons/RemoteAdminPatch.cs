using Exiled.API.Features;
using HarmonyLib;
using RemoteAdmin.Communication;

namespace CustomRoleIcons
{
    [HarmonyPatch(typeof(RaPlayerList), nameof(RaPlayerList.GetPrefix))]
    internal static class RemoteAdminPatch
    {
        public static void Postfix(ref string __result, ReferenceHub hub, bool viewHiddenBadges = false, bool viewHiddenGlobalBadges = false)
        {
            Player player = Player.Get(hub);

            if (player == null || player.Group == null || string.IsNullOrEmpty(player.Group.Name))
                return;

            if (!Plugin.Instance.Config.Badges.ContainsKey(player.Group.Name))
                return;

            var badgeInfo = Plugin.Instance.Config.Badges[player.Group.Name];
            string customIcon = badgeInfo.Icon;
            string badgeColor = badgeInfo.Color;

            if (Plugin.colorMap.TryGetValue(badgeColor, out string hexcolor))
            {
                string originalAdminBadge = "<link=RA_Admin><color=white>[\uf406]</color></link> ";
                string customBadge = $"<link=RA_Admin><color=white>[<color={hexcolor}>{customIcon}</color>]</color></link> ";

                if (__result.Contains(originalAdminBadge))
                    __result = __result.Replace(originalAdminBadge, customBadge);
            }
        }
    }
}