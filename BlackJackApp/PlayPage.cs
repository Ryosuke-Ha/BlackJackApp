using BlackJackApp.Models;
using BlackJackApp.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BlackJackApp
{
    public partial class PlayPage : Form
    {
        int playerSum = 0;
        int dealerSum = 0;
        List<Card> garbage = new List<Card>();
        List<Card> player = new List<Card>();
        List<Card> dealer = new List<Card>();

        //トランプ一覧
        List<Card> trampList = new List<Card>
        {
            //Spade
            new Card(){Value = 2, Name = "Spade 2", Image = Resources.s02},
            new Card(){Value = 3, Name = "Spade 3", Image = Resources.s03},
            new Card(){Value = 4, Name = "Spade 4", Image = Resources.s04},
            new Card(){Value = 5, Name = "Spade 5", Image = Resources.s05},
            new Card(){Value = 6, Name = "Spade 6", Image = Resources.s06},
            new Card(){Value = 7, Name = "Spade 7", Image = Resources.s07},
            new Card(){Value = 8, Name = "Spade 8", Image = Resources.s08},
            new Card(){Value = 9, Name = "Spade 9", Image = Resources.s09},
            new Card(){Value = 10, Name = "Spade 10", Image = Resources.s10},
            new Card(){Value = 10, Name = "Spade J", Image = Resources.s11},
            new Card(){Value = 10, Name = "Spade Q", Image = Resources.s12},
            new Card(){Value = 10, Name = "Spade K", Image = Resources.s13},
            new Card(){Value = 11, Name = "Spade A", Image = Resources.s01},

            //Heart
            new Card(){Value = 2, Name = "Heart 2", Image = Resources.h02},
            new Card(){Value = 3, Name = "Heart 3", Image = Resources.h03},
            new Card(){Value = 4, Name = "Heart 4", Image = Resources.h04},
            new Card(){Value = 5, Name = "Heart 5", Image = Resources.h05},
            new Card(){Value = 6, Name = "Heart 6", Image = Resources.h06},
            new Card(){Value = 7, Name = "Heart 7", Image = Resources.h07},
            new Card(){Value = 8, Name = "Heart 8", Image = Resources.h08},
            new Card(){Value = 9, Name = "Heart 9", Image = Resources.h09},
            new Card(){Value = 10, Name = "Heart 10", Image = Resources.h10},
            new Card(){Value = 10, Name = "Heart J", Image = Resources.h11},
            new Card(){Value = 10, Name = "Heart Q", Image = Resources.h12},
            new Card(){Value = 10, Name = "Heart K", Image = Resources.h13},
            new Card(){Value = 11, Name = "Heart A", Image = Resources.h01},

            //Clover
            new Card(){Value = 2, Name = "Clover 2", Image = Resources.c02},
            new Card(){Value = 3, Name = "Clover 3", Image = Resources.c03},
            new Card(){Value = 4, Name = "Clover 4", Image = Resources.c04},
            new Card(){Value = 5, Name = "Clover 5", Image = Resources.c05},
            new Card(){Value = 6, Name = "Clover 6", Image = Resources.c06},
            new Card(){Value = 7, Name = "Clover 7", Image = Resources.c07},
            new Card(){Value = 8, Name = "Clover 8", Image = Resources.c08},
            new Card(){Value = 9, Name = "Clover 9", Image = Resources.c09},
            new Card(){Value = 10, Name = "Clover 10", Image = Resources.c10},
            new Card(){Value = 10, Name = "Clover J", Image = Resources.c11},
            new Card(){Value = 10, Name = "Clover Q", Image = Resources.c12},
            new Card(){Value = 10, Name = "Clover K", Image = Resources.c13},
            new Card(){Value = 11, Name = "Clover A", Image = Resources.c01},

            //Diamond
            new Card(){Value = 2, Name = "Diamond 2", Image = Resources.d02},
            new Card(){Value = 3, Name = "Diamond 3", Image = Resources.d03},
            new Card(){Value = 4, Name = "Diamond 4", Image = Resources.d04},
            new Card(){Value = 5, Name = "Diamond 5", Image = Resources.d05},
            new Card(){Value = 6, Name = "Diamond 6", Image = Resources.d06},
            new Card(){Value = 7, Name = "Diamond 7", Image = Resources.d07},
            new Card(){Value = 8, Name = "Diamond 8", Image = Resources.d08},
            new Card(){Value = 9, Name = "Diamond 9", Image = Resources.d09},
            new Card(){Value = 10, Name = "Diamond 10", Image = Resources.d10},
            new Card(){Value = 10, Name = "Diamond J", Image = Resources.d11},
            new Card(){Value = 10, Name = "Diamond Q", Image = Resources.d12},
            new Card(){Value = 10, Name = "Diamond K", Image = Resources.d13},
            new Card(){Value = 11, Name = "Diamond A", Image = Resources.d01},
        };

        #region InitializeComponent
        public PlayPage()
        {
            InitializeComponent();
        }
        #endregion

        #region 初回読み込み
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayPage_Load(object sender, EventArgs e)
        {
            //リセット
            ResetGame();
        }
        #endregion

        #region リセットボタン押下
        private void buttonReset_Click(object sender, EventArgs e)
        {
            //リセット
            ResetGame();
        }
        #endregion

        #region スタートボタン押下
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (playerSum > 0)
            {
                labelResult.Text = "プレイ中。。。";
            }
            else
            {
                labelResult.Text = "プレイ中。。。";
                playerSum = 0;
                dealerSum = 0;

                //プレイヤー1枚目
                Card playerCard = GetCard();
                garbage.Add(playerCard);
                player.Add(playerCard);
                picturePlayer1.Image = playerCard.Image;

                //プレイヤー2枚目
                Card playerCard2 = GetCard();
                garbage.Add(playerCard2);                
                player.Add(playerCard2);                
                picturePlayer2.Image = playerCard2.Image;

                //ディーラー1枚目
                Card dealerCard = GetCard();
                garbage.Add(dealerCard);
                dealer.Add(dealerCard);
                pictureDealer1.Image = dealerCard.Image;

                //ディーラー2枚目
                Card dealerCard2 = GetCard();
                garbage.Add(dealerCard2);
                dealer.Add(dealerCard2);               

                //得点の集計
                SumPlayerCards();
                SumDealerCards();

                //得点の表示
                labelPlayerResult.Text = playerSum.ToString();
                labelDealerResult.Text = "?";

                //21がそろった場合
                if (playerSum == GameConst.NUMBER_TWENTY_ONE)
                {
                    labelResult.Text = "プレイヤーの勝ち";
                    MessageBox.Show("あなたの勝ちです！！");
                    ResetGame();
                    return;
                }
            }

            buttonStart.Visible = false;
            buttonReset.Visible = true;
            buttonDeal.Visible = true;
            buttonBattle.Visible = true;
        }
        #endregion

        #region カードを引くボタン押下
        private void buttonDeal_Click(object sender, EventArgs e)
        {
            if (playerSum == 0)
            {
                labelResult.Text = "スタートボタンを押してください。";
            }
            else
            {
                //プレイヤードロー
                Card playerCard = GetCard();
                garbage.Add(playerCard);
                player.Add(playerCard);

                //プレイヤーカードの表示
                SetDealedCard(playerCard);

                //ディーラードロー
                if (IsDealCard())
                {
                    Card dealerCard = GetCard();
                    garbage.Add(dealerCard);
                    dealer.Add(dealerCard);
                }

                //得点の集計
                SumPlayerCards();
                SumDealerCards();

                //得点の表示
                labelPlayerResult.Text = playerSum.ToString();
                labelDealerResult.Text = "?";

                //手札が5枚以上の場合
                if(player.Count >= GameConst.NUMBER_Five)
                {
                    buttonDeal.Visible = false;
                    labelResult.Text = "勝負！またはリセットボタンを押してください。";
                }
                
            }
        }
        #endregion

        #region 勝負！！ボタン押下
        private void buttonBattle_Click(object sender, EventArgs e)
        {
            //得点の集計
            SumPlayerCards();
            SumDealerCards();

            //ディーラーの手札取得
            GetDealerCards();

            //結果の表示
            if (playerSum > dealerSum)
            {
                labelResult.Text = "勝ち";
            }
            else if(playerSum < dealerSum)
            {
                labelResult.Text = "負け";
            }
            else
            {
                labelResult.Text = "引き分け";
            }

            //ボタンの調整
            buttonDeal.Visible = false;
            buttonStart.Visible = false;
            buttonBattle.Visible = false;
        }
        #endregion

        #region 閉じるボタン押下
        private void Button_Close_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("アプリケーションを終了しますか？", "", MessageBoxButtons.OKCancel);
            if (dialog == DialogResult.OK)
            {
                Application.Exit();
            }
        }
        #endregion

        #region ディーラーの手札取得
        private void GetDealerCards()
        {
            //ディーラー得点の表示
            labelDealerResult.Text = dealerSum.ToString();

            //ディーラーの手札リスト
            List<PictureBox> dealerPictures = new List<PictureBox>
            {
                pictureDealer1,
                pictureDealer2,
                pictureDealer3,
                pictureDealer4,
                pictureDealer5
            };

            //トランプ画像の挿入
            for(int i = 0; dealer.Count >i; i++)
            {
                dealerPictures[i].Image = dealer[i].Image;
            }
        }
        #endregion

        #region 手数チェック
        private bool IsDealCard()
        {   
            //ディーラーがドローするかの判断
            if(dealerSum >= 19)
            {
                return false;
            }
            else if(17 < dealerSum && dealerSum <= 18)
            {
                return GetRandom50PersentBool();
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region 引いたカードの表示
        /// <param name="card">引いたカード</param>
        private void SetDealedCard(Card card)
        {
            //フィールドへのカード表示
            if (player.Count == GameConst.NUMBER_THREE)
            {
                picturePlayer3.Image = card.Image;
            }
            else if (player.Count == GameConst.NUMBER_FOUR)
            {
                picturePlayer4.Image = card.Image;
            }
            else if (player.Count == GameConst.NUMBER_Five)
            {
                picturePlayer5.Image = card.Image;
            }
            else if (player.Count >= GameConst.NUMBER_Five)
            {
                MessageBox.Show("用意していないです。。。すいません");
            }
        }
        #endregion

        #region 1/2のランダム取得
        private bool GetRandom50PersentBool()
        {
            //1/2の確率でドローするか否か
            Random random = new Random();
            if(random.Next(0,1) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region トランプのランダム取得
        /// <returns>Index</returns>
        private int GetRandomCard()
        {
            Random random = new Random();
            return random.Next(0, trampList.Count);
        }
        #endregion

        #region ゲームリセット
        private void ResetGame()
        {
            labelResult.Text = null;

            //トランプ画像の初期化
            DisplayPictureOfCardBack(pictureDealer1);
            DisplayPictureOfCardBack(pictureDealer2);
            DisplayPictureOfCardBack(pictureDealer3);
            DisplayPictureOfCardBack(pictureDealer4);
            DisplayPictureOfCardBack(pictureDealer5);

            DisplayPictureOfCardBack(picturePlayer1);
            DisplayPictureOfCardBack(picturePlayer2);
            DisplayPictureOfCardBack(picturePlayer3);
            DisplayPictureOfCardBack(picturePlayer4);
            DisplayPictureOfCardBack(picturePlayer5);

            //初期化
            playerSum = 0;
            dealerSum = 0;
            player.Clear();
            dealer.Clear();
            garbage.Clear();
            labelResult.Text = "スタートボタンを押してください。";

            //ボタンの調整
            buttonStart.Visible = true;
            buttonReset.Visible = false;
            buttonDeal.Visible = false;
            buttonBattle.Visible = false;

            //得点の表示
            labelPlayerResult.Text = playerSum.ToString();
            labelDealerResult.Text = dealerSum.ToString();
        }
        #endregion

        #region カード裏面への変更
        /// <param name="pictureBox">カード画像</param>
        private void DisplayPictureOfCardBack(PictureBox pictureBox)
        {
            pictureBox.Image = Resources.bk0;
        }
        #endregion

        #region ドローカードの取得
        /// <returns>ドローカード</returns>
        private Card GetCard()
        {
            //ランダムで取得
            int randomCard = GetRandomCard();
            Card card = trampList[randomCard];
            while (garbage.Contains(card))
            {
                randomCard = GetRandomCard();
                card = trampList[randomCard];
            }
            return card;
        }
        #endregion

        #region プレイヤーカード合計
        private void SumPlayerCards()
        {
            playerSum = 0;
            for(int i = 0; i < player.Count; i++)
            {
                playerSum += player[i].Value;
            }

            //21以上の場合
            while(playerSum > 21)
            {
                playerSum -= GameConst.NUMBER_TWENTY_ONE;                
            }
        }
        #endregion

        #region ディーラーカード合計
        private void SumDealerCards()
        {
            dealerSum = 0;
            for (int i = 0; i < dealer.Count; i++)
            {
                dealerSum += dealer[i].Value;
            }

            //21以上の場合
            while (dealerSum > 21)
            {
                dealerSum -= GameConst.NUMBER_TWENTY_ONE;                
            }
        }

        #endregion
               
    }
}
