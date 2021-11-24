using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickOn : MonoBehaviour
{
    [SerializeField]
    private Material initial;
    [SerializeField]
    private Material clicked;

    private MeshRenderer Myrend;

    void Start()
    {
        Myrend = GetComponent<MeshRenderer>();
    }

    public void ClickMe()
    {

        Myrend.material = clicked;

    }
    public void AClicked()
    {

        Myrend.material = initial;

    }

}
