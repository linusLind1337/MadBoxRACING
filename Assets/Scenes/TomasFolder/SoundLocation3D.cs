using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class SoundLocation3D : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string fmodEvent;

    [Header("Sound Emission Points")]
    public Transform[] soundEmissionPoints;

    private FMOD.Studio.EventInstance[] eventInstances;

    void Start()
    {
        eventInstances = new FMOD.Studio.EventInstance[soundEmissionPoints.Length];

        for (int i = 0; i < soundEmissionPoints.Length; i++)
        {
            eventInstances[i] = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
            PlaySpatializedAudio(soundEmissionPoints[i].position, eventInstances[i]);
        }
    }

    void PlaySpatializedAudio(Vector3 position, FMOD.Studio.EventInstance instance)
    {
        FMOD.VECTOR fmodPosition;
        fmodPosition.x = position.x;
        fmodPosition.y = position.y;
        fmodPosition.z = position.z;

        int index = System.Array.IndexOf(eventInstances, instance);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(instance, soundEmissionPoints[index], GetComponent<Rigidbody>());

        instance.start();
    }

    void OnDestroy()
    {
        for (int i = 0; i < eventInstances.Length; i++)
        {
            eventInstances[i].stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            eventInstances[i].release();
        }
    }
}
