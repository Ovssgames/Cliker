using _Project.Scripts.Controller;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure
{
    public class GameUpdater : MonoBehaviour
    {
        private IController _controller;

        [Inject]
        private void Construct(IController controller)
        {
            _controller = controller;
        }

        private void Update()
        {
            _controller.Update(Time.deltaTime);
        }
    }
}