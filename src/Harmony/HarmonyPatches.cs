using Harmony;
using System.Reflection;
using System.Reflection.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckGame.SimpleZoom
{
    internal static class HarmonyPatches
    {
        [HarmonyPatch(typeof(RockIntro), nameof(RockIntro.Initialize))]
        internal static class RockIntro_Patch
        {
            internal static void Prefix()
            {
                while (Level.current is RockIntro)
                {
                    SimpleUpdate.rock = true;
                }
                SimpleUpdate.rock = false;
            }
        }
    }
}
