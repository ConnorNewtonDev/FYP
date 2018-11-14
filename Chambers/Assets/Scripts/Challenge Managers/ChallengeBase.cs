using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeBase : MonoBehaviour
{
    private bool hardMode;
    public int hardReward;
    public int hardPenalty;
    public int challengeID;
    [SerializeField]
    private GameManager gM;

    private void Start()
    {
        gM = FindObjectOfType<GameManager>();
    }

    public virtual void Init() { }

    public void SetHardMode(bool _value)
    {
        hardMode = _value;
        gM.SetHardmodeChoice(challengeID, hardMode);
    }

    public bool GetHardMode()
    { return hardMode; }
}
