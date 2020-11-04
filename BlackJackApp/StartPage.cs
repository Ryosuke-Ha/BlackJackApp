using System;
using System.Windows.Forms;

namespace BlackJackApp
{
    public partial class StartPage : Form
    {
        #region InitializeComponent
        public StartPage()
        {
            InitializeComponent();
        }
        #endregion

        #region 閉じるボタン押下
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region スタートボタン押下
        private void buttonGameStart_Click(object sender, EventArgs e)
        {
            PlayPage playPage = new PlayPage();
            playPage.Show();
            this.Visible = false;
        }
        #endregion
    }
}
