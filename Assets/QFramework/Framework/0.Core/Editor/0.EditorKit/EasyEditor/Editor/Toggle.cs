using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace UnityEditorUI
{
    /// <summary>
    /// Widget for displaying read-only text.
    /// </summary>
    public interface IToggle : IWidget
    {
        /// <summary>
        /// Label text.
        /// </summary>
        IPropertyBinding<string, IToggle> Text { get; }

        /// <summary>
        /// Text displayed on mouse hover.
        /// </summary>
        IPropertyBinding<bool, IToggle> On { get; }

        /// <summary>
        /// Whether or not the label should be displayed in bold (default is false).
        /// </summary>
        //IPropertyBinding<bool, ILabel> Bold { get; }

        /// <summary>
        /// Width of the widget in pixels. Default uses auto-layout.
        /// </summary>
        //IPropertyBinding<int, ILabel> Width { get; }

        /// <summary>
        /// Height of the widget in pixels. Default uses auto-layout.
        /// </summary>
        //IPropertyBinding<int, ILabel> Height { get; }
    }

    /// <summary>
    /// Widget for displaying read-only text.
    /// </summary>
    internal class Toggle : AbstractWidget, IToggle
    {
        private string text = string.Empty;
        private bool   on   = false;

        private PropertyBinding<string, IToggle> textProperty;
        private PropertyBinding<bool, IToggle>   onProperty;

        public IPropertyBinding<string, IToggle> Text
        {
            get { return textProperty; }
        }

        public IPropertyBinding<bool, IToggle> On
        {
            get { return onProperty; }
        }

        internal Toggle(ILayout parent, int width) : base(parent)
        {
            textProperty = new PropertyBinding<string, IToggle>(
                this,
                value => text = value
            );

            onProperty = new PropertyBinding<bool, IToggle>(
                this,
                value => on = value
            );

            mWidth = width;
        }

        private int mWidth;

        public override void OnGUI()
        {
            var newOn = false;

            if (mWidth == -1)
            {
                GUILayout.Toggle(@on, text);
            }
            else
            {
                GUILayout.Toggle(@on, text, GUILayout.Width(mWidth));
            }

            if (newOn != @on)
            {
                on = newOn;
                onProperty.UpdateView(newOn);
            }
        }

        public override void BindViewModel(object viewModel)
        {
            textProperty.BindViewModel(viewModel);
            onProperty.BindViewModel(viewModel);
        }
    }
}