using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace game.ui
{
    public class CoinsCounter : MonoBehaviour
    {

        [Header("Managing")]
        [SerializeField]
        private Text _textCounting;
        [SerializeField]
        private float _timeForAdd = 0.1f;

        [Header("Events")]
        [SerializeField]
        private UnityEvent _onStart;
        [SerializeField]
        private UnityEvent _onStop;

        private int _totalAmount;
        private bool _isCounting = false;

        public void StartCount(int amount)
        {
            if (_isCounting)
                return;

            _onStart.Invoke();
            _isCounting = true;
            _totalAmount = amount;
            StartCoroutine(WaitAndAddOne(0));
        }

        public IEnumerator WaitAndAddOne(int amount)
        {
            yield return new WaitForSeconds(_timeForAdd);


            if(amount <= _totalAmount)
            {
                _textCounting.text = amount.ToString();
                StartCoroutine(WaitAndAddOne(amount + 1));
            }
            else
            {
                _onStop.Invoke();
                _isCounting = false;
            }
        }

    }
}
