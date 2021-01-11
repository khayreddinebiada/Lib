using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace game.lib
{
    public class WaitAndExecute : MonoBehaviour
    {
        [SerializeField]
        private bool _inStart = true;
        [SerializeField]
        private float _time = 1;
        [SerializeField]
        private UnityEvent _action;

        // Start is called before the first frame update
        private void Start()
        {
            if (_inStart)
                StartCoroutine(WaitAndAction());
        }

        private IEnumerator WaitAndAction()
        {
            yield return new WaitForSeconds(_time);
            _action.Invoke();
            Destroy(this);
        }


        public WaitAndExecute(bool inStart, float time, UnityEvent action)
        {
            _inStart = inStart;
            _time = time;
            _action = action;
        }
    }
}