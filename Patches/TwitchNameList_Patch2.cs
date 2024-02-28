using HarmonyLib;
using Kitchen;
using static Kitchen.TwitchNameList;

namespace KitchenPermanentVisits.Patches
{
    [HarmonyPatch]
    static class TwitchNameList_Patch2
    {
        [HarmonyPatch(typeof(TwitchNameList), "SetData")]
        [HarmonyPrefix]
        static void ClearData_Prefix(ref TwitchCustomerData data)
        {
            if (!PatchHelper.StaticHas<STwitchOrderingActive>() && data.OrderIndex > 0)
            {
                data.OrderIndex = 0;
                Main.LogError("Ordering disabled! Set Order Index to 0.");
            }
        }
    }
}
