namespace QFramework.ChivaConfigurationVRPatform
{
    using UnityEngine;
    using System.Collections;
    using UniRx;


    public class TreeNodeItem
    {
        /// <summary>
        /// 是否展开
        /// </summary>
        public BoolReactiveProperty expende = new BoolReactiveProperty(false);

        /// <summary>
        /// 所处层级
        /// </summary>
        public IntReactiveProperty layer = new IntReactiveProperty();

        /// <summary>
        /// 子节点
        /// </summary>
        public ReactiveCollection<TreeNode> childTreeNodes = new ReactiveCollection<TreeNode>();

        /// <summary>
        /// 父节点
        /// </summary>
        public TreeNode parentNode;

        /// <summary>
        /// 内容
        /// </summary>
        public string content;

        /// <summary>
        /// 克隆位置
        /// </summary>
        public Transform cloneConent;

        /// <summary>
        /// 预制体
        /// </summary>
        public GameObject prefab;

    }
}
