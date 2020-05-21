using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveCrystal : MonoBehaviour
{
    public GameObject crystal;
    public Image fade;

    public void Start()
    {
        fade.canvasRenderer.SetAlpha(1.0f);

        fade.CrossFadeAlpha(0, 2.5f, false);
    }

    public void Update()
    {
        if(crystal.activeInHierarchy == false)
        {
            fade.CrossFadeAlpha(1, 2.5f, false);         
        }
    }
}
