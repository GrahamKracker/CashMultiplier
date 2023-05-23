using BTD_Mod_Helper.Api.ModOptions;
using CashMultiplier;
using Il2CppAssets.Scripts.Simulation;

[assembly: MelonInfo(typeof(CashMultiplier.Main), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace CashMultiplier;

[HarmonyPatch]
public class Main : BloonsTD6Mod
{
    private static readonly ModSettingDouble Multiplier = new(.5)
    {
        displayName = "Multiplier",
        description = "The multiplier for all cash gained, cannot go above 1",
        max = 1,
    };
    
    [HarmonyPatch(typeof(Simulation), nameof(Simulation.AddCash))]
    [HarmonyPrefix]
    static void Simulation_AddCash(ref double c, Simulation.CashSource source)
    {
        if (Multiplier > 1)
        {
            c /= Multiplier;    //troll face
        }
        else if (source != Simulation.CashSource.CoopTransferedCash)
            c *= Multiplier;
    }
}