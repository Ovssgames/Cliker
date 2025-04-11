using _Project.Scripts.Model;
using _Project.Scripts.View;
using UnityEngine;

namespace _Project.Scripts.Controller
{
    public interface IController
    {
        void OnClick();
        void OnRestart();
        void Update(float time);
    }
    
    public class Controller : IController
    {
        private readonly IModel _model;
        private readonly IView _view;
        
        public Controller(IModel model, IView view)
        {
            _model = model;
            _view = view;

            _view.OnClick += OnClick;
            _view.OnRestart += OnRestart;
            
            _model.Restart();
            _view.ShowRestartButton(false);
            _view.UpdateClicks(_model.Clicks);
            _view.UpdateTimer(_model.TimeLeft);
        }
        
        public void OnClick()
        {
            _model.AddClick();
            _view.UpdateClicks(_model.Clicks);
        }

        public void OnRestart()
        {
            _model.Restart();
            _view.ShowRestartButton(false);
            _view.UpdateClicks(_model.Clicks);
            _view.UpdateTimer(_model.TimeLeft);
        }

        public void Update(float time)
        {
            _model.UpdateTime(time);
            _view.UpdateTimer(Mathf.CeilToInt(_model.TimeLeft));
            
            if(!_model.IsGameActive)
                _view.ShowRestartButton(true);
        }
    }
}