using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOX : MonoBehaviour
{
    public int index;
    public MARK mark;
    public bool isMarked;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        index = transform.GetSiblingIndex();
        mark = MARK.None;
        isMarked = false;
         
    }
    public void SetAsMarked (Sprite sprite, MARK mark, Color color)
    {
        isMarked = true;
        this.mark = mark;

        spriteRenderer.color = color;
        spriteRenderer.sprite = sprite;

        GetComponent<CircleCollider2D>().enabled = false;
    }


}
