using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace game.loading
{
    public class LoadingPageManager : MonoBehaviour
    {
        public enum Type { byName, byIndex }

        [SerializeField]
        private Text _textLoading;
        [SerializeField]
        private Slider _loadingSlider;

        [SerializeField]
        private Type _type;
        [SerializeField]
        private string _sceneName;
        [SerializeField]
        private int _sceneIndex;

        private int _pointNumber;
        // Start is called before the first frame update
        private void Start()
        {
            _textLoading.text = "LOADING .";
            StartCoroutine(WaitAndChangeText());
        }

        private IEnumerator WaitAndChangeText()
        {
            yield return new WaitForSeconds(0.8f);
            _pointNumber++;

            if (_pointNumber == 3)
            {
                _textLoading.text = "LOADING ";
                _pointNumber = 0;
            }

            _textLoading.text += ".";
            StartCoroutine(WaitAndChangeText());


            if (_type == Type.byIndex)
                StartCoroutine(LoadAsynchronously(_sceneIndex));
            else
                StartCoroutine(LoadAsynchronously(_sceneName));
        }

        private IEnumerator LoadAsynchronously(int scenceIndex)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(scenceIndex);

            while (!operation.isDone)
            {

                _loadingSlider.value = operation.progress;
                yield return null;

            }

        }

        private IEnumerator LoadAsynchronously(string sceneName)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

            while (!operation.isDone)
            {

                _loadingSlider.value = operation.progress;
                yield return null;

            }

        }
    }
}
