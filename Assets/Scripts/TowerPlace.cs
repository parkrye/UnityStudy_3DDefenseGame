using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlace : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Color outMouse, onMouse;
    Renderer render;

    void Awake()
    {
        render = GetComponent<Renderer>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            BuildInGameUI buildInGameUI = GameManager.UI.ShowInGameUI<BuildInGameUI>("UI/BuildInGameUI");
            buildInGameUI.SetTarget(transform);
            buildInGameUI.SetOffset(new Vector3(0f, 100f, 100f));

            buildInGameUI.towerPlace = this;
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {

        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        render.material.color = onMouse;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        render.material.color = outMouse;
    }

    public void BuildTower(TowerData data)
    {
        GameManager.Resource.Destroy(gameObject);
        GameManager.Resource.Instantiate(data.towers[0].tower, transform.position, transform.rotation);
    }
}
