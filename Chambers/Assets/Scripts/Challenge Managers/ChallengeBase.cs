using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeBase : MonoBehaviour
{
    public bool hardMode;
    public int hardReward;
    public int hardPenalty;

    public virtual void Init() { }
}
