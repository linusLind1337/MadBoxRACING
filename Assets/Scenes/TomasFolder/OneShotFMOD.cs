using UnityEngine;
using FMODUnity;

public class OneShotFMOD : MonoBehaviour
{
    [EventRef]
    public string fmodEventPath;

    private FMOD.Studio.EventInstance fmodEventInstance;

    private void OnEnable()
    {
        fmodEventInstance = RuntimeManager.CreateInstance(fmodEventPath);
        fmodEventInstance.start();
    }

    private void Update()
    {
        FMOD.Studio.PLAYBACK_STATE playbackState;
        fmodEventInstance.getPlaybackState(out playbackState);
        if (playbackState == FMOD.Studio.PLAYBACK_STATE.STOPPED)
        {
            fmodEventInstance.release();
            enabled = false;
        }
    }

    private void OnDestroy()
    {
        if (fmodEventInstance.isValid())
        {
            fmodEventInstance.release();
        }
    }
}
