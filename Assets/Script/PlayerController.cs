using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float power = 100f; // ������ ȸ����ų ��
    public float rot = 45f; // ������ ȸ�� ����
    Rigidbody rb;
    public WheelCollider[] wheels = new WheelCollider[4];
    // ���� ���� ���� �κ� 4��
    GameObject[] wheelMesh = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
        wheelMesh = GameObject.FindGameObjectsWithTag("WheelMesh");

        for (int i = 0; i < wheelMesh.Length; i++)
        {	// ���ݶ��̴��� ��ġ�� �����޽��� ��ġ�� ���� �̵���Ų��.
            wheels[i].transform.position = wheelMesh[i].transform.position;
            rb = GetComponent<Rigidbody>();
            // ���� �߽��� y�� �Ʒ��������� �����.
            rb.centerOfMass = new Vector3(0, -1, 0);
        }
    }
    void Update()
    {
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < wheels.Length; i++)
        {
            // for���� ���ؼ� ���ݶ��̴� ��ü�� Vertical �Է¿� ���� power��ŭ�� ������ �����̰��Ѵ�.
            wheels[i].motorTorque = Input.GetAxis("Vertical") * power;
        }
        for (int i = 0; i < 2; i++)
        {
            // �չ����� ������ȯ�� �Ǿ���ϹǷ� for���� �չ����� �ش�ǵ��� �����Ѵ�.
            wheels[i].steerAngle = Input.GetAxis("Horizontal") * rot;
        }
    }
    void WheelPosAndAni()
    {
        Vector3 wheelPosition = Vector3.zero;
        Quaternion wheelRotation = Quaternion.identity;

        for (int i = 0; i < 4; i++)
        {
            wheels[i].GetWorldPose(out wheelPosition, out wheelRotation);
            wheelMesh[i].transform.position = wheelPosition;
            wheelMesh[i].transform.rotation = wheelRotation;
        }
    }
}

// Update is called once per frame



