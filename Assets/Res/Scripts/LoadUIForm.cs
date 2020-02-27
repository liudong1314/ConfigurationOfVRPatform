/*******************************************************************
* Copyright(c) #YEAR# #COMPANY#
* All rights reserved.
*
* 文件名称: #SCRIPTFULLNAME#
* 简要描述:
* 
* 创建日期: #DATE#
* 作者:     #AUTHOR#
* 说明:  
******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
public class LoadUIForm : MonoBehaviour
{
    public string PanelName;

    public bool editor = true;

    private void Awake()
    {
        ResMgr.Init();
    }
    void Start()
	{
        UIMgr.OpenPanel(PanelName, UILevel.Common);
        //UIManager.Instance.OpenUI(UIForms.SourceTreeForm,UILevel.Common,null,UIFormAssetBundleName.sourcetree_prefab);
	}


    private void Update()
    {
        GlobalConfiger.EditorMode.Value = editor;
    }

}