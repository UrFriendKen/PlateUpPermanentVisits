using Kitchen;
using KitchenMods;
using Unity.Entities;

namespace KitchenPermanentVisits
{
    public class PatchHelper : GenericSystemBase, IModSystem
    {
        static PatchHelper _instance;

        protected override void Initialise()
        {
            base.Initialise();
            _instance = this;
        }

        protected override void OnUpdate()
        {
        }

        internal static bool GetExistingSystem<T>(out T system) where T : ComponentSystemBase
        {
            system = _instance?.World?.GetExistingSystem<T>();
            return system != null;
        }

        internal static bool StaticSet<T>(out Entity singleton) where T : struct, IComponentData
        {
            singleton = _instance?.Set<T>() ?? default;
            return singleton != default;
        }

        internal static bool StaticHas<T>(bool errorVal = false) where T : struct, IComponentData
        {
            return _instance?.Has<T>() ?? errorVal;
        }

        internal static bool StaticHas<T>(Entity e, bool errorVal = false) where T : struct, IComponentData
        {
            return _instance?.Has<T>(e) ?? errorVal;
        }

        internal static bool StaticRequire<T>(out T comp, bool errorVal = false) where T : struct, IComponentData
        {
            comp = default;
            return _instance?.Require(out comp) ?? errorVal;
        }

        internal static bool StaticRequire<T>(Entity e, out T comp, bool errorVal = false) where T : struct, IComponentData
        {
            comp = default;
            return _instance?.Require(e, out comp) ?? errorVal;
        }
    }
}
