using UnityEngine;

public class ChallengeBase : MonoBehaviour
{
    private bool hardMode;
    public int hardReward;
    public int hardPenalty;
    public int challengeID;
    public Transform spawnParent;
    public Transform playerSpawn;
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

    public void SetActiveRespawn(Transform _spawnLoc)
    {
        gM.respawnLoc = _spawnLoc;
    }

    public bool GetHardMode()
    { return hardMode; }
}
