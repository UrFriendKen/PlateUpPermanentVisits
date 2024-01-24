using HarmonyLib;
using Kitchen.ChefConnector.Commands;

namespace KitchenPermanentVisits.Patches
{
    [HarmonyPatch]
    static class TwitchNameList_Patch2
    {
        [HarmonyPatch(typeof(Visit), "SendMessages")]
        [HarmonyPrefix]
        static void ClearData_Prefix(ref bool ___RequestWipe)
        {
            if (___RequestWipe)
                Main.LogError("Requested Wipe");
        }
    }
}
