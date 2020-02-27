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
using UniRx;

public class GlobalConfiger 
{
    /// <summary>
    /// 目前运行模式
    /// </summary>
    public static BoolReactiveProperty EditorMode = new BoolReactiveProperty(true);


}