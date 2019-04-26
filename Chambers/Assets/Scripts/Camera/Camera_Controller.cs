using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    // Movement Variables
    private Transform target;
    public Vector3 offset;
    public Vector3 defaultRot;
    private float dampening = 15f;

    //UI PANELS
    private GameObject uiPanel;
    public GameObject deathPanel;

    private void Awake()
    {
        //SetupPanels
        deathPanel = GameObject.Find("Death Panel");
        deathPanel.GetComponent<CanvasGroup>().alpha = 0;
        deathPanel.SetActive(false);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!this.gameObject.isStatic && target != null)
            this.transform.position = Vector3.Lerp(this.transform.position, (target.position - offset), dampening);
    }

    //Target the camera onto an object.
    public void TargetObject(GameObject _target)
    {
        target = _target.transform;
        this.transform.rotation = Quaternion.Euler(defaultRot);
    }

    public bool GetStatic()
    {
        if(this.gameObject.isStatic)
            return true;
        else
            return false;
    }

    public IEnumerator FadeUI(GameObject _panel, float _alphaStart, float _alphaFinish)
    {
        CanvasGroup panelCG = _panel.GetComponent<CanvasGroup>();
        if (!_panel.activeInHierarchy)
        {
            _panel.SetActive(true);
        }


        if (panelCG == null)
            yield return null;

        float elapsedTime = 0;
        panelCG.alpha = _alphaStart;

        while (elapsedTime < 0.5f)
        {
            panelCG.alpha = Mathf.Lerp(panelCG.alpha, _alphaFinish, (elapsedTime / 0.5f));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        //To make sure if faded away the panel is also disabled.
        if(_alphaFinish == 0)
        {
            _panel.SetActive(false);
        }
    }




}
