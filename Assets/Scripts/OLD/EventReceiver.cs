using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EventReceiver : MonoBehaviour//, IPointerClickHandler

{
    public GameObject obj, overwriteObj;


    /*  public void OnBeginDrag(PointerEventData eventData)
      {
          Debug.Log("DEBUG - Begin Drag");
          obj.GetComponent<Map>().NodeHandlerOnBeginDrag(this.gameObject);
      }
      public void OnDrag(PointerEventData eventData)
      {
          Debug.Log("DEBUG - OnDrag");
          obj.GetComponent<Map>().NodeHandlerOnDrag(this.gameObject);
      }
      public void OnEndDrag(PointerEventData eventData)
      {
          Debug.Log("DEBUG - End Drag");
          obj.GetComponent<Map>().NodeHandlerOnEndDrag(this.gameObject);
      }*/
   /* public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("DEBUG - Click");
        obj = GameObject.Find("Plane");
        overwriteObj = GameObject.Find("ToggleOverWrite");
        if (overwriteObj.GetComponent<Toggle>().isOn)
        {

            if (obj.GetComponent<Map>().PriceChecker(obj.GetComponent<Map>().NodeSelector().name))
            {
                obj.GetComponent<Map>().checkPriceNumBuilding = true;
                //string tempString = string.Format("{0}", gameObject.name).Remove(gameObject.name.Length - 7);
                //Debug.Log(tempString + " tempString OnPointerClick");
                obj.GetComponent<Map>().nodeToRemoveTemp = gameObject.name; //tempString;
            }
            else
            {
                obj.GetComponent<Map>().checkPriceNumBuilding = false;//s
            }
            Debug.Log(this.gameObject.name);
            //obj.GetComponent<Map>().SelectedBuildingRemoveTracker(this.gameObject.name);
            obj.GetComponent<Map>().NodeHandlerOnClick(this.gameObject);
        }
        else
        {
            if (obj.GetComponent<Map>().PriceChecker(obj.GetComponent<Map>().NodeSelector().name))
            {
                obj.GetComponent<Map>().checkPriceNumBuilding = true;
                //string tempString = string.Format("{0}", gameObject.name).Remove(gameObject.name.Length - 7);
                //Debug.Log(tempString + " tempString OnPointerClick");
                obj.GetComponent<Map>().nodeToRemoveTemp = gameObject.name; //tempString;
            }
            else
            {
                obj.GetComponent<Map>().checkPriceNumBuilding = false;
            }
            Debug.Log(this.gameObject.name);
            //obj.GetComponent<Map>().SelectedBuildingRemoveTracker(this.gameObject.name);
            obj.GetComponent<Map>().NodeHandlerOnClick(this.gameObject);
        }

    }*/

}
