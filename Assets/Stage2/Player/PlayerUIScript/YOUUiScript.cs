using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Å‰‚É‚Å‚é"YOU"‚ğíœ‚·‚éˆ—
public class YOUUiScript : MonoBehaviour
{
    [SerializeField] GameObject youText;

    [SerializeField] float closeTime = 1.0f;

    private void Update()
    {
        StartCoroutine(CloseYouUi());
    }

    private IEnumerator CloseYouUi()
    {
        yield return new WaitForSeconds(closeTime);

        youText.SetActive(false);
    }
}
