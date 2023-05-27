using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class StageSelectManager : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private GameObject emptyui;

    [SerializeField]
    private ss_background background;
    
    [SerializeField, Header("UI")]
    private List<StageSelectUI> uis = new List<StageSelectUI>();

    [SerializeField, Header("Icon")]
    private IconManager iconManager;
    private List<IconManager> iconManagers = new List<IconManager>();
    private GameObject imManager;

    [SerializeField]
    private Image mask;

    [SerializeField]
    private float distanceX = 3840;

    [SerializeField, Range(0, 10)]
    private float moveSpeed = 2;

    [SerializeField, Range(0, 3)]
    private int worldIndexLimit = 0;
    private int worldIndex = 0;

    private bool active = true;

    private SceneChange sceneChange;

    private float m_InputVolum = 0;         // 十字キー入力
    private float m_InputVolumStick = 0;    // スティック入力

    private SoundManager sound;

    void Start()
    {
        var datas = GameObject.Find("Datas");
        var data = datas.GetComponent<ScoreData>();
        var save = datas.GetComponent<SaveManager>();

        // ワールド限界値取得
        worldIndexLimit = save.data.worldindex;

        // 背景
        background = Instantiate(background, canvas.transform);
        background.SetBG(worldIndex);

        // UI
        var obj = Instantiate(emptyui, canvas.transform);
        obj.name = "UIs";

        for(int i = 0; i < uis.Count; ++i)
        {
            uis[i] = Instantiate(uis[i], obj.transform);
            uis[i].Activate(worldIndex, worldIndexLimit);
        }

        // アイコン
        imManager = Instantiate(emptyui, canvas.transform); 
        imManager.name = "iconManagers";
        imManager.GetComponent<RectTransform>().anchoredPosition
            = new Vector2(-distanceX * 2 * worldIndex, 0);

        for (int i = 0; i < Co.Const.WORLD_NUM * 2 - 1; ++i)
        {
            if ((i & 1) == 0)
            {
                iconManagers.Add(Instantiate(iconManager, imManager.transform));
                iconManagers[i / 2].GetComponent<RectTransform>().anchoredPosition
                 = new Vector2(i * distanceX, 0);
                iconManagers[i / 2].CreateIcons(i / 2, save);
            }
            else
            {
                var pmask = Instantiate(mask, imManager.transform);
                pmask.GetComponent<RectTransform>().anchoredPosition = new Vector2(i * distanceX, 0);
            }
        }

        sceneChange = GameObject.Find("SceneChange").GetComponent<SceneChange>();

        Inactivate(data.WorldIndex, data.StageIndex);

        sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        if(!sound.CheckPlayBGM("タイトルBGM")) sound.BGMPlay("タイトルBGM", true);
    }

    void Update()
    {
        if (!active)
        {
            // シーン遷移終了待機
            
        }
        else
        {
            if (sceneChange.isFade)
            {
                Inactivate();
                //active = false;
                //return;
            }

            // 選択された
            if (Input.GetKeyDown("joystick button 0") || Input.GetMouseButton(0))
            {
                iconManagers[worldIndex].Pushed();
                sound.SEPlay("ステージ決定SE");
            }
            // タイトル戻る
            else if (Input.GetKeyDown("joystick button 1") ||  Input.GetMouseButton(2))
            {
                GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene("TitleTest");
                Inactivate();
                sound.SEPlay("戻るSE");
                Destroy(this);
            }
            // ワールド移動右
            else if ((Input.GetKeyDown("joystick button 5") ||  Input.GetKeyDown(KeyCode.D)) && worldIndex < worldIndexLimit)
            {
                Inactivate(1);
            }
            // ワールド移動左
            else if ((Input.GetKeyDown("joystick button 4") ||  Input.GetKeyDown(KeyCode.A)) && worldIndex > 0)
            {
                Inactivate(-1);
            }
            // ステージ移動
            else
            {
                //////////////////////////////////////////////
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    iconManagers[worldIndex].MoveCursor(1);
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    iconManagers[worldIndex].MoveCursor(-1);
                }
                //////////////////////////////////////////////
                // 十字キー入力
                {
                    var newvolum = Input.GetAxis("JuujiKeyX");
                 
                    if (m_InputVolum != newvolum)
                    {
                        SelectChange(-newvolum);
                    }
                    m_InputVolum = newvolum;
                }
                // スティック入力
                {
                    var newvolum = Input.GetAxis("Horizontal");

                    if (m_InputVolumStick != newvolum)
                    {
                        SelectChange(-newvolum);
                    }
                    m_InputVolumStick = newvolum;
                }
            }
        }
    }

    private void Activate(int _stageindex)
    {
        foreach (var ui in uis)
        {
            ui.Activate(worldIndex, worldIndexLimit);
        }

        iconManagers[worldIndex].Activate(_stageindex);
        active = true;
    }

    private void Inactivate()
    {
        active = false;

        iconManagers[worldIndex].Inactivate();
    }

    private void Inactivate(int _way, int _stageindex = 0)
    {
        if (_way == 0)
        {
            iconManagers[worldIndex].Activate(_stageindex);
            return;
        }

        foreach (var ui in uis)
        {
            ui.Inactivate();
        }

        iconManagers[worldIndex].Inactivate();

        worldIndex += _way;

        active = false;
        sound.SEPlay("選択SE");
        StartCoroutine(MoveIcons(_way, _stageindex));
    }

    private IEnumerator MoveIcons(int _way, int _stageindex)
    {
        WaitForSeconds ws = new WaitForSeconds(0.001f);

        Vector2 defpos = imManager.transform.localPosition;
        Vector2 tgtpos = new Vector2(imManager.transform.localPosition.x - distanceX * 2 * _way, 0);
        float param = 0;

        while(param < 1)
        {
            imManager.transform.localPosition = Vector2.Lerp(defpos, tgtpos, param);

            // bg切り替え
            if (param >= 0.49f && param <= 0.51f)
            {
                background.SetBG(worldIndex);
            }

            param += 0.01f * moveSpeed;
            yield return ws;
        }
        Activate(_stageindex);
        yield break;
    }

    private void SelectChange(float _volum)
    {
        if ((int)_volum == 0) return;

        int num = 0;

        if (_volum < 0) num = 1;
        else if (_volum > 0) num = -1;

        if(iconManagers[worldIndex].MoveCursor(num))
            sound.SEPlay("選択SE");
    }
}
