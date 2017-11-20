using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;


using UnityEngine.UI;

public class MyDrag : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler,
    IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public int cost = 1000;
	public int emissionReduction = 100;
    public GameObject PrefabsGameObject;
    private RectTransform canvas;          
    private RectTransform imgRect;        
    Vector2 offset = new Vector3();    
    Vector3 imgReduceScale = new Vector3(0.8f, 0.8f, 1);   
    Vector3 imgNormalScale = new Vector3(1, 1, 1);   
    private Vector2 rectTransform;
    private GameObject go;
    private Image iamge;
    private bool IsAlive = false;
    
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<RectTransform>();
        imgRect = GetComponent<RectTransform>();
        go = Instantiate(PrefabsGameObject);
        go.transform.rotation = PrefabsGameObject.transform.rotation;
        go.SetActive(false);
        iamge = GetComponent<Image>();
    }

    
    public void OnPointerDown(PointerEventData eventData)
    {
        rectTransform = imgRect.position;
        Vector2 mouseDown = eventData.position;    
        Vector2 mouseUguiPos = new Vector2();   
        imgRect.localScale = imgReduceScale;   
        
        bool isRect = RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, mouseDown, eventData.enterEventCamera, out mouseUguiPos);
        if (isRect)   
        {
            
            offset = imgRect.anchoredPosition - mouseUguiPos;
        }
    }

    
    public void OnDrag(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        FreeCamera.FreeCamera.instance.CanCtrl = false;
        if (Physics.Raycast(ray,out hit))
        {
            if (hit.collider.CompareTag("Prop"))
            {
                iamge.enabled = false;
                FreeCamera.FreeCamera.instance.CanCtrl = false;
                go.SetActive(true);
                go.transform.position = new Vector3(hit.point.x,hit.point.y+go.transform.localScale.y*0.4f,hit.point.z);
                IsAlive = true;
            }
        }
        else
        {
            FreeCamera.FreeCamera.instance.CanCtrl = true;
            iamge.enabled = true;
            IsAlive = false;
            go.SetActive(false);
            Vector2 mouseDrag = eventData.position;   
            Vector2 uguiPos = new Vector2();   
            
            bool isRect = RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, mouseDrag, eventData.enterEventCamera, out uguiPos);

            if (isRect)
            {
                
                imgRect.anchoredPosition = offset + uguiPos;
            }
        }
    }

   
    public void OnPointerUp(PointerEventData eventData)
    {
        FreeCamera.FreeCamera.instance.CanCtrl = true;
        iamge.enabled = true;
        imgRect.localScale = imgNormalScale;   
        imgRect.position = rectTransform;                    
        offset = Vector2.zero;
        if (IsAlive)
        {
            if (GameMaster.instance.balance>=cost)
            {
                GameObject ins = Instantiate(go);
                GameMaster.instance.balance -= cost;
				GameMaster.instance.annualEmissions -= emissionReduction;
                go.SetActive(false);
            }
        }
    }

    
    public void OnEndDrag(PointerEventData eventData)
    {
        offset = Vector2.zero;      
    }

    
    public void OnPointerEnter(PointerEventData eventData)
    {
		//imgRect.localScale = imgReduceScale;
    }

    
    public void OnPointerExit(PointerEventData eventData)
    {
		//imgRect.localScale = imgNormalScale;
    }

/*    string toDollar(int value)
    {
        return "$" + string.Format("{0:n0}", value);
    }*/
}