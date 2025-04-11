using _Project.Scripts.Controller;
using _Project.Scripts.Model;
using _Project.Scripts.View;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure
{
    public class SceneInstaller : MonoInstaller
    { 
        [SerializeField] private View.View _view;
        
        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            Container.Bind<IModel>().To<Model.Model>().AsSingle();
            Container.Bind<IView>().FromInstance(_view).AsSingle();
            Container.Bind<IController>().To<Controller.Controller>().AsSingle().NonLazy();
        }
    }
}
