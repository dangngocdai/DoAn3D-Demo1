using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.Vehicles.Car;

public class CangatManager : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField]
    Animator animatorCanGat;

    string nameAnim_N = "CanGat_N";
    string nameAnim_D = "CanGat_D";
    string nameAnim_R = "CanGat_R";

    int indexCanGat = 1;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        CarUserControl.Instance.typeStartus = TypeStartusCar.N;
        animatorCanGat.Play(nameAnim_N);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Vector3 dragVectorDirection = (eventData.position - eventData.pressPosition).normalized;
        MoveCanGat(GetDragDirection(dragVectorDirection));
    }

    void MoveCanGat(DraggedDirection direction)
    {
        if (direction == DraggedDirection.Up)
        {
            Next();
        }
        if (direction == DraggedDirection.Down)
        {
            Pre();
        }
    }

    void Next()
    {
        if ((indexCanGat + 1) > 3)
            return;
        indexCanGat++;
        SetAnim();
    }

    void Pre()
    {
        if ((indexCanGat - 1) < 0)
            return;
        indexCanGat--;
        SetAnim();
    }

    void SetAnim()
    {
        switch (indexCanGat)
        {
            case 0:
                animatorCanGat.Play(nameAnim_R);
                CarUserControl.Instance.typeStartus = TypeStartusCar.R;
                break;
            case 1:
                animatorCanGat.Play(nameAnim_N);
                CarUserControl.Instance.typeStartus = TypeStartusCar.N;
                break;
            case 2:
                animatorCanGat.Play(nameAnim_D);
                CarUserControl.Instance.typeStartus = TypeStartusCar.D;
                break;

        }
    }

    private enum DraggedDirection
    {
        Up,
        Down,
        Right,
        Left
    }
    private DraggedDirection GetDragDirection(Vector3 dragVector)
    {
        float positiveX = Mathf.Abs(dragVector.x);
        float positiveY = Mathf.Abs(dragVector.y);
        DraggedDirection draggedDir;
        if (positiveX > positiveY)
        {
            draggedDir = (dragVector.x > 0) ? DraggedDirection.Right : DraggedDirection.Left;
        }
        else
        {
            draggedDir = (dragVector.y > 0) ? DraggedDirection.Up : DraggedDirection.Down;
        }
        Debug.Log(draggedDir);
        return draggedDir;
    }
    public void OnDrag(PointerEventData eventData)
    {
        // Debug.Log((eventData.position - eventData.pressPosition).y);

        // if (!onDrag && !isMove)
        // {
        //     posDragStartY = _container.transform.position.y;
        //     onDrag = true;
        // }


        // SetPostion((eventData.position - eventData.pressPosition).y * 0.005f);
    }
}
