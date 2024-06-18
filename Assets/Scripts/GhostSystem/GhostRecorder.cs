using System;
using UnityEngine;

namespace GhostSystem
{
    public class GhostRecorder : MonoBehaviour
    {
        [SerializeField] private Ghost ghost;
        private float _timer;
        private float _timeValue;

        private Transform _recorderTransform;

        private void Start()
        {
            _recorderTransform = transform;
            
            if(GameState.Instance.GetActiveState() == GameStates.Player1Turn)
                ghost.ResetData();
        }

        private void Update()
        {
            switch (ghost.currentState)
            {
                case GhostState.Recording:
                    UpdateRecording();
                    break;
                case GhostState.Idle:
                    break;
                case GhostState.Replaying:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void UpdateRecording()
        {
            _timer += Time.deltaTime;
            _timeValue += Time.deltaTime;

            if (!(_timer >= 1 / ghost.recordFrequency)) 
                return;

            var ghostValues = new GhostValues(_timeValue, _recorderTransform.position, _recorderTransform.rotation);
            ghost.GhostValues.Add(ghostValues);

            _timer = 0;
        }
    }

}
