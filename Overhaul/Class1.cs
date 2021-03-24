using System;
using BepInEx;
using BepInEx.Configuration;
using EntityStates.Croco;
using EntityStates.Huntress.HuntressWeapon;
using On.EntityStates.Huntress.HuntressWeapon;
using RoR2.Projectile;
using RoR2;
using On.RoR2;
using R2API;
using R2API.Utils;
using UnityEngine;
using UnityEngine.Networking;



namespace Overhaul
{
    [BepInDependency("com.bepis.r2api")]
    //Change these
    [BepInPlugin("com.Necropotence.Overhaul", "Revamped Items, Skills and Stats", "1.0.0")]
    [R2APISubmoduleDependency(new string[]
    {
        "LanguageAPI"
    })]
    public class Overhaul : BaseUnityPlugin
    {
        public void Awake()
        {
            Logger.LogMessage("Loaded Overhaul");
            this.crocoBody = Resources.Load<GameObject>("Prefabs/CharacterBodies/CrocoBody");
            this.CrocoPrimaries();
            this.CrocoBaseStats();
        }

        private void AddBodyFlags()
        {
            RoR2.CharacterBody component = RoR2.BodyCatalog.FindBodyPrefab("HuntressBody").GetComponent<RoR2.CharacterBody>();
            component.bodyFlags |= RoR2.CharacterBody.BodyFlags.SprintAnyDirection;
        }

        private void CrocoPrimaries()
        {
            On.EntityStates.Croco.Slash.OnEnter += delegate(On.EntityStates.Croco.Slash.orig_OnEnter orig, EntityStates.Croco.Slash self)
            {
                self.damageCoefficient = 2.0f;
                RoR2.Chat.AddMessage("test");
                self.co
                orig.Invoke(self);
            };
        }

        private void CrocoBaseStats()
        {
            this.crocoBody.GetComponent<RoR2.CharacterBody>().baseMoveSpeed = 10f;
        }

        public GameObject crocoBody;
    }
}