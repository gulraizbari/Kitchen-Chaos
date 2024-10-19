using System;
using KitchenChaos.Feature.Delivery;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KitchenChaos.UI.DeliveryStatus
{
    public class DeliveryStatusUI : MonoBehaviour
    {
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private TextMeshProUGUI _statusText;
        [SerializeField] private Image _statusIcon;
        [SerializeField] private Color _successColor;
        [SerializeField] private Color _failedColor;
        [SerializeField] private Sprite _successSprite;
        [SerializeField] private Sprite _failedSprite;
        [SerializeField] private Animator _deliveryStatusPopUp;
        
        private readonly int POPUP_KEY = Animator.StringToHash("DeliveryAction");

        private void Start()
        {
            DeliveryManager.Instance.OnRecipeSuccess += DeliveryManager_OnRecipeSuccess;
            DeliveryManager.Instance.OnRecipeFail += DeliveryManager_OnRecipeFail;
            Hide();
        }
        
        private void DeliveryManager_OnRecipeSuccess(object sender, EventArgs e)
        {
            Show();
            _deliveryStatusPopUp.SetTrigger(POPUP_KEY);
            _backgroundImage.color = _successColor;
            _statusText.text = "DELIVERY\nSUCCESS";
            _statusIcon.sprite = _successSprite;
        }

        private void DeliveryManager_OnRecipeFail(object sender, EventArgs e)
        {
            Show();
            _deliveryStatusPopUp.SetTrigger(POPUP_KEY);
            _backgroundImage.color = _failedColor;
            _statusText.text = "DELIVERY\nFAILED";
            _statusIcon.sprite = _failedSprite;
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

