using UnityEngine;

public class Manager : MonoBehaviour
{
    static Manager s_instance; // static���� �����Ͽ� ����� Manager ������Ʈ�� �ϳ��� �����ϰ� �Ѵ�
    InputManager _inputManager = new InputManager(); // InputManager�� Manager �ȿ� ���� �� �����Ͽ� �ϳ��� �����ϰ�(���ٰ����ϰ�)�Ѵ�

    static Manager Instance { get { Init(); return s_instance; } } // Manager Property

    public static InputManager Input { get { return Instance._inputManager; } } // InputManager Property

    void Start()
    {
        Init();
    }

    void Update()
    {
        Input.OnUpdate(); // InputManager�� �� �����Ӹ��� Ȯ���ؾ� �� ���� ��Ƴ��� �Լ�
    }

    static void Init() // @Manager������Ʈ �ʱ� ���� �Լ�
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Manager"); // @Manager�� ã�ƺ���

            if (go == null) // ���� �������� ������ @Manager������Ʈ�� �ϳ� ����
            {
                go = new GameObject { name = "@Manager" };
            }
            if (go.GetComponent<Manager>() == null) // @Manager�� Manager��ũ��Ʈ�� ������ ��ũ��Ʈ�� �߰�
            {
                go.AddComponent<Manager>();
            }

            DontDestroyOnLoad(go); // @Manager������Ʈ�� DontDestroyOnLoad�� �÷����� Destory�� ���´�

            s_instance = go.GetComponent<Manager>(); // static���� ������Ʈ ���� (��Ȯ���� �ش� ������Ʈ�� Manager ������Ʈ�� �����Ѵ�)
        }
    }
}
