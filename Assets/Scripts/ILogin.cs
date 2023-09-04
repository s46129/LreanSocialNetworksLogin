using UnityEngine;
using UnityEngine.UI;

// ReSharper disable once InconsistentNaming
namespace RexScripts
{
    public abstract class ILogin : MonoBehaviour
    {
        [SerializeField] private Button targetButton;

        private void OnEnable()
        {
            targetButton.onClick.AddListener(Login);
        }

        private void OnDisable()
        {
            targetButton.onClick.RemoveListener(Login);
        }

        protected abstract void Login();
    }
}