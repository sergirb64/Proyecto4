using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleController : MonoBehaviour
{
    //Importaciones
    [Header("Importaciones")]
    Rigidbody _rb;

    [Header("Parametros Movimiento")]
    public float[] _velocity = new float[5];
    public int _currentVelocity = 1;
    public float _currentInc = 0;
    public float _currentGiro = 0;
    public float _velRotation;
    public float _velGiro;
    float _giro;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        UpdateControllData();
        CalculeGiro();
        MoveShip();
    }

    void UpdateControllData()
    {
        _currentVelocity = 3;
        _currentInc = Input.GetAxis("Vertical");
        _giro = Input.GetAxis("Horizontal");
    }

    void CalculeGiro()
    {
        //Quaternion newQ = new Quaternion(transform.rotation.x, transform.rotation.y + Client.Instance._controllData.currentInc, transform.rotation.z + Client.Instance._controllData.giro, 1);
        //transform.rotation = Quaternion.Lerp(transform.rotation, newQ, Time.deltaTime * _velRotation);
    }

    void MoveShip()
    {
        _rb.AddRelativeForce(Vector3.forward * 0 * Time.deltaTime, ForceMode.Impulse);
    }

    public void setCurrentVelocity(int value)
    {
        _currentVelocity = value;
    }

}