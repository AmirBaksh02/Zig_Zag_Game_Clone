using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class CombatText : MonoBehaviour
{
    private float speed;
    private Vector3 direction;
    private float fadeTime;

    void Update()
    {
        float translation = speed * Time.deltaTime;

        transform.Translate(direction * translation); 

    }

    public void Start()
    {
        transform.LookAt(2 * transform.position - CombatTextManager.Instance.camTransform.position); 

    }



    public void Initialize(float speed, Vector3 direction)
    {
        this.speed = speed;
        this.fadeTime = fadeTime; 
        this.direction = direction;

        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float startAlpha = GetComponent<Text>().color.a;

        float rate = 1.0f / fadeTime;

        float progress = 0.0f;

        while (progress < 1.0)
        {
            Color tmpColor = GetComponent<Text>().color;

            GetComponent<Text>().color = new Color(tmpColor.r, tmpColor.g, tmpColor.b, Mathf.Lerp(startAlpha, 0, progress));

            progress += rate * Time.deltaTime;

            yield return new WaitForSeconds(20); 

            //yield return null; 
        }

        Destroy(gameObject);
    }

}
