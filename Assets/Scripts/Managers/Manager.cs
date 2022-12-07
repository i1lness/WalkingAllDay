using UnityEngine;

public class Manager : MonoBehaviour
{
    static Manager s_instance;
    static Manager Instance { get { Init(); return s_instance; } }

    InputManager _inputManager = new InputManager();

    public static InputManager Input { get { return Instance._inputManager; } }

    void Start()
    {
        Init();
    }

    void Update()
    {
        Input.OnUpdate();
    }

    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Manager");
            if (go == null)
            {
                go = new GameObject { name = "@Manager" };
            }
            if (go.GetComponent<Manager>() == null)
            {
                go.AddComponent<Manager>();
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Manager>();
        }
    }
}
