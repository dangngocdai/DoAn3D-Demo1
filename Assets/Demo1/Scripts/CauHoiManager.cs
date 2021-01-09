using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauHoiManager : SingletonMonoBehaviour<CauHoiManager>
{
    [SerializeField]
    List<GameObject> listCauHoi;

    public void ShowCauHoi(int index)
    {
        Time.timeScale = 0;
        listCauHoi[index - 1].SetActive(true);
    }

    public bool TraLoiDungCau(int index)
    {
        return PlayerPrefs.GetInt("Cau" + index, 0) == 1;
    }

    public void SetCauHoi(int index)
    {
        PlayerPrefs.SetInt("Cau" + index, 1);
    }

}
