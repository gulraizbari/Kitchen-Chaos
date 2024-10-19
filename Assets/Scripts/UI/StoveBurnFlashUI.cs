using KitchenChaos.Feature.Interaction;
using KitchenChaos.UI.Interface;
using UnityEngine;

namespace KitchenChaos.UI.Utility
{
    public class StoveBurnFlashUI : MonoBehaviour
    {
        [SerializeField] private StoveCounter _stoveCounter;
        [SerializeField] private Animator _stoveBurnFlashAnimator;
        
        private readonly int FLASH_KEY = Animator.StringToHash("IsFlashing");

        private void Start()
        {
            _stoveCounter.OnProgressChanged += StoveCounter_OnProgressChanged;
            _stoveBurnFlashAnimator.SetBool(FLASH_KEY, false);
        }

        private void StoveCounter_OnProgressChanged(object sender, IProgressBar.OnProgressChangedEventArgs e)
        {
            var warningShowAmount = 0.75f;
            var canShowWarning = _stoveCounter.IsFried() && e.progressNormalized >= warningShowAmount;
            _stoveBurnFlashAnimator.SetBool(FLASH_KEY, canShowWarning);
        }
    }
}