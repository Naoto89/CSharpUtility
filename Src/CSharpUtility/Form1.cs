using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpUtility
{
    public partial class Form1 : Form
    {
        private CustomTrackBar m_trackBar = null;
        private int m_iThumbNum = 2;
        public Form1()
        {
            InitializeComponent();
            m_trackBar = new CustomTrackBar(100, m_iThumbNum, new Size(640,50));
            this.Controls.Add(m_trackBar);
            m_trackBar.SetEventHandlerOnMouseUp(new CustomTrackBar.WhenMouseUp(this.OnMouseMoveTrackBar));
        }

        public void OnMouseMoveTrackBar()
        {
            string strTmp = "";
            for (int i = 0; i < m_iThumbNum; ++i)
            {
                strTmp += $"[ID:{i}] pos = {m_trackBar.GetCurrentThumbPos(i),4} ";
            }
            strTmp += "\r\n";
            textBox1.Text += strTmp;
        }

    }
}
