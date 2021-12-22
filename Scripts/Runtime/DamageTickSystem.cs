using niscolas.OdinCompositeAttributes;
using niscolas.UnityUtils.Extras;
using niscolas.UnityUtils.UnityAtoms;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace niscolas.Healthy
{
    public class DamageTickSystem : MonoBehaviour
    {
        [Required, SerializeField]
        private Health _health;

        [Title("Tick")]
        [SecondsLabel, SerializeField]
        private FloatReference _tickInterval;

        [SerializeField]
        private RawAndRatioValue _tickSelfDamage;

        private TickSystem _tickSystem;

        private void Awake()
        {
            _tickSystem = new TickSystem(_tickInterval, InflictSelfDamage);
        }

        private void OnEnable()
        {
            _tickSystem.Start();
        }

        private void OnDisable()
        {
            _tickSystem.Stop();
        }

        private void InflictSelfDamage(TickSystem.Data tickData)
        {
            _health.TakeRelativeDamage(_tickSelfDamage.Ratio);
            _health.TakeDamage(_tickSelfDamage.RawValue);
        }
    }
}