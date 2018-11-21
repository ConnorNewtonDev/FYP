using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    // Movement Variables
    private Transform target;
    private Vector3 offset = new Vector3(1f, -7, 6);
    private Vector3 defaultRot = new Vector3(50, 15, 0);
    private float dampening = 15f;

    //UI PANELS
    private GameObject uiPanel;
    public GameObject deathPanel { get;  private set; }

    private void Start()
    {
        //SetupPanels
        uiPanel = GameObject.Find("UI Panel");
        deathPanel = GameObject.Find("Death Panel");
        uiPanel.GetComponent<CanvasGroup>().alpha = 0;
        deathPanel.GetComponent<CanvasGroup>().alpha = 0;
        deathPanel.SetActive(false);
        uiPanel.SetActive(false);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        this.transform.position = Vector3.Lerp(this.transform.position, (target.position - offset), dampening);
    }

    //Target the camera onto an object.
    public void TargetObject(GameObject _target)
    {
        target = _target.transform;
        this.transform.rotation = Quaternion.Euler(defaultRot);
    }

    public void ToggleChoiceUI(GameObject _challenge)
    {

        uiPanel.GetComponent<DifficultyUI>().activeChallenge = _challenge;

        StartCoroutine(FadeUI(uiPanel, 0, 1));
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

        while (elapsedTime < 1f)
        {
            panelCG.alpha = Mathf.Lerp(panelCG.alpha, _alphaFinish, (elapsedTime / 1f));
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
