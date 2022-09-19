using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    //IA
    public Button _off;
    public Button _on;
    public LayerMask _canBeClicked;
    public bool _isClikMove = true;
    private NavMeshAgent _agent;

    //
    public GameObject _pivot;
    private CharacterController _characterController;
    public float _speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isClikMove)
        {
            _pivot.transform.position = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
            transform.LookAt(-_pivot.transform.position);
            float verticalMove = Input.GetAxis("Vertical");
            if (verticalMove != 0)
            {
                //_characterController.Move(Vector3.forward * Time.deltaTime * _speed * verticalMove);
                transform.forward = Vector3.forward * _speed * verticalMove;
            }
            else
            {
                _characterController.Move(Vector3.zero * Time.deltaTime * _speed * 0);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if(Physics.Raycast(myRay, out hit, 100, _canBeClicked))
                {
                    print(hit.collider.gameObject.name);
                    _agent.SetDestination(hit.point);                
                }
            }
        }
    }

    #region Buttons

    public void setClickMode(bool isClick)
    {
        if (isClick)
        {
            _off.gameObject.SetActive(false);
            _on.gameObject.SetActive(true);
            _characterController.enabled = false;
        }
        else
        {
            _off.gameObject.SetActive(true);
            _on.gameObject.SetActive(false);
            _characterController.enabled = true;
        }
        _isClikMove = isClick;
    }

    #endregion
}
