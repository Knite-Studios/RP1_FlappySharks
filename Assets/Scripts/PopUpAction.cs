using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpAction : MonoBehaviour
{

    private bool _fadeIn = false;
    private bool _fadeOut = false;
    [SerializeField]
    private CanvasGroup canvasGroup;

    [SerializeField]
    private float fadeSpeed = 1f;
    [SerializeField]
    private float fadeAfterSec = 5f;

    Vector3 newPos;
    RectTransform rectPos;

    void Awake()
    {
        rectPos = GetComponent<RectTransform>();
        newPos = new Vector3(700, rectPos.position.y, rectPos.position.z);
        StartCoroutine(MoveIn());
        canvasGroup.alpha = 0;
    }
    public void FadeIn()
    {
        _fadeIn = true;
    }
    public void FadeOut()
    {
        _fadeOut = true;
    }

    IEnumerator MoveIn()
    {
        FadeIn();
        yield return new WaitForSeconds(fadeAfterSec);
        FadeOut();
        yield return new WaitForSeconds(fadeAfterSec);
        FadeIn();
        yield return new WaitForSeconds(fadeAfterSec);
        FadeOut();
        this.gameObject.SetActive(false);
    }

    void Move()
    {
        rectPos.position = Vector3.MoveTowards(rectPos.position, newPos, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (_fadeIn)
        {
            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += fadeSpeed * Time.deltaTime;
                if (canvasGroup.alpha >= 1)
                {
                    _fadeIn = false;
                }
            }

        }
        if (_fadeOut)
        {
            if (canvasGroup.alpha >= 0)
            {
                canvasGroup.alpha -= fadeSpeed * Time.deltaTime;
                if (canvasGroup.alpha == 0)
                {
                    _fadeOut = false;
                }
            }

        }
    }
}
