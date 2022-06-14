using System;
using UnityEngine;

namespace Systems
{
    public class Timer : MonoBehaviour
    {
        #region Variables

        private Action _completeCallback;
        private float _time;
        private bool _isStarted;

        #endregion


        #region Unity lifecycle

        private void Update()
        {
            if (!_isStarted)
            {
                return;
            }

            _time -= Time.deltaTime;

            if (_time <= 0)
            {
                _isStarted = false;
                _completeCallback.Invoke();
            }
        }

        #endregion


        #region Public methods

        public void StartTimer(float time, Action completeCallback)
        {
            _completeCallback = completeCallback;
            _time = time;
            _isStarted = true;
        }

        #endregion
    }
}