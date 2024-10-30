using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


public class Interaction : MonoBehaviour
{
    public GameObject interactGameObject;
    private Camera camera;
    public float maxCheckDistance;
    public TextMeshProUGUI text;
    ItemObject itemObject;
    public LayerMask layerMask;
    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2));
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
        {
            if (hit.collider.gameObject != interactGameObject)
            {
                
                interactGameObject = hit.collider.gameObject;
                itemObject = hit.collider.GetComponent<ItemObject>();
                SetPromptText();
            }
        }
        else 
        {
            interactGameObject = null;
            text.gameObject.SetActive(false);
        }

    }

    private void SetPromptText()
    {
        text.gameObject.SetActive(true);
        text.text = itemObject.InteractPrompt();
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && interactGameObject != null && interactGameObject.CompareTag("Item"))
        {
            itemObject.OnUse();
            interactGameObject = null;
            itemObject = null;
            text.gameObject.SetActive(false);

        }
    }
}

