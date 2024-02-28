using HarmonyLib;
using Kitchen.ChefConnector.Commands;

namespace KitchenPermanentVisits.Patches
{
    [HarmonyPatch]
    static class Visit_Patch
    {
        [HarmonyPatch(typeof(Visit), "SendMessages")]
        [HarmonyPrefix]
        static void SendMessages_Prefix(ref bool ___RequestWipe)
        {
            if (___RequestWipe)
                Main.LogError("Requested Wipe");
        }
    }
}
