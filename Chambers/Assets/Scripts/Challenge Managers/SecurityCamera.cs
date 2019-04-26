using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    public float scanSpeed;
    public float scanAngle;
    public float waitTime;
    private Vector3 targetRot;
    private Vector3 initRot;
    public float elapsedTime = 0.0f;

    public enum STATE { AT_START, IN_PROGRESS, AT_TARGET, WAITING, SPINNING}
    public STATE cameraState = STATE.AT_START;
    // Start is called before the first frame update
    void Start()
    {
        initRot = transform.eulerAngles;
        targetRot = new Vector3(initRot.x, initRot.y + scanAngle, initRot.z);
    }

    // Update is called once per frame
    void Update()
    {
        switch(cameraState)
        {
            case STATE.AT_START:
            {
                StopAllCoroutines();
                StartCoroutine(Scan(initRot, targetRot, STATE.WAITING));
                break;
            }
            case STATE.IN_PROGRESS:
                break;
            case STATE.AT_TARGET:
            {
                StopAllCoroutines();
                StartCoroutine(Scan(targetRot, initRot, STATE.WAITING));
                break;
            }
            case STATE.WAITING:
            {
                StopAllCoroutines();
                if (transform.eulerAngles == initRot)
                    StartCoroutine(Wait(STATE.AT_START));
                else
                    StartCoroutine(Wait(STATE.AT_TARGET));
                break;
            }
            case STATE.SPINNING:
            {
                    this.transform.Rotate(0, scanSpeed * Time.deltaTime, 0);
                    break;
            }
        }       
    }

    private IEnumerator Wait(STATE endState)
    {
        cameraState = STATE.IN_PROGRESS;
        yield return new WaitForSeconds(waitTime);
        cameraState = endState;
    }

    private IEnumerator Scan(Vector3 start, Vector3 end, STATE endState)
    {
        cameraState = STATE.IN_PROGRESS;

        elapsedTime = 0.0f;

        while (elapsedTime < scanSpeed)
        {
            //transform.rotation = Quaternion.Slerp(start, end, (elapsedTime / scanSpeed));
            transform.eulerAngles = Vector3.Lerp(start, end, (elapsedTime / scanSpeed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.eulerAngles = end;
        cameraState = endState;
    }

}
