using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleObjectList : MonoBehaviour
{
    [System.Serializable]
    public class Object
    {
        [SerializeField]
        private TitleStateEnum.STATE m_state;
        public TitleStateEnum.STATE m_State
        {
            get => m_state;
        }

        [SerializeField]
        private List<TitleUI> m_ui;
        public List<TitleUI> m_Ui
        {
            get => m_ui;
        }

        [SerializeField]
        private List<TitleObject> m_objects;
        public List<TitleObject> m_Objects
        {
            get => m_objects;
        }
    }

    [SerializeField]
    private List<Object> m_Objects;

    /// <summary>
    /// オブジェクト生成
    /// </summary>
    /// <param name="_state">状態指定</param>
    /// <param name="_canvas">使うキャンバス</param>
    public void CreateObjects(TitleStateEnum.STATE _state, Canvas _canvas)
    {
        // リストの探索
        foreach(var objs in m_Objects)
        {
            // 指定された状態発見
            if (objs.m_State == _state)
            {
                // UI生成
                if (objs.m_Ui.Capacity > 0)
                    CreateUI(objs, _canvas);
                
                // オブジェクト生成
                if (objs.m_Objects.Capacity > 0)
                    CreateObject(objs);
                
                break;
            }
        }
    }

    private void CreateUI(Object _obj, Canvas _canvas)
    {
        foreach(var ui in _obj.m_Ui)
        {
            var obj = Instantiate(ui);
            obj.transform.SetParent(_canvas.transform, false);
        }
    }

    private void CreateObject(Object _obj)
    {
        foreach(var obj in _obj.m_Objects)
        {
            Instantiate(obj);
        }
    }
}
