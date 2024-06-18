using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReplayManager : MonoBehaviour
{
    public GameActionIntInt highlightPassed;
    public GameActionVoid finishLinePassed;
    public RenderTexture highlightRenderTexture;
    public List<Texture2D> replayFrameImages;
    public List<Texture2D> sequencedFrames;
    
    //Planned to have multiple cameras and multiple replays recorded for each map
    public Camera highlightCamera;
    public Transform[] highlightCameraAnchorPoints;
    public ReplayData replayData;

    //highlight
    private int highlightIndex;
    private float highlightRecordTimer;
    private float highlightRecordDuration;
    private bool highlightRecording;
    private int framesSaved;
    //replay
    private float playReplayTimer;
    private float playReplayDuration;
    private bool playReplay;
    private int listIndex;
    private int frameCounter;
    public RawImage rawImageReplayPlayback;

    private void OnEnable()
    {
        highlightPassed.callActionIntInt += HighlightPassed;
        finishLinePassed.callActionVoid += FinishlinePassed;
    }

    private void OnDisable()
    {
        highlightPassed.callActionIntInt -= HighlightPassed;
        finishLinePassed.callActionVoid -= FinishlinePassed;
    }

    private void Start()
    {
        rawImageReplayPlayback.enabled = false;
        replayFrameImages = new List<Texture2D>();
    }

    private void FixedUpdate()
    {
        if (highlightRecording)
        {
            highlightRecordTimer += Time.fixedDeltaTime;
            if (highlightRecordTimer >= highlightRecordDuration)
            {
                HighlightRecordingFinished();
            }
        } 
        
        //Loops the index when the maximum is reached
        if (playReplay)
        {
            if (frameCounter % 2 == 0)
            {
                PlayTextureFrameAnimation(listIndex);
                listIndex++;
                if (listIndex == replayFrameImages.Count)
                {
                    listIndex = 0;
                }
            }
            frameCounter++;
        }
        
        //Saves textures to the list every other fixed update loop
        if (highlightRecording)
        {
            if (framesSaved % 2 == 0)
            {
                SaveTextureFrames();
            }
            framesSaved++;
        }
    }

    //Starts the recording
    private void HighlightPassed(int duration, int cameraIndex)
    {
        MoveCamera(cameraIndex);
        highlightRecording = true;
        highlightRecordTimer = 0;
        highlightRecordDuration = (float)duration;
        framesSaved = 0;
    }

    #region Saving Textures
    //Creates a texture from the render target and adds it to a global list of textures
    private void SaveTextureFrames()
    {
        Texture2D texture = new Texture2D(1280, 720, TextureFormat.RGB24, false);
        RenderTexture.active = highlightRenderTexture;
        texture.ReadPixels(new Rect(0, 0, highlightRenderTexture.width, highlightRenderTexture.height), 0, 0);
        texture.Apply();
        replayFrameImages.Add(texture);
    }
    //The recording finishes
    private void HighlightRecordingFinished()
    {
        highlightRecording = false;
    }
    
    //An object of Nested Texture2D is created and the frames in replayFrameImages
    //are added to the objects list.
    private void SaveTexturesToObject(Texture2D texture)
    {
        var frames = new NestedTexture2DListClass(); //Object is created
        frames.listOfFrames = new List<Texture2D>(); //The list contained within the object is created
        frames.listOfFrames.Add(texture); //The list contained in the object is filled with the textures from the saved list
        replayData.setsOfReplayData.Add(frames); //The object is added to the list of sets
    }
    
    #endregion
    
    #region Replaying Textures
    
    private void FinishlinePassed()
    {
        playReplay = true;
        sequencedFrames = SequenceReplayFrames();
        listIndex = 0;
        rawImageReplayPlayback.enabled = true;

    }
    //The nested list of iterated through, adding each set of the list in the order they were created
    //Creating one long list of frames for replaying in sequence.
    private List<Texture2D> SequenceReplayFrames()
    {
        List<Texture2D> sequencedFrames = new List<Texture2D>();
        for (int i = 0; i < replayData.setsOfReplayData.Count; i++)
        {
            for (int j = 0; j < replayData.setsOfReplayData[i].listOfFrames.Count; j++)
            {
                sequencedFrames.Add(replayData.setsOfReplayData[i].listOfFrames[j]);
            }
        }

        return sequencedFrames;
    }

    //Replays the frames by iterating through each entry in the list and updating the UI element
    private void PlayTextureFrameAnimation(int index)
    {
        rawImageReplayPlayback.texture = replayFrameImages[index];
    }
    
    #endregion
    
    private void MoveCamera(int cameraIndex)
    {
        highlightCamera.transform.position = highlightCameraAnchorPoints[cameraIndex].transform.position;
    }
    
}
