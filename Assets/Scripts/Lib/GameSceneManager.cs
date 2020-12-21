using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace game.lib
{
    public class GameSceneManager : MonoBehaviour
    {

        // Start is called before the first frame update
        private void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {

        }

        public void Replay()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void ReplayAsync()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }

        public void GoScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        public void GoScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void GoSceneAsync(int sceneIndex)
        {
            SceneManager.LoadSceneAsync(sceneIndex);
        }

        public void GoSceneAsync(string sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}
