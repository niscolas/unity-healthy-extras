using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Assertions;

namespace niscolas.Healthy
{
    public class HealthNotifier : MonoBehaviour
    {
        [Required, SerializeField]
        private Health _health;

        [ListDrawerSettings(NumberOfItemsPerPage = 1)]
        [SerializeField]
        private HealthComparer[] _comparers;

        private void Awake()
        {
            Assert.IsNotNull(_health);

            _health.ValueChangedWithHistory += HealthOnValueChanged;
        }

        private void OnDestroy()
        {
            _health.ValueChangedWithHistory -= HealthOnValueChanged;
        }

        private void HealthOnValueChanged(FloatPair healthWithHistory)
        {
            foreach (HealthComparer comparer in _comparers)
            {
                comparer.Execute(healthWithHistory.Item2, _health.Max);
            }
        }
    }
}