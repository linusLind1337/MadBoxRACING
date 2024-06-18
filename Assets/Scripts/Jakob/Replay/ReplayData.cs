using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ReplayData")]
public class ReplayData : ScriptableObject
{
    public List<NestedTexture2DListClass> setsOfReplayData;
    public List<Texture2D> replayFrames;
}
