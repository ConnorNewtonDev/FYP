using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCube : Interactable
{
    public GameObject lightCube;
    public override void Action()
    {
        ToggleLight();
    }

    private void ToggleLight()
    {
        lightCube.SetActive(!lightCube.activeInHierarchy);
    }
}
