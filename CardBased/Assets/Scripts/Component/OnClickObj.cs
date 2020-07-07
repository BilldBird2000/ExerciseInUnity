using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnClickObj : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick ( PointerEventData eventData )
    {
        Debug.LogFormat ("{0}被点击!" , eventData.pointerEnter.name);
    }


}
