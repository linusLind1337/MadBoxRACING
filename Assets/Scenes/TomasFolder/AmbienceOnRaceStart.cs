//using UnityEngine;
//using FMODUnity;

//// To Jakob: This script starts playing the crowd cheering. This will play once the race actually starts. (Player presses GO!/Start!)


//public class AmbienceOnRaceStart : MonoBehaviour
//{
//    [FMODUnity.EventRef]
//    public string ambienceEvent;

//    private FMOD.Studio.EventInstance ambienceInstance;
//    private bool hasPlayed = false;

//    private void Start()
//    {
//        ambienceInstance = FMODUnity.RuntimeManager.CreateInstance(ambienceEvent);
//    }

//    private void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Space) && !hasPlayed) // To Jakob: Activates when GO! has been pressed by the player.
//        {
//            PlayAmbienceSound();
//            hasPlayed = true; 
//        }
//    }

//    private void PlayAmbienceSound()
//    {
//        ambienceInstance.start();
//    }
//}
