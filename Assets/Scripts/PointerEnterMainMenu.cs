using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class PointerEnterMainMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    public MenuScript menuScript;
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        menuScript.hoverMenu = true;
        gameObject.GetComponent<TextMeshProUGUI>().color = Color.white;
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        menuScript.hoverMenu = false;
        gameObject.GetComponent<TextMeshProUGUI>().color = new Color(0.5081176f, 0.3847328f, 0.6415094f);
    }
}
