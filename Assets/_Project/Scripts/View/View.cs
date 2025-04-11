using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.View
{
    public interface IView
    {
        event Action OnClick;
        event Action OnRestart;
        
        void UpdateClicks(int clicks);
        void UpdateTimer(float time);
        void ShowRestartButton(bool show);
    }
    
    public class View : MonoBehaviour, IView
    {
        public event Action OnClick;
        public event Action OnRestart;
        
        [SerializeField] private TextMeshProUGUI _textClicks;
        [SerializeField] private TextMeshProUGUI _textTimer;

        [Space]
        [SerializeField] private Button _buttonClick;
        [SerializeField] private Button _buttonRestart;

        private void Start()
        {
            _buttonClick.onClick.AddListener(() => OnClick?.Invoke());
            _buttonRestart.onClick.AddListener(() => OnRestart?.Invoke());
        }

        public void UpdateClicks(int clicks)
        {
            _textClicks.text = $"Clicks: {clicks}";
        }

        public void UpdateTimer(float time)
        {
            _textTimer.text = $"Time: {time}";            
        }

        public void ShowRestartButton(bool show)
        {
            _buttonRestart.gameObject.SetActive(show);
            _buttonClick.interactable = !show;
        }
    }
}