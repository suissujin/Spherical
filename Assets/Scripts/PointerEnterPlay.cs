using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine;

public class PointerEnterPlay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public MenuScript menuScript;
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        menuScript.hoverPlay = true;
        gameObject.GetComponent<TextMeshProUGUI>().color = Color.white;
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        menuScript.hoverPlay = false;
        gameObject.GetComponent<TextMeshProUGUI>().color = new Color(0.5081176f, 0.3847328f, 0.6415094f);
    }
}
