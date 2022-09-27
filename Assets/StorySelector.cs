using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorySelector : MonoBehaviour
{
    public GameObject heroe;
    public GameObject villano;
    public GameObject rescatado;
    public GameObject mascota;

    public Transform heroeSpawner;
    public Transform villanoSpawner;
    public Transform rescatadoSpawner;
    public Transform mascotaSpawner;
    public void InstantiateCharacters()
    {
        GameObject newHeroe = Instantiate(heroe,heroeSpawner);
        //newHeroe.AddComponent<CharacterController>();
        newHeroe.AddComponent<Heroe>();
        newHeroe.AddComponent<Rigidbody>();
        newHeroe.GetComponent<Rigidbody>().useGravity = false;
        newHeroe.GetComponent<Rigidbody>().freezeRotation = true;
        newHeroe.tag = "Player";

        GameObject newMascota = Instantiate(mascota, mascotaSpawner);
        newMascota.AddComponent<CompanionFollower>();

        GameObject newVillain= Instantiate(villano, villanoSpawner);
        newVillain.AddComponent<AIVillain>();
        newVillain.tag = "Villano";
        GameObject newRescatado = Instantiate(rescatado, rescatadoSpawner);
        newRescatado.AddComponent<AIRescatado>();
        newRescatado.tag = "Rescatado";
    }
}
