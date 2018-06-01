using Harmony;
using RimWorld;
using RimWorld.Planet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine;
using Verse;

namespace AnimalRaiders
{
    [StaticConstructorOnStartup]
    class AnimalRaiders : Mod
    {
        public AnimalRaiders(ModContentPack content) : base(content)
        {
            var harmony = HarmonyInstance.Create("net.pog.rimworld.mod.animalraiders");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

    }

    [HarmonyPatch(typeof(LordToil_Siege))]
    [HarmonyPatch("CanBeBuilder")]
    [HarmonyPatch(new Type[] { typeof(Pawn) })]
    class Patch
    {
        static bool Prefix(Pawn p)
        {
            return (p.story != null);
        }
    }

}
