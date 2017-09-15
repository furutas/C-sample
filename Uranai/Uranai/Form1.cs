using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uranai
{
    public partial class FormUranai : Form
    {
        public FormUranai()
        {
            InitializeComponent();
        }
        
        private void buttonUranaiStart_Click(object sender, EventArgs e)
        {
            int dateNumber; // 年間累積日を記憶する変数
            dateNumber = dateTimeUranai.Value.DayOfYear; //選んだ日付から、年間累積日を計算

            int selectBloodType = 0; //血液型

            switch (bloodType.Text)
            {
                case "A型":
                    selectBloodType = 0;
                    break;
                case "B型":
                    selectBloodType = 1;
                    break;
                case "O型":
                    selectBloodType = 2;
                    break;
                case "AB型":
                    selectBloodType = 3;
                    break;
            }

            switch ((dateNumber + selectBloodType ) % 5) // 年間累積日を5で割った余りは？
            {
                case 0: // 大吉
                    pictureBoxResult.Image = Uranai.Properties.Resources.Daikichi;
                    textResult.Text = "思ったことがコードにかけてものすごいアプリがつくれるかも！！";
                    break;
                case 1: // 中吉
                    pictureBoxResult.Image = Uranai.Properties.Resources.Cyuukichi;
                    textResult.Text = "書いたコードがビルドエラーも起きず一発で実行できるかも！";
                    break;
                case 2: // 小吉
                    pictureBoxResult.Image = Uranai.Properties.Resources.Syoukichi;
                    textResult.Text = "できた！と思ったらコード書き忘れて動かないところがあるかも";
                    break;
                case 3: // 吉
                    pictureBoxResult.Image = Uranai.Properties.Resources.Kichi;
                    textResult.Text = "なかなかエラーが修正できないかも";
                    break;
                case 4: // 凶
                    pictureBoxResult.Image = Uranai.Properties.Resources.Kyou;
                    textResult.Text = "せっかく書いたプログラムが消えるかも。"
                                    + "まさにしょぼーんなことがおこるかも";
                    break;
                default: // ここに到達することがあれば条件のミス
                    pictureBoxResult.Image = null;
                    break;
            }
        }

        private void dateTimeUranai_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FormUranai_Load(object sender, EventArgs e)
        {
            DateTimePicker dateTimePicker1 = new DateTimePicker();
            dateTimeUranai.Value = DateTime.Now;

            bloodType.Items.Add("A型");
            bloodType.Items.Add("B型");
            bloodType.Items.Add("O型");
            bloodType.Items.Add("AB型");

        }

        private void bloodType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
