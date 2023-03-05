using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class TransparecyManager : MonoBehaviour
{
    public Vector3[] positions;
    
    
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        //StartCoroutine(FadeIn());
        //StartCoroutine(MoveSphere());
        StartCoroutine(MovementLeft());
    }

    private Color RandomColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        
        return new Color(r, g, b);
    }
    
    private Vector3 RandomScale()
    {
        float x = Random.Range(0.5f, 10f);
        float y = Random.Range(0.5f, 10f);

        return new Vector3(x, y, 1);
    }

    private IEnumerator FadeOut()
    {
        Color color = _meshRenderer.material.color;
        for (float i = 1; i >= 0; i -= 0.1f)
        {
            //transform.localScale = RandomScale();
            color = RandomColor();
            color = new Color(color.r, color.g, color.b, i);
            _meshRenderer.material.color = color;
            yield return new WaitForSeconds(0.2f);
        }
        
        color = new Color(color.r, color.g, color.b, 0);
        _meshRenderer.material.color = color;
        
        StartCoroutine(FadeIn());
    }
    
    private IEnumerator FadeIn()
    {
        Color color = _meshRenderer.material.color;
        for (float i = 0; i <= 1; i += 0.1f)
        {
            //transform.localScale = RandomScale();
            color = RandomColor();
            color = new Color(color.r, color.g, color.b, i);
            _meshRenderer.material.color = color;
            yield return new WaitForSeconds(0.2f);
        }
        
        color = new Color(color.r, color.g, color.b, 1);
        _meshRenderer.material.color = color;
        
        StartCoroutine(FadeOut());
    }
    
    private IEnumerator MovementRight()
    {
        for (float i = 0; i <= 1; i += 0.1f)
        {
            transform.position = i * Vector3.right;
            yield return new WaitForSeconds(0.2f);
        }
        StartCoroutine(MovementLeft());
    }
    
    private IEnumerator MovementLeft()
    {
        for (float i = 1; i >= 0; i -= 0.1f)
        {
            transform.position = i * Vector3.right;
            yield return new WaitForSeconds(0.2f);
        }

        StartCoroutine(MovementRight());

    }

    private IEnumerator MoveSphere()
    {
        foreach (Vector3 pos in positions)
        {
            transform.position = pos;
            yield return new WaitForSeconds(1f);
        }
    }
}
