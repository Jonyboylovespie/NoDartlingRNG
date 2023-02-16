using Il2CppAssets.Scripts.Models;
using BTD_Mod_Helper;
using MelonLoader;
using NoDartlingRNG;
using Il2CppAssets.Scripts.Models.Towers.Mods;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Api.Data;
using BTD_Mod_Helper.Extensions;
using System.Linq;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;

[assembly: MelonInfo(typeof(NoDartlingRNG.Main), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace NoDartlingRNG
{
    public class Main : BloonsTD6Mod
    {
        public override void OnApplicationStart()
        {
            MelonLogger.Msg(System.ConsoleColor.Green, "Dartling Gunners now have no RNG!");
        }
        public override void OnNewGameModel(GameModel gameModel, Il2CppSystem.Collections.Generic.List<ModModel> mods)
        {
            foreach (var towerModel in gameModel.towers)
            {
                if (towerModel.baseId == "DartlingGunner")
                {
                    towerModel.GetDescendants<RandomEmissionModel>().ForEach(angle => angle.angle = 1);
                    towerModel.GetDescendants<EmissionWithOffsetsModel>().ForEach(angle => angle.randomRotationCone = 1);
                }
            }
        }
    }
}
