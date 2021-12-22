using niscolas.UnityUtils.UnityAtoms;
using UnityAtoms;
using UnityEngine;

namespace niscolas.Healthy.Atoms
{
    [CreateAssetMenu(
        menuName = UnityAtomsConstants.ActionsCreateAssetMenuPrefix + "(" + nameof(Health) + ") => Heal")]
    public class HealAtomAction : AtomAction<Health>
    {
        [SerializeField]
        private RawAndRatioValue _healAmount;

        public override void Do(Health healable)
        {
            if (!healable)
            {
                return;
            }

            healable.Heal(_healAmount.RawValue);
            healable.HealRelative(_healAmount.Ratio);
        }
    }
}