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

        UpdateInputs();
        CalculeGiro();
        MoveShip();
    }

    void UpdateInputs()
    {
        _currentVelocity = 3;
        _currentInc = Input.GetAxisRaw("Vertical");
        _currentGiro = Input.GetAxisRaw("Horizontal");
    }

    void CalculeGiro()
    {

        Quaternion newQ = new Quaternion(transform.rotation.x - (_currentInc * 0.01f), transform.rotation.y + (_currentGiro * 0.01f), transform.rotation.z, 1);
        transform.rotation = Quaternion.Lerp(transform.rotation, newQ, Time.deltaTime * _velRotation * 25f);
        //transform.rotation = newQ;

    }

    void MoveShip()
    {
        _rb.AddRelativeForce(Vector3.forward * 5 * Time.deltaTime, ForceMode.Impulse);
        _rb.velocity = transform.forward * 100 * Time.deltaTime;
    }

    public void setCurrentVelocity(int value)
    {
        _currentVelocity = value;
    }

}