using HarmonyLib;
using Kitchen;
using KitchenMods;
using PreferenceSystem;
using System.Reflection;
using Unity.Entities;
using UnityEngine;

namespace KitchenPermanentVisits
{
    public class Main : IModInitializer
    {
        public const string MOD_GUID = $"IcedMilo.PlateUp.{MOD_NAME}";
        public const string MOD_NAME = "Permanent Visits";
        public const string MOD_VERSION = "0.1.0";

        internal const string RESET_VISITS_ID = "resetVisits";

        internal static PreferenceSystemManager PrefManager;

        public Main()
        {
            Harmony harmony = new Harmony(MOD_GUID);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public void PostActivate(KitchenMods.Mod mod)
        {
            LogWarning($"{MOD_GUID} v{MOD_VERSION} in use!");

            PrefManager = new PreferenceSystemManager(MOD_GUID, MOD_NAME);
            PrefManager
                .AddLabel("Reset Visits")
                .AddOption<bool>(
                    RESET_VISITS_ID,
                    true,
                    new bool[] { false, true },
                    new string[] { "Never", "When Reentering Restaurant" })
                .AddSpacer()
                .AddButton("Reset Visits Now",
                    delegate (int _)
                    {
                        PatchHelper.StaticSet<TwitchNameList.CResetNameList>(out Entity _);
                        if (PatchHelper.GetExistingSystem(out TwitchNameList twitchNameList))
                            twitchNameList.ClearData();
                    })
                .AddSpacer()
                .AddSpacer();

            PrefManager.RegisterMenu(PreferenceSystemManager.MenuType.PauseMenu);
            PrefManager.RegisterMenu(PreferenceSystemManager.MenuType.MainMenu);
        }

        public void PreInject()
        {
        }

        public void PostInject()
        {
        }

        #region Logging
        public static void LogInfo(string _log) { Debug.Log($"[{MOD_NAME}] " + _log); }
        public static void LogWarning(string _log) { Debug.LogWarning($"[{MOD_NAME}] " + _log); }
        public static void LogError(string _log) { Debug.LogError($"[{MOD_NAME}] " + _log); }
        public static void LogInfo(object _log) { LogInfo(_log.ToString()); }
        public static void LogWarning(object _log) { LogWarning(_log.ToString()); }
        public static void LogError(object _log) { LogError(_log.ToString()); }

        #endregion
    }
}
