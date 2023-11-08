using UnityEngine;
using UnityEngine.UI;
using Utils;
using Zenject;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class SceneReloadingButtonView : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            _button.onClick.AddListener(SceneChanger.ReloadScene);
        }
    }
}