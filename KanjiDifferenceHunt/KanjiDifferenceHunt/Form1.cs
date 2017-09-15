using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KanjiDifferenceHunt
{
    public partial class FormGame : Form
    {
        string correctText = "古";          // 正解の文字：1つだけ
        string mistakeText = "吉";          // 間違いの文字：24個並ぶ
        double nowTime;                     // 経過時間
        double score;

        public FormGame()
        {
            InitializeComponent();
        }

        // 画面下部の25個のボタンのいずれかをクリックしたとき（共通で呼ばれる）
        private void buttons_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == correctText)
            {
                timer1.Stop(); //時間の計測終了
                score = 100 - nowTime;
                    //double.Parse(textTimer.Text);
                MessageBox.Show("クリア！" +
                    "\r\nスコア:" + score);
            }
            else
            {
                nowTime = nowTime + 10; // ペナルティー
                MessageBox.Show("間違い…。10秒追加");
            }
        }

        // スタートボタンをクリックしたとき
        private void buttonStart_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();          // 乱数を生成するためのインスタンスを生成
            int randomResult = rnd.Next(25);    // 0～24の乱数を取得

            // splitContainerの下部のPanel2に乗っている
            // ButtonのTextをすべて間違いの文字にする
            for (int i = 0; i < splitContainer1.Panel2.Controls.Count; i++)
            {
                splitContainer1.Panel2.Controls[i].Text = mistakeText;
            }

            // ランダムで1つだけ正解の文字にする。
            splitContainer1.Panel2.Controls[randomResult].Text = correctText;

            // タイマースタート
            nowTime = 0; // タイマーの初期化            nowTime = 0; // タイマーの初期化
            timer1.Start();
        }

        // 0.02秒置きに呼ばれるタイマーのイベントハンドラ
        private void timer1_Tick(object sender, EventArgs e)
        {
            nowTime = nowTime + 0.02;
            textTimer.Text = nowTime.ToString("0.00");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textTimer_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            this.textTimer.ReadOnly = true;
        }
    }
}
