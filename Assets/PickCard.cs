using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickCard : MonoBehaviour
{
    public bool humano;
    bool correctPosition;
    Vector3 toPosition;
    public StorySelector storySelector;

    public GameObject personaje;
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Entro");
        if (other.gameObject.CompareTag("CharacterSlot") && humano)
        {
            correctPosition = true;
            toPosition = other.GetComponent<RectTransform>().position;
            if (other.GetComponent<Slot>().slotNumber == 1)
            {
                storySelector.heroe = personaje;
                Debug.Log("heroe colcoado");
            }
            else if (other.GetComponent<Slot>().slotNumber == 2)
            {
                storySelector.villano = personaje;
                Debug.Log("villano colcoado");
            }
            else if (other.GetComponent<Slot>().slotNumber == 3)
            {
                storySelector.rescatado = personaje;
                Debug.Log("r4escatado colcoado");
            }
        }
        else if (other.gameObject.CompareTag("AnimalSlot") && !humano)
        {
            correctPosition = true;
            toPosition = other.GetComponent<RectTransform>().position;
            if (other.GetComponent<Slot>().slotNumber == 0)
            {
                storySelector.mascota = personaje;
                Debug.Log("animal colcoado");
            }

        }
    }

    public RectTransform rectTransform;
    Vector3 offset;
    public void GetOffset()
    {
        offset = rectTransform.position - Input.mousePosition;
    }
    public void MoveObject()
    {
        rectTransform.position = Input.mousePosition + offset;
    }
    public void PlaceCharacter()
    {
        if (correctPosition)
        {
            rectTransform.position = toPosition;

        }
    }
}
