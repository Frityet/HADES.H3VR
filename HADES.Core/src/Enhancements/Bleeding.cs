using System;
using System.Collections.Generic;
using BepInEx.Configuration;
using FistVR;
namespace HADES.Core
{
    public class Bleeding : HADESEnhancement
    {
        private ConfigEntry<bool> _enabledEntry;
        public bool Enabled => _enabledEntry.Value;
        public IEnumerable<FVRPlayerHitbox> Hitboxes => Player.Hitboxes;

        private MatDef _materialDefinition;
        private const string CATEGORY_NAME = "Bleeding";

        public Bleeding()
        {
            _enabledEntry = Plugin.BindConfig<bool>
            (
                CATEGORY_NAME,
                "Enabled",
                true,
                "If enabled, the player will bleed when damaged"
            );
        }

        public void Awake()
        {
            _materialDefinition = GetComponent<PMat>().MatDef;
            On.FistVR.FVRPlayerHitbox.Damage_Damage += Bleed;
        }

        public void Bleed(On.FistVR.FVRPlayerHitbox.orig_Damage_Damage _, FVRPlayerHitbox @this, Damage damage)
        {
            _(@this, damage);
        }
    }
}