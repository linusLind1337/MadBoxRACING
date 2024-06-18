using System;
using UnityEngine;

namespace GhostSystem
{
    public class GhostRecorderAlphaMap : MonoBehaviour
    {
        [SerializeField] private Ghost ghost;
        private float _timer;
        private float _timeValue;

        private Transform _recorderTransform;

        private void Awake()
        {
            /*
            _recorderTransform = transform;
            //Added
            if (GameState.Instance.GetActiveState() != GameStates.Player2Turn)
            {
                ghost.ResetData();
            }
            */
        }

        private void Start()
        {
            _recorderTransform = transform;
            //Added
            if (GameState.Instance.GetPlayerTurn() != PlayerTurn.Player2Turn)
            {
                ghost.ResetData();
            }
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
            _timer += Time.unscaledDeltaTime;
            _timeValue += Time.unscaledDeltaTime;

            if (!(_timer >= 1 / ghost.recordFrequency)) 
                return;

            var ghostValues = new GhostValues(_timeValue, _recorderTransform.position, _recorderTransform.rotation);
            ghost.GhostValues.Add(ghostValues);

            _timer = 0;
        }
    }

}
