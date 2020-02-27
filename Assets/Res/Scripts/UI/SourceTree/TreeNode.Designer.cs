/****************************************************************************
 * 2020.2 DESKTOP-PBQ45G2
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.ChivaConfigurationVRPatform
{
	public partial class TreeNode
	{
		[SerializeField] public UnityEngine.UI.Toggle showORHide;
		[SerializeField] public UnityEngine.UI.Button nodeClickBtn;
		[SerializeField] public UnityEngine.UI.InputField nodeInputField;
		[SerializeField] public UnityEngine.UI.Button removeSelfBtn;
		[SerializeField] public UnityEngine.UI.Button addChildNodeBtn;

		public void Clear()
		{
			showORHide = null;
			nodeClickBtn = null;
			nodeInputField = null;
			removeSelfBtn = null;
			addChildNodeBtn = null;
		}

		public override string ComponentName
		{
			get { return "TreeNode";}
		}
	}
}
