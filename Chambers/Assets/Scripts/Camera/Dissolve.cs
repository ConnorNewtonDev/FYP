using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    RaycastHit rayHit;
    Vector3 rayDir;
    // private Shader shader;
    private Renderer rend;
    private float counter;
    // Start is called before the first frame update
    void Start()
    {
        rend = this.GetComponent<Renderer>();
        counter = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StopAllCoroutines();
            StartCoroutine(ToggleDisolve(1));
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StopAllCoroutines();
            StartCoroutine(ToggleDisolve(0));
        }

    }


    public IEnumerator ToggleDisolve(float target)
    {
        float elapsedTime = 0f;
        while (elapsedTime < 3f)
        {
            rend.material.SetFloat("_alphaClip", Mathf.Lerp(rend.material.GetFloat("_alphaClip"), target, (elapsedTime / 3f)));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rend.material.SetFloat("_alphaClip", target);
        yield return null;

    }
}
