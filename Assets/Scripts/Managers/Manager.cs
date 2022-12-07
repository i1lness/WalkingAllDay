using UnityEngine;

public class Manager : MonoBehaviour
{
    static Manager s_instance; // static으로 선언하여 사용할 Manager 컴포넌트를 하나만 존재하게 한다
    InputManager _inputManager = new InputManager(); // InputManager를 Manager 안에 선언 및 정의하여 하나만 존재하게(접근가능하게)한다

    static Manager Instance { get { Init(); return s_instance; } } // Manager Property

    public static InputManager Input { get { return Instance._inputManager; } } // InputManager Property

    void Start()
    {
        Init();
    }

    void Update()
    {
        Input.OnUpdate(); // InputManager가 매 프레임마다 확인해야 할 것을 모아놓은 함수
    }

    static void Init() // @Manager오브젝트 초기 설정 함수
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Manager"); // @Manager를 찾아본다

            if (go == null) // 만약 존재하지 않으면 @Manager오브젝트를 하나 생성
            {
                go = new GameObject { name = "@Manager" };
            }
            if (go.GetComponent<Manager>() == null) // @Manager에 Manager스크립트가 없으면 스크립트를 추가
            {
                go.AddComponent<Manager>();
            }

            DontDestroyOnLoad(go); // @Manager오브젝트를 DontDestroyOnLoad에 올려놓아 Destory를 막는다

            s_instance = go.GetComponent<Manager>(); // static으로 오브젝트 저장 (정확히는 해당 오브젝트의 Manager 컴포넌트를 저장한다)
        }
    }
}
