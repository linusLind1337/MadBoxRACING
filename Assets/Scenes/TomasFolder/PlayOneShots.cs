using UnityEngine;
using FMODUnity;

public class OneShotSoundPlayer : MonoBehaviour
{
    [System.Serializable]
    public struct OneShotSound
    {
        public string name;
        public StudioEventEmitter sound;
    }

    public OneShotSound[] oneShotSounds;

    public void PlaySound(string name)
    {
        foreach (OneShotSound sound in oneShotSounds)
        {
            if (sound.name == name)
            {
                sound.sound.Play();
                return;
            }
        }
        Debug.LogWarning("Sound '" + name + "' not found.");
    }
}
