using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Drawing;

namespace CSharpUtility
{
    /// <summary>
    /// ver.1.0
    /// 下記URLのサンプルコードを修正して、複数つまみに対応
    /// https://docs.microsoft.com/ja-jp/dotnet/api/system.windows.forms.trackbarrenderer?view=windowsdesktop-6.0
    /// </summary>
    class CustomTrackBar : Control
    {
        private int m_iNumberTicks = 10;//目盛りの数
        private Rectangle m_rtTrackRectangle = new Rectangle();//トラックバー領域の矩形サイズ
        private Rectangle m_rtTicksRectangle = new Rectangle();//目盛りの矩形サイズ
        private float m_fTickSpace = 0;//目盛り間隔
        public delegate void WhenMouseUp();
        WhenMouseUp m_delgMouseUp = null;
        /// <summary>
        /// つまみに関する情報をまとめたクラス
        /// </summary>
        public class ThumbInfo
        {
            public int CurrentTickPos { get; set; }//つまみの現在位置
            public Rectangle Rect { get; set; }//つまみの矩形サイズ、位置
            public bool Clicked { get; set; }//つまみをクリックしたか否か
            public TrackBarThumbState State { get; set; }//つまみの状態

            public ThumbInfo()
            {
                CurrentTickPos = 100;
                Rect = new Rectangle();
                Clicked = false;
                State = TrackBarThumbState.Normal;
            }

            public ThumbInfo(int currentTickPos, Rectangle rect, bool clicked, TrackBarThumbState state)
            {
                CurrentTickPos = currentTickPos;
                Rect = rect;
                Clicked = clicked;
                State = state;
            }
        }

        /// <summary>
        /// 目盛りを表示するか否か
        /// </summary>
        private bool VisibleTicks { get; set; } = true;

        //private ThumbInfo[] m_aryThumbInfo = null;
        private List<ThumbInfo> m_aryThumbInfo = new List<ThumbInfo>();
        /// <summary>
        /// カスタムトラックバーのコンストラクタ
        /// </summary>
        /// <param name="iTicksNum">目盛りの数</param>
        /// <param name="iThumbNum">つまみの数</param>
        /// <param name="szTrackBarSize">トラックバー領域のサイズ</param>
        public CustomTrackBar(int iTicksNum, int iThumbNum, Size szTrackBarSize)
        {
            this.Location = new Point(10, 10);
            this.Size = szTrackBarSize;
            this.m_iNumberTicks = iTicksNum;
            this.BackColor = Color.DarkCyan;
            this.DoubleBuffered = true;

            for (int i = 0; i < iThumbNum; ++i)
            {
                m_aryThumbInfo.Add(new ThumbInfo());
            }
            SetupTrackBar();
        }

        /// <summary>
        /// 現在のつまみの位置を返す
        /// </summary>
        /// <param name="iThumbID">つまみ番号</param>
        /// <returns></returns>
        public int GetCurrentThumbPos(int iThumbID)
        {
            return CurrentTickXCoordinate(iThumbID);
        }

        /// <summary>
        /// マウスアップしたときのイベントハンドラー設定
        /// </summary>
        /// <param name="eh"></param>
        public void SetEventHandlerOnMouseUp(WhenMouseUp delgMouseUp)
        {
            m_delgMouseUp += delgMouseUp;
        }
        // Calculate the sizes of the bar, thumb, and ticks rectangle.
        private void SetupTrackBar()
        {
            if (!TrackBarRenderer.IsSupported)
            {
                return;
            }

            using (Graphics g = this.CreateGraphics())
            {
                // トラックバー領域のサイズ、位置の設定
                m_rtTrackRectangle.X = ClientRectangle.X + 2;
                m_rtTrackRectangle.Y = ClientRectangle.Y + 28;
                m_rtTrackRectangle.Width = ClientRectangle.Width - 4;
                m_rtTrackRectangle.Height = 4;

                // トラックバー領域の中で目盛りを描画する位置大きさを設定
                m_rtTicksRectangle.X = m_rtTrackRectangle.X + 4;
                m_rtTicksRectangle.Y = m_rtTrackRectangle.Y - 8;
                m_rtTicksRectangle.Width = m_rtTrackRectangle.Width - 8;
                m_rtTicksRectangle.Height = 4;

                // 目盛り間隔設定
                m_fTickSpace = ((float)m_rtTicksRectangle.Width - 1) / ((float)m_iNumberTicks - 1);

                // つまみの位置大きさ設定
                for (int i = 0; i < m_aryThumbInfo.Count; ++i)
                {
                    m_aryThumbInfo[i].CurrentTickPos = (int)(i * m_fTickSpace);

                    Size szTmp = TrackBarRenderer.GetTopPointingThumbSize(g, TrackBarThumbState.Normal);
                    Rectangle rect = new Rectangle(
                        CurrentTickXCoordinate(i)
                        , m_rtTrackRectangle.Y - 8
                        , szTmp.Width
                        , szTmp.Height
                        );

                    m_aryThumbInfo[i].Rect = rect;
                }
            }
        }

