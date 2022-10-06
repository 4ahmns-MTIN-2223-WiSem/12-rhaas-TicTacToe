using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOARD : MonoBehaviour
{
    [Header("Input Settings : ")]
    [SerializeField] private LayerMask boxesLayerMask;
    [SerializeField] private float touchRadius;

    [Header("Mark Sprites : ")]
    [SerializeField] private Sprite spriteX;
    [SerializeField] private Sprite spriteO;

    [Header("Mark Colors")]
    [SerializeField] private Color colorX;
    [SerializeField] private Color colorO;

    public MARK[] marks;

    private Camera cam;

    private MARK currentMark;

    private void Start()
    {
        cam = Camera.main;

        currentMark = MARK.X;

        marks = new MARK[9];
    }
    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Vector2 touchPosition = cam.ScreenToWorldPoint(Input.mousePosition);

            Collider2D hit = Physics2D.OverlapCircle(touchPosition, touchRadius, boxesLayerMask );
            if (hit)
                HitBox(hit.GetComponent<BOX>());
        }
    }
    private void HitBox (BOX box)
    {
        if (!box.isMarked)
        {
            marks[box.index] = currentMark;

            box.SetAsMarked(GetSprite(),currentMark,GetColor());

            SwitchPlayer();
        }
    }
    private void SwitchPlayer()
    {
        currentMark = (currentMark == MARK.X) ? MARK.O : MARK.X;
    }

    private Color GetColor()
    {
        return (currentMark == MARK.X) ? colorX : colorO;
    }
    private Sprite GetSprite()
    {
        return (currentMark == MARK.X) ? spriteX : spriteO;
    }

    

}
