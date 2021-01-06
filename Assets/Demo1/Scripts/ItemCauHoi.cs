using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCauHoi : MonoBehaviour
{
    int indexOptionSelect = 0;
    [SerializeField]
    int indexOptionTrue = 0;
    [SerializeField]
    Button btnXacNhan;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        btnXacNhan.interactable = false;
    }

    public void ClickBtnXacNhan()
    {
        if (indexOptionTrue == indexOptionSelect)
        {
            //Dung
        }
        else
        {
            //Sai
        }
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void TickOption(int _index)
    {
        if (indexOptionSelect != _index)
        {
            indexOptionSelect = _index;
            btnXacNhan.interactable = true;
        }
        else
        {
            indexOptionSelect = 0;
            btnXacNhan.interactable = false;
        }
    }
}
