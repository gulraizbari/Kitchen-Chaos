using System;
using TMPro;
using UnityEngine;
using KitchenChaos.Feature.Input;
using KitchenChaos.Manager.GameStates;

namespace KitchenChaos.UI.Tutorial
{
    public class TutorialUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moveUpText;
        [SerializeField] private TextMeshProUGUI _moveDownText;
        [SerializeField] private TextMeshProUGUI _moveLeftText;
        [SerializeField] private TextMeshProUGUI _moveRightText;
        [SerializeField] private TextMeshProUGUI _pauseText;
        [SerializeField] private TextMeshProUGUI _interactText;
        [SerializeField] private TextMeshProUGUI _cuttingText;

        private void Start()
        {
            GameInput.Instance.OnBindingRebind += GameInput_OnBindingRebind;
            KitchenGameManager.Instance.OnGameStateChanged += KitchenGameManager_OnGameStateChanged;
            UpdateBindingTexts();
            Show(); 
        }

        private void KitchenGameManager_OnGameStateChanged(object sender, KitchenGameManager.GameStateChangedEventArg e)
        {
            if (KitchenGameManager.Instance.IsCountdownToStartActive())
            {
                Hide();
            }
        }

        private void GameInput_OnBindingRebind(object sender, EventArgs e)
        {
            UpdateBindingTexts();
        }

        private void UpdateBindingTexts()
        {
            _moveUpText.text = GameInput.Instance.GetBindingText(GameInput.Binding.MoveUp);
            _moveDownText.text = GameInput.Instance.GetBindingText(GameInput.Binding.MoveDown);
            _moveLeftText.text = GameInput.Instance.GetBindingText(GameInput.Binding.MoveLeft);
            _moveRightText.text = GameInput.Instance.GetBindingText(GameInput.Binding.MoveRight);
            _pauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);
            _interactText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact);
            _cuttingText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Cutting);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}