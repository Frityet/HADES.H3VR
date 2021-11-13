using FistVR;
using UnityEngine;
using BepInEx.Configuration;

using static HADES.Core.Plugin;
using static HADES.Utilities.Logging;

namespace HADES.Core
{
    public class FallDamage : HADESEnhancement
    {        
        private const string CATEGORY_NAME = "FallDamage";

        public bool Enabled => _enabledEntry.Value;
        private ConfigEntry<bool> _enabledEntry;

        private readonly ConfigEntry<float> _damageMultiplierEntry;
        public float DamageMultiplier => _damageMultiplierEntry.Value;

        private readonly ConfigEntry<float> _fallHeightEntry;
        public float FallHeight => _fallHeightEntry.Value;

        private Rigidbody _playerRigidBody;

        public FallDamage()
        {
            _enabledEntry = Plugin.BindConfig
            (
                CATEGORY_NAME,
                "Enabled",
                true,
                "If enabled, the player will take Fall Damage based off how far they fall from (configurable)"
            );

            _fallHeightEntry = Plugin.BindConfig
            (
                CATEGORY_NAME,
                "Height",
                20f,
                "How far you need to fall to take fall damage"
            );

            _damageMultiplierEntry = Plugin.BindConfig
            (
                CATEGORY_NAME,
                "Multiplier",
                1.5f,
                "The multiplier is multiplied by your velocity (distance travelled between 2 points in 0.02 seconds) and is what damages you"
            );
        }

        private void Start()
        {
            _playerRigidBody = Player.gameObject.GetComponent<Rigidbody>();
        }

        private float _fuTimer;
        public void FixedUpdate()
        {
            if (!Enabled) return;

            // if (_fuTimer < 1f)
            // {
            //     _fuTimer += 0.05f;
            //     return;
            // }
            // _fuTimer = 0f;

            // damage = previousVelocity - (initPos - currentPos) / 50

            // Vector3 velocity = _playerRigidBody.velocity;

            // if (velocity.y > 0.5f) // is falling
            // {

            // }

        }
    }
}