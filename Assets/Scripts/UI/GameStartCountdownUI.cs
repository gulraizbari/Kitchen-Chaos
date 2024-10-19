using System;
using KitchenChaos.Manager.GameStates;
using TMPro;
using UnityEngine;

namespace KitchenChaos.UI
{
    public class GameStartCountdownUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _countdownTimerText;
        [SerializeField] private Animator _countdownTimerAnimator;
        
        private int _previousCountdownTimer;
        private readonly int POPUP_KEY = Animator.StringToHash("PopUp");
        
        private void Start()
        {
            KitchenGameManager.Instance.OnGameStateChanged += Game_OnStateChanged;
            Hide();
        }

        private void Update()
        {
            var countdownTimer = Mathf.CeilToInt(KitchenGameManager.Instance.GetCountdownTimerText());
            _countdownTimerText.text = countdownTimer.ToString();
            if (_previousCountdownTimer != countdownTimer)
            {
                _previousCountdownTimer = countdownTimer;
                _countdownTimerAnimator.SetTrigger(POPUP_KEY);
            }
        }

        private void Game_OnStateChanged(object sender, EventArgs e)
        {
            if (KitchenGameManager.Instance.IsCountdownToStartActive())
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

