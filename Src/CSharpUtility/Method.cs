using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace CSharpUtility
{
    class Method
    {
        /// <summary>
        /// プロパティグリッドの説明文欄の高さを変更する
        /// </summary>
        /// <param name="grid">対象のプロパティグリッド</param>
        /// <param name="iHeight">変更後の高さ(px)</param>
        static public void ResizeDescriptionArea(PropertyGrid grid, int iHeight)
        {
            try
            {
                var info = grid.GetType().GetProperty("Controls");
                var collection = (Control.ControlCollection)info.GetValue(grid, null);

                foreach (Control ctrl in collection)
                {
                    var type = ctrl.GetType();

                    if ("DocComment" == type.Name)
                    {
                        const BindingFlags Flags = BindingFlags.Instance | BindingFlags.NonPublic;
                        var field = type.BaseType.GetField("userSized", Flags);
                        field.SetValue(ctrl, true);
                        ctrl.Height = iHeight;
                        break;
                    }
                }
            }
            catch (Exception /*ex*/)
            {
                //Error handling
            }
        }
    }
}
