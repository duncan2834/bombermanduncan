using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] private Sprite[] frameArray;
    private int curFrame = 0;
    private float timer = 0;
    public float frameRate;
    private SpriteRenderer spriteRenderer;
    
    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnEnable() {
        spriteRenderer.enabled = true;
    }

     private void OnDisable() {
        spriteRenderer.enabled = false;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= frameRate) {
            timer -= frameRate;
            curFrame = (curFrame + 1) % frameArray.Length;
            spriteRenderer.sprite = frameArray[curFrame];
        }
    }
}
