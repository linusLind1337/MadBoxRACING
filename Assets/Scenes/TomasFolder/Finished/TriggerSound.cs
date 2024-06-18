using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string fmodEvent;

    [Header("Sound Emission Points")] // SPEAKERS
    public Transform[] soundEmissionPoints;

    private FMOD.Studio.EventInstance[] eventInstances;

    void Start()
    {
        eventInstances = new FMOD.Studio.EventInstance[soundEmissionPoints.Length];

        for (int i = 0; i < soundEmissionPoints.Length; i++)
        {
            eventInstances[i] = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < soundEmissionPoints.Length; i++)
            {
                PlaySpatializedAudio(soundEmissionPoints[i].position, eventInstances[i]);
            }
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
            eventInstances[i].stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstances[i].release();
        }
    }
}
