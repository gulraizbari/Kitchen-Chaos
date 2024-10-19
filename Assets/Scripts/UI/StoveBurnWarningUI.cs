using KitchenChaos.Feature.Interaction;
using KitchenChaos.UI.Interface;
using UnityEngine;

namespace KitchenChaos.UI.Utility
{
    public class StoveBurnWarningUI : MonoBehaviour
    {
        [SerializeField] private StoveCounter _stoveCounter;

        private void Start()
        {
            _stoveCounter.OnProgressChanged += StoveCounter_OnProgressChanged;
            Hide();
        }

        private void StoveCounter_OnProgressChanged(object sender, IProgressBar.OnProgressChangedEventArgs e)
        {
            var warningShowAmount = 0.5f;
            var canShowWarning = _stoveCounter.IsFried() && e.progressNormalized >= warningShowAmount;
            if (canShowWarning)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

        private void Show()
        {
            gameObject.SetActive(true);
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}

