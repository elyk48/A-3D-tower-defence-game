using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour


{  [SerializeField]
    private LayerMask ClickableLayer;
    bool clicked = false;
    float money =1000f;
    public GameObject selected;

    public SelectedUI US_Ui;
    public GameObject _UpgradedPrefab;
   
    // Update is called once per frame
    void Update()
    {

        /// <summary>
        /// Selecting object
        /// </summary>
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit rayhit;
            /// <summary>
            /// testing if you selected an object
            /// </summary>
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out rayhit,Mathf.Infinity,ClickableLayer))
            {
                if (clicked == false)
                {
                    clicked = true;
                    rayhit.collider.GetComponent<clickOn>().ClickMe();
                    if (selected == rayhit.transform.gameObject)
                    {
                        DselectObj();

                    }
                    else
                    {
                        selected = rayhit.transform.gameObject;
                        US_Ui.SetTarget(selected);
                    }
                    

                    Debug.Log("clicked!!!!!!!!!!!!");
                }else
                {

                    clicked = false;
                    rayhit.collider.GetComponent<clickOn>().AClicked();
                }

            }
        }
        
    }

    public void DselectObj()
    {
        selected = null;
        US_Ui.hide();

    }

    public void UpgradeTurret()
    {
        if (selected != null)
        {
            Instantiate(_UpgradedPrefab, selected.transform.position, selected.transform.rotation);

            Debug.Log("Turret Upgraded !!!!!!");
            Destroy(selected);
            DselectObj();
        }
    }

    public void SellTurret()
    {
        if (selected != null)
        {

            Destroy(selected);
            money +=200;

            Debug.Log(money);
            DselectObj();
        }
    }
}
