using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game.lib
{
    public class DetectGameLaunched : MonoBehaviour
    {
        [SerializeField]
        private static bool _isLaunched = false;
        public static bool isLaunched
        {
            get { return _isLaunched; }
        }

        private static DetectGameLaunched _instance;
        

        private void OnEnable()
        {
            if (_instance == null)
            {
                _instance = this;
                _isLaunched = true;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                _isLaunched = false;
                Destroy(gameObject);
            }
        }
    }
}
