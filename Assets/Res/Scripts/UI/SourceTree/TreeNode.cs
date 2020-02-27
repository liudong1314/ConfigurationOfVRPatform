/****************************************************************************
 * 2020.2 DESKTOP-PBQ45G2
 ****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using UniRx;
using UniRx.Triggers;

namespace QFramework.ChivaConfigurationVRPatform
{
	public partial class TreeNode : UIElement
	{  
        public TreeNodeItem treeNodeItem = new TreeNodeItem();

        private void Start()
        {
            Init();
        }

        public void Init()
        {  
            //停止编辑
            nodeInputField.onEndEdit.AddListener(value => 
            {
                nodeClickBtn.transform.Find("Text").GetComponent<Text>().text = value;
                treeNodeItem.content = value;
            });
            
            //节点点击
            nodeClickBtn.onClick.AddListener(() => Debug.LogError(nodeClickBtn.transform.Find("Text").GetComponent<Text>().text));

            //增加节点点击
            addChildNodeBtn.onClick.AddListener(AddChildNode);
            
            //删除节点点击
            removeSelfBtn.onClick.AddListener(() => 
            {
                if (treeNodeItem.parentNode != null)
                {
                    treeNodeItem.parentNode.treeNodeItem.childTreeNodes.Remove(this);
                }
                RemoveChildNode(this);
            });

            GlobalConfiger.EditorMode.Subscribe(value => 
            {
                if (value)
                {
                    addChildNodeBtn.gameObject.SetActive(true);
                    nodeInputField.gameObject.SetActive(true);
                    removeSelfBtn.gameObject.SetActive(true);
                    nodeClickBtn.gameObject.SetActive(false);
                }
                else
                {
                    addChildNodeBtn.gameObject.SetActive(false);
                    nodeInputField.gameObject.SetActive(false);
                    removeSelfBtn.gameObject.SetActive(false);
                    nodeClickBtn.gameObject.SetActive(true);
                }

            });

            showORHide.isOn = treeNodeItem.expende.Value;
            showORHide.onValueChanged.AddListener(isOn => treeNodeItem.expende.Value = isOn);
            treeNodeItem.expende.Subscribe(isOn =>
            {
                if (isOn)
                {  
                    ChangeChildState(treeNodeItem.childTreeNodes, true);
                }
                else
                {
                    ChangeChildState(treeNodeItem.childTreeNodes, false);
                }
            });

            //数量监听
            treeNodeItem.childTreeNodes.ObserveCountChanged().Subscribe(count => 
            {
                if (count > 0)
                {
                    showORHide.gameObject.SetActive(true);
                    treeNodeItem.expende.Value = true;
                }
                else
                {
                    showORHide.gameObject.SetActive(false);
                    treeNodeItem.expende.Value = false;
                }
                showORHide.isOn = treeNodeItem.expende.Value;
            });
        }

        /// <summary>
        /// 改变子节点状态
        /// </summary>
        public void ChangeChildState(ReactiveCollection<TreeNode> treeNodes,bool show)
        {
            treeNodes.ForEach(item =>
            { 
                if (item.treeNodeItem.expende.Value) ChangeChildState(item.treeNodeItem.childTreeNodes, show);
                item.gameObject.SetActive(show);
            }
            );
            
        }

        /// <summary>
        /// 添加子节点
        /// </summary>
        public void AddChildNode()
        {
            //克隆子节点
            GameObject childNode = Instantiate(treeNodeItem.prefab, treeNodeItem.cloneConent);

            //设置层级
            int layer = transform.GetSiblingIndex();
            int tempCount = GetChildCount(this);
            childNode.transform.SetSiblingIndex(layer + treeNodeItem.childTreeNodes.Count + 1);

            //添加信息
            TreeNode treeNode = childNode.GetComponent<TreeNode>();
            treeNode.treeNodeItem.prefab = treeNodeItem.prefab;
            treeNode.treeNodeItem.cloneConent = treeNodeItem.cloneConent;
            treeNode.treeNodeItem.layer.Value = treeNodeItem.layer.Value + 1;
            treeNode.treeNodeItem.parentNode = this;
            treeNodeItem.childTreeNodes.Add(treeNode);


            //移动位置
            childNode.transform.Find("Editor").transform.position += Vector3.right * treeNode.treeNodeItem.layer.Value * 0.2f;

            //显示对象
            childNode.SetActive(true);
        }

        /// <summary>
        /// 删除此节点
        /// </summary>
        public void RemoveChildNode(TreeNode treeNode)
        {
            foreach (var item in treeNode.treeNodeItem.childTreeNodes)
            {   
                RemoveChildNode(item);
            }

            Destroy(treeNode.gameObject);
        }

		protected override void OnBeforeDestroy()
		{
		}

        /// <summary>
        /// 得到它孪生的所有的节点个数
        /// </summary>
        /// <returns></returns>
        private int GetChildCount(TreeNode tree)
        {
            int count = 0;

            if (tree.treeNodeItem.childTreeNodes.Count == 0)
            {
                return count;
            }
            else
            {
                foreach (var item in treeNodeItem.childTreeNodes)
                {
                    count += GetChildCount(item);
                }
            }

            return count;
        }

    }
}