using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GameNim
{
    public partial class FormTroChoi : Form
    {
        private struct structPictureBox
        {
            public PictureBox[] pb;
        }

        structPictureBox[] mangPictureBox = new structPictureBox[5];
        Label[] mangSoDiem = new Label[5];
        private int soHop;
        int[] soDiemMoiHop = new int[5];
        Random random = new Random();
        private bool clickNutChoi = false, chonNutChoiTiep = false, chonNutVanMoi = false;
        private int tongSoDiemChon = 0;
        private int thuTuHop = 0, thuTuDiem = 0;
        private int[] mangSoDiemChon = new int[10];
        private int[,] viTri = new int[5, 11];
        private int pcLay = 0, viTriPcLay = 0;
        string[] duLieuVao = new string[] { "0", "0", "0", "0", "0", "0" };
        public FormTroChoi()
        {
            InitializeComponent();
            nutChoi.Visible = false;
            nutVanMoi.Visible = false;
            nutChonXong.Visible = false;
            nutLuu.Visible = false;
            lbHop1.Visible = false;
            lbHop2.Visible = false;
            lbHop3.Visible = false;
            lbHop4.Visible = false;
            lbHop5.Visible = false;
            rbMucDo3.Checked = true;
            lbThongBao.Text = "";
        }

        private void nutKhoiTao_Click(object sender, EventArgs e)
        {
            if (rbMucDo3.Checked == true)
            {
                soHop = 3;
                lbHop1.Visible = true;
                lbHop2.Visible = true;
                lbHop3.Visible = true;
                lbHop4.Visible = false;
                lbHop5.Visible = false;
                nutChoi.Visible = true;
            }

            else if (rbMucDo4.Checked == true)
            {
                soHop = 4;
                lbHop1.Visible = true;
                lbHop2.Visible = true;
                lbHop3.Visible = true;
                lbHop4.Visible = true;
                lbHop5.Visible = false;
                nutChoi.Visible = true;
            }

            else if (rbMucDo5.Checked == true)
            {
                soHop = 5;
                lbHop1.Visible = true;
                lbHop2.Visible = true;
                lbHop3.Visible = true;
                lbHop4.Visible = true;
                lbHop5.Visible = true;
                nutChoi.Visible = true;
            }


            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (viTri[i, j] != 0)
                    {
                        mangSoDiem[i].Dispose();
                        mangPictureBox[i].pb[j].Dispose();
                    }
                }
                soDiemMoiHop[i] = 0;
            }
            
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    viTri[i, j] = 0;
                }
            }

            taoSoDiemMoiHop();
        }
        private void taoSoDiemMoiHop()
        {
            while(tongNim() == 0)
            {
                for (int i = 0; i < soHop; i++)
                {
                    soDiemMoiHop[i] = random.Next(3, 11);
                }
            }

            for (int i = 0; i < soHop; i++)
            {
                mangPictureBox[i].pb = new PictureBox[soDiemMoiHop[i]];
                mangSoDiem[i] = new Label();
                mangSoDiem[i].Text = soDiemMoiHop[i].ToString();
                mangSoDiem[i].Width = 30;
                mangSoDiem[i].Height = 40;
                mangSoDiem[i].Top = 85 * i + 50;
                mangSoDiem[i].Left = 500;
                mangSoDiem[i].BackColor = Color.Transparent;
                mangSoDiem[i].Font = new Font("Cambria", 10.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                mangSoDiem[i].ForeColor = Color.Teal;
                this.Controls.Add(pnCacHopDiem);
                pnCacHopDiem.Controls.Add(mangSoDiem[i]);

                for (int j = 0; j < soDiemMoiHop[i]; j++)
                {
                    mangPictureBox[i].pb[j] = new PictureBox();
                    mangPictureBox[i].pb[j].Width = 15;
                    mangPictureBox[i].pb[j].Height = 70;
                    mangPictureBox[i].pb[j].Top = 80 * i + 35;
                    mangPictureBox[i].pb[j].Left = 30 * j + 70;
                    mangPictureBox[i].pb[j].Cursor = Cursors.Hand;
                    mangPictureBox[i].pb[j].BackColor = Color.Transparent;
                    mangPictureBox[i].pb[j].Image = GameNim.Properties.Resources.que_diem1;
                    mangPictureBox[i].pb[j].SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Controls.Add(pnCacHopDiem);
                    pnCacHopDiem.Controls.Add(mangPictureBox[i].pb[j]);
                    viTri[i, j] = 1;
                    mangPictureBox[i].pb[j].MouseClick += new MouseEventHandler(chonDiem);
                }
            }
        }

        private void nutChoi_Click(object sender, EventArgs e)
        {
            nutKhoiTao.Visible = false;
            nutChoi.Visible = false;
            nutVanMoi.Visible = true;
            nutChonXong.Visible = false;
            nutLuu.Visible = true;
            lbMucDo.Visible = false;
            rbMucDo3.Visible = false;
            rbMucDo4.Visible = false;
            rbMucDo5.Visible = false;
            clickNutChoi = true; //de phong choi khi chua click nut choi
        }

        private void chonDiem(object sender, MouseEventArgs e)
        {
            if(clickNutChoi == true) { 
                PictureBox pictureBox = (PictureBox)sender;
                int toaDoX = e.X + pictureBox.Left;
                int toaDoY = e.Y + pictureBox.Top;

                for(int i = 0; i < 5; i++)
                {
                    if (toaDoY >= (80 * i + 35) && toaDoY < (80 * (i + 1) + 35)) //Khi click sat le tren thi khong bi loi hinh anh bien mat nhung mangSoDiem ko tru
                    {
                        thuTuHop = i;
                        mangSoDiem[thuTuHop].Text = (Convert.ToInt32(mangSoDiem[thuTuHop].Text) - 1).ToString();
                    }
                }

                for (int i = 0; i < 10; i++)
                {
                    if(toaDoX >= (30 * i + 70) && toaDoX < (30 * (i + 1) + 70)) //Neu cho = het thi se tu 1 thanh 3
                    {
                        thuTuDiem = i;
                        mangSoDiemChon[tongSoDiemChon] = thuTuDiem;
                        viTri[thuTuHop, thuTuDiem] = 2;
                        tongSoDiemChon++;
                    }
                }

                lbThongBao.Text = "Bạn đã lấy " + tongSoDiemChon.ToString() + " que diêm ở hộp " + (thuTuHop + 1).ToString();

                for (int i = 0; i < thuTuHop; i++)
                {
                    for (int j = 0; j < 10; j++) 
                    {
                        if (viTri[i, j] == 1)
                        {
                            mangPictureBox[i].pb[j].Enabled = false;
                        }
                    }
                }

                for (int i = soHop - 1; i > thuTuHop; i--)
                {
                    for (int j = 0; j < 10; j++) 
                    {
                        if (viTri[i, j] == 1)
                        {
                            mangPictureBox[i].pb[j].Enabled = false;
                        }
                    }
                }

                if (e.Button == MouseButtons.Left)
                {
                    pictureBox.Hide();
                }

                nutChonXong.Visible = true;
            }
        }

        private void nutMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMoDau f = new FormMoDau();
            if (chonNutChoiTiep == true)
            {
                duLieuVao = new string[]{ soDiemMoiHop[0].ToString(), soDiemMoiHop[1].ToString(), soDiemMoiHop[2].ToString(),
                                      soDiemMoiHop[3].ToString(), soDiemMoiHop[4].ToString(), soHop.ToString() };
                File.WriteAllLines(@"data.txt", duLieuVao);
                chonNutChoiTiep = false;
            }
            f.ShowDialog();
            this.Close();
        }

        /*private void FormTroChoi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (chonNutChoiTiep == true)
            {
                duLieuVao = new string[]{ soDiemMoiHop[0].ToString(), soDiemMoiHop[1].ToString(), soDiemMoiHop[2].ToString(),
                                      soDiemMoiHop[3].ToString(), soDiemMoiHop[4].ToString(), soHop.ToString() };
                File.WriteAllLines(@"data.txt", duLieuVao);
                chonNutChoiTiep = false;
            }
            DialogResult result;
            result = MessageBox.Show("Ban muon thoat tro choi?", "Thong Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {

            }
        }*/

        private void nutVanMoi_Click(object sender, EventArgs e)
        {
            nutKhoiTao.Visible = true;
            nutChoi.Visible = false;
            nutVanMoi.Visible = false;
            nutChonXong.Visible = false;
            lbMucDo.Visible = true;
            rbMucDo3.Visible = true;
            rbMucDo4.Visible = true;
            rbMucDo5.Visible = true;
            clickNutChoi = false;
            //chonNutChoiTiep = false;
            lbThongBao.Text = "";
            if (chonNutChoiTiep == true)
            {
                chonNutVanMoi = true;
                duLieuVao = new string[]{ soDiemMoiHop[0].ToString(), soDiemMoiHop[1].ToString(), soDiemMoiHop[2].ToString(),
                                      soDiemMoiHop[3].ToString(), soDiemMoiHop[4].ToString(), soHop.ToString() };
                File.WriteAllLines(@"data.txt", duLieuVao);
            }
        }
        
        private void nutChonXong_Click(object sender, EventArgs e)
        {
            nutChonXong.Visible = false;
            if (mangSoDiem[thuTuHop].Text == "0")
            {
                mangSoDiem[thuTuHop].Dispose();
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (viTri[i, j] == 2)
                    {
                        viTri[i, j] = 0;
                    }
                }
            }

            //Xoa (nhung) que diem nguoi choi da lay
            for (int i = 0; i < tongSoDiemChon; i++)
            {
                soDiemMoiHop[thuTuHop]--;
                mangPictureBox[thuTuHop].pb[mangSoDiemChon[i]].Dispose();
            }
            tongSoDiemChon = 0;

            for (int i = 0; i < soHop; i++)
            {
                for (int j = 0; j < soDiemMoiHop[i]; j++)
                {
                    if (mangPictureBox[i].pb[j].Enabled == false)
                    {
                        mangPictureBox[i].pb[j].Enabled = true;
                    }
                }
            }

            int nguoiSoHopCoDiem = 0;
            for (int i = 0; i < 5; i++)
            {
                if (soDiemMoiHop[i] != 0)
                    nguoiSoHopCoDiem++;
            }

            if (nguoiSoHopCoDiem == 0)
            {
                MessageBox.Show("Bạn thắng rồi. Hay quá đi!", "Thông báo");
                nutChonXong.Visible = false;
                nutLuu.Visible = false;
                /*if (chonNutChoiTiep == true && chonNutVanMoi == false)
                {
                    duLieuVao = new string[] { "0", "0", "0", "0", "0", "0" };
                    File.WriteAllLines(@"data.txt", duLieuVao);
                }*/
            }

            else
            { 
                int flag = 0, t, pcthuLay = -1, k = 0, soDiem = soDiemMoiHop[k], bienTam, hopNhieuDiemNhat = 0;
                /*if (t != 0)
                {
                    while((soDiemMoiHop[k] ^ t) >= soDiemMoiHop[k])
                    {
                        k++;
                        soDiem = soDiemMoiHop[k];
                        viTriPcLay = k;
                    }
                    pcLay = soDiem - (soDiem ^ t);
                }

                 else
                 {
                    for (int i = 0; i < soHop; i++)
                    {
                        if (soDiemMoiHop[i] > hopNhieuDiemNhat)
                        {
                            hopNhieuDiemNhat = soDiemMoiHop[i];
                            viTriPcLay = i;
                        }
                    }
                    pcLay = random.Next(0, hopNhieuDiemNhat) + 1;
                 }*/
                    //int t = tongNim();
                    
                for(int i = 0; i < 5; i++)
                {
                    bienTam = soDiemMoiHop[i];
                    for (int j = 0; j < soDiemMoiHop[i]; j++)
                    {
                        pcthuLay = j + 1;
                        soDiemMoiHop[i] = soDiemMoiHop[i] - pcthuLay;
                        t = tongNim();
                        if(t == 0)
                        {
                            flag = 1;
                            pcLay = pcthuLay;
                            viTriPcLay = i;
                            soDiemMoiHop[i] = bienTam;
                            break;
                        }
                        soDiemMoiHop[i] = bienTam;
                    }
                    if(flag == 1)
                        break;
                }

                /*if(flag == 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (soDiemMoiHop[i] > hopNhieuDiemNhat)
                        {
                            hopNhieuDiemNhat = soDiemMoiHop[i];
                            viTriPcLay = i;
                        }
                    }
                    pcLay = random.Next(1, hopNhieuDiemNhat);
                }*/
                if(flag == 0)
                {
                    do
                    {
                        viTriPcLay = random.Next(0, 5);
                    }while (soDiemMoiHop[viTriPcLay] == 0);

                    pcLay = random.Next(1, 4);

                    if(pcLay > soDiemMoiHop[viTriPcLay])
                        pcLay = pcLay - (pcLay - soDiemMoiHop[viTriPcLay]);
                }
                

                for (int i = 0; i < pcLay; i++)
                {
                    for (int j = 10; j >= 0; j--)
                    {
                        if (viTri[viTriPcLay, j] == 1)
                        {
                            viTri[viTriPcLay, j] = 0;
                            mangPictureBox[viTriPcLay].pb[j].Dispose();
                            break;
                        }
                    }
                }

                soDiemMoiHop[viTriPcLay] = soDiemMoiHop[viTriPcLay] - pcLay;
                lbThongBao.Text = "Máy đã lấy " + pcLay.ToString() + " que diêm ở hộp " + (viTriPcLay + 1).ToString();
                
                mangSoDiem[viTriPcLay].Text = soDiemMoiHop[viTriPcLay].ToString();

                if (mangSoDiem[viTriPcLay].Text == "0")
                {
                    mangSoDiem[viTriPcLay].Dispose();
                }

                int pcSoHopCoDiem = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (soDiemMoiHop[i] != 0)
                        pcSoHopCoDiem++;
                }

                if(pcSoHopCoDiem == 0)
                {
                    MessageBox.Show("Máy thắng bạn rồi!", "Thông báo");
                    nutChonXong.Visible = false;
                    nutLuu.Visible = false;
                    /*if (chonNutChoiTiep == true && chonNutVanMoi == false)
                    {
                        duLieuVao = new string[] { "0", "0", "0", "0", "0", "0" };
                        File.WriteAllLines(@"data.txt", duLieuVao);
                    }*/
                }
            }
        }

        private void nutLuuTrangThai_Click(object sender, EventArgs e)
        { 
            duLieuVao = new string[]{ soDiemMoiHop[0].ToString(), soDiemMoiHop[1].ToString(), soDiemMoiHop[2].ToString(),
                                      soDiemMoiHop[3].ToString(), soDiemMoiHop[4].ToString(), soHop.ToString() };
            File.WriteAllLines(@"data.txt", duLieuVao);
            MessageBox.Show("Đã lưu ván hiện tại");
            this.Close();
        }

        public void choiTiep()
        {
            chonNutChoiTiep = true;
            string[] duLieuRa = File.ReadAllLines(@"data.txt");
            if (new FileInfo(@"data.txt").Length == 0  || (Convert.ToInt32(duLieuRa[0]) == 0 && Convert.ToInt32(duLieuRa[1]) == 0 && Convert.ToInt32(duLieuRa[2]) == 0 && Convert.ToInt32(duLieuRa[3]) == 0 && Convert.ToInt32(duLieuRa[4]) == 0))
            {
                MessageBox.Show("Bạn hiện không có ván chơi tiếp. Qua ván mới nhé!");
                chonNutChoiTiep = false;
            }
            else
            {
                FormMoDau f = new FormMoDau();
                f.Hide();
                soHop = Convert.ToInt32(duLieuRa[5]);
                for (int i = 0; i < soHop; i++)
                {
                    soDiemMoiHop[i] = Convert.ToInt32(duLieuRa[i]);
                }

                nutKhoiTao.Visible = false;
                nutChoi.Visible = false;
                //nutVanMoi.Visible = true;
                //nutBocXong.Location = new System.Drawing.Point(89, 90);
                lbMucDo.Visible = false;
                rbMucDo3.Visible = false;
                rbMucDo4.Visible = false;
                rbMucDo5.Visible = false;
                clickNutChoi = true;

                if (soHop == 3)
                {
                    lbHop1.Visible = true;
                    lbHop2.Visible = true;
                    lbHop3.Visible = true;
                    lbHop4.Visible = false;
                    lbHop5.Visible = false;
                }

                else if (soHop == 4)
                {
                    lbHop1.Visible = true;
                    lbHop2.Visible = true;
                    lbHop3.Visible = true;
                    lbHop4.Visible = true;
                    lbHop5.Visible = false;
                }

                else if (soHop == 5)
                {
                    lbHop1.Visible = true;
                    lbHop2.Visible = true;
                    lbHop3.Visible = true;
                    lbHop4.Visible = true;
                    lbHop5.Visible = true;
                }

                for (int i = 0; i < soHop; i++)
                {
                    mangPictureBox[i].pb = new PictureBox[soDiemMoiHop[i]];
                    mangSoDiem[i] = new Label();
                    mangSoDiem[i].Text = soDiemMoiHop[i].ToString();
                    mangSoDiem[i].Width = 30;
                    mangSoDiem[i].Height = 40;
                    mangSoDiem[i].Top = 85 * i + 50;
                    mangSoDiem[i].Left = 500;
                    mangSoDiem[i].BackColor = Color.Transparent;
                    mangSoDiem[i].Font = new Font("Cambria", 10.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    mangSoDiem[i].ForeColor = Color.Teal;
                    this.Controls.Add(pnCacHopDiem);
                    pnCacHopDiem.Controls.Add(mangSoDiem[i]);

                    for (int j = 0; j < soDiemMoiHop[i]; j++)
                    {
                        mangPictureBox[i].pb[j] = new PictureBox();
                        mangPictureBox[i].pb[j].Width = 15;
                        mangPictureBox[i].pb[j].Height = 70;
                        mangPictureBox[i].pb[j].Top = 80 * i + 35;
                        mangPictureBox[i].pb[j].Left = 30 * j + 70;
                        mangPictureBox[i].pb[j].Cursor = Cursors.Hand;
                        mangPictureBox[i].pb[j].BackColor = Color.Transparent;
                        mangPictureBox[i].pb[j].Image = GameNim.Properties.Resources.que_diem1;
                        mangPictureBox[i].pb[j].SizeMode = PictureBoxSizeMode.StretchImage;
                        this.Controls.Add(pnCacHopDiem);
                        pnCacHopDiem.Controls.Add(mangPictureBox[i].pb[j]);
                        viTri[i, j] = 1;
                        mangPictureBox[i].pb[j].MouseClick += new MouseEventHandler(chonDiem);
                    }
                }
                for (int i = 0; i < soHop; i++)
                {
                    if (mangSoDiem[i].Text == "0")
                    {
                        mangSoDiem[i].Dispose();
                    }
                }
            }
        }

        public int tongNim()
        {
            int t = 0;
            for (int i = 0; i < 5; i++)
            {
                t = t ^ soDiemMoiHop[i];
            }
            return t;
        }
    }
}

