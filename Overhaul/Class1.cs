using BepInEx;
using EntityStates.Croco;
using RoR2;
using EntityStates;
using RoR2.Skills;


namespace Overhaul
{
    [BepInDependency("com.bepis.r2api")]
    //Change these
    [BepInPlugin("com.Necropotence.Overhaul", "Revamped Items, Skills and Stats", "1.0.0")]
    public class Overhaul : BaseUnityPlugin
    {
        public void Awake()
        {
            Logger.LogMessage("Loaded Overhaul");
            //Acrid Changes
            Slash.comboFinisherDamageCoefficient = 10;

            On.EntityStates.Croco.Slash.OnEnter += (orig, self) =>
            {
                Chat.AddMessage("It's ALIVE!");
                orig(self);
            };
        }
    }
}