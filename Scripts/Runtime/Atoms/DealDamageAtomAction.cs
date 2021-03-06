using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.UnityAtoms;
using UnityAtoms;
using UnityEngine;

namespace niscolas.Healthy.Atoms
{
    [CreateAssetMenu(
        menuName = UnityAtomsConstants.ActionsCreateAssetMenuPrefix + "(" + nameof(Health) + ") => Deal Damage")]
    public class DealDamageAtomAction : AtomAction<GameObject>
    {
        [SerializeField]
        private RawAndRatioValue _damage;

        [SerializeField]
        private bool _findFromRoot;

        public override void Do(GameObject target)
        {
            IDamageable damageable = default;
            if (_findFromRoot && !target.TryGetComponentFromRoot(out damageable) ||
                !_findFromRoot && !target.TryGetComponent(out damageable) ||
                damageable == null)
            {
                return;
            }

            damageable.TakeRelativeDamage(_damage.Ratio);
            damageable.TakeRawDamage(_damage.RawValue);
        }
    }
}