        private int CurrentTickXCoordinate(int iThumID)
        {
            if (m_fTickSpace == 0)
            {
                return 0;
            }
            else
            {
                return ((int)Math.Round(m_fTickSpace) * m_aryThumbInfo[iThumID].CurrentTickPos);
            }
        }

        // Draw the track bar.
        protected override void OnPaint(PaintEventArgs e)
        {
            if (!TrackBarRenderer.IsSupported)
            {
                return;
            }
            // トラックバーの領域を描画
            TrackBarRenderer.DrawHorizontalTrack(e.Graphics, m_rtTrackRectangle);
            
            // 目盛りの描画
            if(this.VisibleTicks)
            {
                TrackBarRenderer.DrawHorizontalTicks(e.Graphics, m_rtTicksRectangle, m_iNumberTicks, EdgeStyle.Raised);
            }

            // つまみの描画
            for (int i = 0; i < m_aryThumbInfo.Count; ++i)
            {
                TrackBarRenderer.DrawTopPointingThumb(e.Graphics,  m_aryThumbInfo[i].Rect, m_aryThumbInfo[i].State);
            }
        }

        // Determine whether the user has clicked the track bar thumb.
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!TrackBarRenderer.IsSupported)
            {
                return;
            }

            // つまみをクリックしたか否かの判定
            for (int i = 0; i < m_aryThumbInfo.Count; ++i)
            {
                if ( m_aryThumbInfo[i].Rect.Contains(e.Location))
                {
                    m_aryThumbInfo[i].Clicked = true;
                    m_aryThumbInfo[i].State = TrackBarThumbState.Pressed;
                }
            }
            Invalidate();
        }

        // Redraw the track bar thumb if the user has moved it.
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (!TrackBarRenderer.IsSupported)
            {
                return;
            }
            // つまみを放したときの状態更新
            for (int i = 0; i < m_aryThumbInfo.Count; ++i)
            {
                if (m_aryThumbInfo[i].Clicked)
                {
                    if (e.Location.X > m_rtTrackRectangle.X &&
                        e.Location.X < (m_rtTrackRectangle.X +
                        m_rtTrackRectangle.Width -  m_aryThumbInfo[i].Rect.Width))
                    {
                        m_aryThumbInfo[i].State = TrackBarThumbState.Hot;
                    }

                    m_aryThumbInfo[i].Clicked = false;
                    this.Invalidate();
                }
            }
        }
        // Track cursor movements.
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!TrackBarRenderer.IsSupported)
            {
                return;
            }
            // つまみを動かし時の制御
            for (int i = 0; i < m_aryThumbInfo.Count; ++i)
            {
                // どのつまみをつかんでいるか
                if (m_aryThumbInfo[i].Clicked == true)
                {
                    // Track movements to the next tick to the right, if 
                    // the cursor has moved halfway to the next tick.
                    if (m_aryThumbInfo[i].CurrentTickPos < m_iNumberTicks - 1 && e.Location.X > CurrentTickXCoordinate(i) + (int)(m_fTickSpace))
                    {
                        ++m_aryThumbInfo[i].CurrentTickPos;
                    }

                    // Track movements to the next tick to the left, if 
                    // cursor has moved halfway to the next tick.
                    else if (m_aryThumbInfo[i].CurrentTickPos > 0 && e.Location.X < CurrentTickXCoordinate(i) - (int)(m_fTickSpace / 2))
                    {
                        --m_aryThumbInfo[i].CurrentTickPos;
                    }
                    Rectangle rtTmp = new Rectangle(
                      CurrentTickXCoordinate(i)
                    , m_aryThumbInfo[i].Rect.Y
                    , m_aryThumbInfo[i].Rect.Size.Width
                    , m_aryThumbInfo[i].Rect.Size.Height
                        );
                    m_aryThumbInfo[i].Rect = rtTmp;
                    if(m_delgMouseUp != null)
                    {
                        m_delgMouseUp();
                    }

                }
                else
                {
                    // The cursor is passing over the track.
                    m_aryThumbInfo[i].State = m_aryThumbInfo[i].Rect.Contains(e.Location) ? TrackBarThumbState.Hot : TrackBarThumbState.Normal;
                }
            }

            Invalidate();
        }
    }
}
