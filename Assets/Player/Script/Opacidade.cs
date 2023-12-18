using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opacidade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartFadeOut(150f);
    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator FadeOut(Renderer renderer, float duration)
    {
        Color color = renderer.material.color;
        float startOpacity = color.a;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            float blend = t / duration;

            color.a = Mathf.Lerp(startOpacity, 0, blend);

            renderer.material.color = color;

            yield return null;
        }

        color.a = 0;
        renderer.material.color = color;
    }

    void StartFadeOut(float duration)
    {
        foreach (Transform child in transform)
        {
            var renderer = child.GetComponent<Renderer>();
            if (renderer != null)
            {
                Material material = renderer.material;
                if (material.HasProperty("_Color"))
                {
                    StartCoroutine(FadeOut(renderer, duration));
                }
            }
        }
    }



}
