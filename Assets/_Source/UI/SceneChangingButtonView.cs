using UnityEngine;
using UnityEngine.UI;
using Utils;
using Zenject;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class SceneChangingButtonView : MonoBehaviour
    {
        [SerializeField] private int sceneIndex;
        private Button _button;
        private SceneChanger _sceneChanger;

        [Inject]
        private void Construct(SceneChanger sceneChanger)
        {
            _sceneChanger = sceneChanger;
        }
        
        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            _button.onClick.AddListener(delegate {_sceneChanger.LoadSceneBySceneIndex(sceneIndex); });
        }
    }
}