using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace game.loading
{
    public class LoadingPageManager : MonoBehaviour
    {
        [SerializeField]
        private Text _textLoading;
        [SerializeField]
        private Slider _loadingSlider;

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
            StartCoroutine(LoadAsynchronously(1));
        }

        IEnumerator LoadAsynchronously(int scenceIndex)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(scenceIndex);

            while (!operation.isDone)
            {

                _loadingSlider.value = operation.progress;
                yield return null;

            }

        }
    }
}
