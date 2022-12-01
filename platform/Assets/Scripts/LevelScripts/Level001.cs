using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level001 : MonoBehaviour
{
    public GameObject fadeIn;

    void Start()
    {
        RedirectToLevel.redirectToLevel = 3;
        StartCoroutine(FadeInOff());
    }

    IEnumerator FadeInOff()
    {
        yield return new WaitForSeconds(1);
        fadeIn.SetActive(false);
    }

    
}
