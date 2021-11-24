using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedUI : MonoBehaviour
{

    public GameObject Ui;
    private GameObject target;

    

    public void SetTarget(GameObject _target)
    {
        target = _target;
        transform.position = target.transform.position;

        Ui.SetActive(true);
    }


    public void hide()
    {
        Ui.SetActive(false);

    }
}
