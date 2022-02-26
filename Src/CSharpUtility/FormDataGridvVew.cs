using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSharpUtility
{
    public partial class FormDataGridvVew : Form
    {
        /// <summary>
        /// DataGridViewに設定されたパスを返す
        /// </summary>
        public List<string> Pathes
        {
            get
            {
                List<string> list = new List<string>();
                for (int i = 0; i < m_dataGridView.Rows.Count; ++i)
                {
                    list.Add(m_dataGridView.Rows[i].Cells[0].Value.ToString());
                }
                return list;
            }
        }


        public FormDataGridvVew()
        {
            InitializeComponent();
            
            m_dataGridView.AllowUserToAddRows = false;// 新しい行を非表示
            m_dataGridView.DefaultCellStyle.Font = this.Font;//フォントはフォームと同じにする
            m_dataGridView.ColumnCount = 1;
            ////////////////////////////////////////
            // 2列目にボタンを表示
            ////////////////////////////////////////
            DataGridViewButtonColumn column = new DataGridViewButtonColumn();
            //列の名前を設定
            column.Name = "Button";
            //全てのボタンにTextを表示する
            column.UseColumnTextForButtonValue = true;
            column.Text = "...";// ファイル選択ダイアログを意識したボタン
            m_dataGridView.Columns.Add(column);

            // 列ヘッダーのテキスト設定
            //m_dataGridView.Columns[0].HeaderText = "0";
            //m_dataGridView.Columns[1].HeaderText = "1";

            // 行ヘッダーの幅設定
            m_dataGridView.RowHeadersWidth = (int)(m_dataGridView.Width * 0.14);

            // 列の幅設定
            m_dataGridView.Columns[0].Width = (int)(m_dataGridView.Width * 0.75);
            m_dataGridView.Columns[1].Width = (int)(m_dataGridView.Width * 0.1);
        }

        private void m_btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void m_btnAddRow_Click(object sender, EventArgs e)
        {
            m_dataGridView.Rows.Add("");
        }

        /// <summary>
        /// 選択されている行削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_btnDeleteRow_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in m_dataGridView.SelectedRows)
            {
                if (!r.IsNewRow)
                {
                    m_dataGridView.Rows.Remove(r);
                }
            }
        }

        private void m_dataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // 描画領域の設定
            Rectangle rect = new Rectangle(
              e.RowBounds.Location.X+20,
              e.RowBounds.Location.Y,
              m_dataGridView.RowHeadersWidth - 20,
              e.RowBounds.Height);

            // 上記の長方形内に行番号を縦方向中央＆左詰めで描画する
            // フォントや前景色は行ヘッダの既定値を使用する
            TextRenderer.DrawText(
              e.Graphics,
              $"[{e.RowIndex + 1}]",
              m_dataGridView.RowHeadersDefaultCellStyle.Font,
              rect,
              m_dataGridView.RowHeadersDefaultCellStyle.ForeColor,
              TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
        }

        private void m_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // クリックされたセルの列がボタン表示列かチェック
            if (e.ColumnIndex == 1)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    //ボタンの左隣のセルにパスを設定
                    m_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value = ofd.FileName;
                }
            }
        }
    }
}
