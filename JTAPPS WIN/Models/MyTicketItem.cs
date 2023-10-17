using JTAPPS_WIN.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTAPPS_WIN.Models
{
    public class MyTicketItem
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyTicketMain));
        RoundedPanel roundedPanel = new();
        Panel panelGarisTiket = new();
        Label labelHargaTiket = new();
        Label labelX = new();
        Label labelKuantitas = new();
        Button buttonLihatWisata = new();
        PictureBox pbMasaBerlakuTiket = new();
        Label labelAlamatWisata = new();
        Label labelRp = new();
        PictureBox pbLocation = new();
        Label lbNamaWisata = new();
        Label labelETiket = new();
        RoundedPicbox roundedPicboxWisata = new();
        Label labelMasaBerlakuTiket = new();
        PictureBox pbRating1 = new();
        PictureBox pbRating2 = new();
        PictureBox pbRating3 = new();
        PictureBox pbRating4 = new();
        PictureBox pbRating5 = new();
        MyTiket MyTiket;



        public MyTicketItem(MyTiket myTiket)
        {
            MyTiket = myTiket;

            roundedPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            roundedPanel.CornerRadius = 30;
            roundedPanel.Margin = new Padding(3, 4, 3, 4);
            roundedPanel.Name = "roundedPanel";
            roundedPanel.Size = new Size(846, 165);
            roundedPanel.TabIndex = 0;
            roundedPanel.Anchor = AnchorStyles.None;
            roundedPanel.BackColor = Color.FromArgb(209, 232, 232);
            roundedPanel.Controls.Add(panelGarisTiket);
            roundedPanel.Controls.Add(labelRp);
            roundedPanel.Controls.Add(labelHargaTiket);
            roundedPanel.Controls.Add(labelKuantitas);
            roundedPanel.Controls.Add(labelX);
            roundedPanel.Controls.Add(buttonLihatWisata);
            roundedPanel.Controls.Add(pbMasaBerlakuTiket);
            roundedPanel.Controls.Add(labelAlamatWisata);
            roundedPanel.Controls.Add(pbLocation);
            roundedPanel.Controls.Add(lbNamaWisata);
            roundedPanel.Controls.Add(labelETiket);
            roundedPanel.Controls.Add(roundedPicboxWisata);
            roundedPanel.Controls.Add(labelMasaBerlakuTiket);
            roundedPanel.Controls.Add(pbRating1);
            roundedPanel.Controls.Add(pbRating2);
            roundedPanel.Controls.Add(pbRating3);
            roundedPanel.Controls.Add(pbRating4);
            roundedPanel.Controls.Add(pbRating5);

            lbNamaWisata.AutoSize = true;
            lbNamaWisata.Font = new Font("Poppins SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbNamaWisata.Location = new Point(118, 36);
            lbNamaWisata.Name = "lbNamaWisata";
            lbNamaWisata.Size = new Size(143, 35);

            labelAlamatWisata.AutoSize = true;
            labelAlamatWisata.Font = new Font("Poppins", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labelAlamatWisata.Location = new Point(142, 91);
            labelAlamatWisata.Name = "labelAlamatWisata";

            panelGarisTiket.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelGarisTiket.BackgroundImage = (Image)resources.GetObject("panelGarisTiket.BackgroundImage");
            panelGarisTiket.BackgroundImageLayout = ImageLayout.Stretch;
            panelGarisTiket.Location = new Point(16, 121);
            panelGarisTiket.Margin = new Padding(3, 4, 3, 4);
            panelGarisTiket.Size = new Size(815, 4);
            panelGarisTiket.Name = "panelGarisTiket";

            buttonLihatWisata.Text = "Lihat";
            buttonLihatWisata.Click += ButtonLihatWisata_Click;
            buttonLihatWisata.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonLihatWisata.BackColor = Color.Transparent;
            buttonLihatWisata.FlatAppearance.BorderSize = 0;
            buttonLihatWisata.FlatStyle = FlatStyle.Flat;
            buttonLihatWisata.Font = new Font("Poppins Medium", 6.75F, FontStyle.Bold, GraphicsUnit.Point);
            buttonLihatWisata.ForeColor = Color.FromArgb(34, 87, 121);
            buttonLihatWisata.Location = new Point(716, 128);
            buttonLihatWisata.Margin = new Padding(3, 4, 3, 4);
            buttonLihatWisata.Name = "buttonLihatWisata";
            buttonLihatWisata.Size = new Size(89, 31);

            labelHargaTiket.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelHargaTiket.AutoSize = true;
            labelHargaTiket.Font = new Font("Poppins Medium", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelHargaTiket.Location = new Point(709, 60);
            labelHargaTiket.Name = "labelHargaTiket";

            labelKuantitas.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelKuantitas.AutoSize = true;
            labelKuantitas.Font = new Font("Poppins Medium", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelKuantitas.Location = new Point(648, 60);
            labelKuantitas.Name = "labelKuantitas";

            pbMasaBerlakuTiket.BackgroundImage = (Image)resources.GetObject("pbMasaBerlakuTiket.BackgroundImage");
            pbMasaBerlakuTiket.BackgroundImageLayout = ImageLayout.Stretch;
            pbMasaBerlakuTiket.Location = new Point(31, 133);
            pbMasaBerlakuTiket.Margin = new Padding(3, 4, 3, 4);
            pbMasaBerlakuTiket.Name = "pbMasaBerlakuTiket";
            pbMasaBerlakuTiket.Size = new Size(14, 16);

            pbLocation.Image = (Image)resources.GetObject("pbLocation.Image");
            pbLocation.Location = new Point(125, 93);
            pbLocation.Margin = new Padding(3, 4, 3, 4);
            pbLocation.Name = "pbLocation";
            pbLocation.Size = new Size(16, 20);

            pbRating1.Image = Properties.Resources.lop2Group_8;
            pbRating1.Location = new Point(122, 70);
            pbRating1.Margin = new Padding(3, 4, 3, 4);
            pbRating1.Name = "pbRating1";
            pbRating1.Size = new Size(18, 19);
            pbRating1.SizeMode = PictureBoxSizeMode.StretchImage;

            pbRating2.Image = Properties.Resources.lop2Group_8;
            pbRating2.Location = new Point(142, 70);
            pbRating2.Margin = new Padding(3, 4, 3, 4);
            pbRating2.Name = "pbRating2";
            pbRating2.Size = new Size(18, 19);
            pbRating2.SizeMode = PictureBoxSizeMode.StretchImage;

            pbRating3.Image = Properties.Resources.lop2Group_8;
            pbRating3.Location = new Point(161, 70);
            pbRating3.Margin = new Padding(3, 4, 3, 4);
            pbRating3.Name = "pbRating3";
            pbRating3.Size = new Size(18, 19);
            pbRating3.SizeMode = PictureBoxSizeMode.StretchImage;


            pbRating4.Image = Properties.Resources.lop2Group_8;
            pbRating4.Location = new Point(180, 70);
            pbRating4.Margin = new Padding(3, 4, 3, 4);
            pbRating4.Name = "pbRating4";
            pbRating4.Size = new Size(18, 19);
            pbRating4.SizeMode = PictureBoxSizeMode.StretchImage;


            pbRating5.Image = Properties.Resources.lop2Group_8;
            pbRating5.Location = new Point(199, 70);
            pbRating5.Margin = new Padding(3, 4, 3, 4);
            pbRating5.Name = "pbRating5";
            pbRating5.Size = new Size(18, 19);
            pbRating5.SizeMode = PictureBoxSizeMode.StretchImage;

            labelETiket.AutoSize = true;
            labelETiket.Font = new Font("Poppins Medium", 7F, FontStyle.Bold, GraphicsUnit.Point);
            labelETiket.ForeColor = Color.FromArgb(159, 159, 159);
            labelETiket.Location = new Point(121, 21);
            labelETiket.Name = "labelETiket";
            labelETiket.Size = new Size(74, 22);
            labelETiket.Text = "E - Tiket";

            roundedPicboxWisata.CornerRadius = 10;
            roundedPicboxWisata.Image = (Image)resources.GetObject("roundedPicboxWisata.Image");
            roundedPicboxWisata.Location = new Point(23, 16);
            roundedPicboxWisata.Margin = new Padding(3, 4, 3, 4);
            roundedPicboxWisata.Name = "roundedPicboxWisata";
            roundedPicboxWisata.Size = new Size(91, 96);

            roundedPicboxWisata.CornerRadius = 10;
            roundedPicboxWisata.Image = (Image)resources.GetObject("roundedPicboxWisata.Image");
            roundedPicboxWisata.Location = new Point(23, 16);
            roundedPicboxWisata.Margin = new Padding(3, 4, 3, 4);
            roundedPicboxWisata.Name = "roundedPicboxWisata";
            roundedPicboxWisata.Size = new Size(91, 96);

            labelMasaBerlakuTiket.AutoSize = true;
            labelMasaBerlakuTiket.Font = new Font("Poppins Medium", 7F, FontStyle.Bold, GraphicsUnit.Point);
            labelMasaBerlakuTiket.Location = new Point(45, 132);
            labelMasaBerlakuTiket.Name = "labelMasaBerlakuTiket";
            labelMasaBerlakuTiket.Size = new Size(118, 22);
            labelMasaBerlakuTiket.Text = "Berlaku 24 Jam";

            labelRp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelRp.AutoSize = true;
            labelRp.Font = new Font("Poppins Medium", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelRp.Location = new Point(720, 58);
            labelRp.Name = "labelRp";
            labelRp.Size = new Size(33, 26);
            labelRp.Text = "Rp";

            labelHargaTiket.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelHargaTiket.AutoSize = true;
            labelHargaTiket.Font = new Font("Poppins Medium", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelHargaTiket.Location = new Point(749, 60);
            labelHargaTiket.Name = "labelHargaTiket";
            labelHargaTiket.Size = new Size(93, 26);

            labelKuantitas.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelKuantitas.AutoSize = true;
            labelKuantitas.Font = new Font("Poppins Medium", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelKuantitas.Location = new Point(660, 60);
            labelKuantitas.Name = "labelKuantitas";
            labelKuantitas.Size = new Size(29, 26);

            labelX.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelX.AutoSize = true;
            labelX.Font = new Font("Poppins Medium", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelX.Location = new Point(683, 60);
            labelX.Name = "labelKuantitas";
            labelX.Size = new Size(29, 26);
            labelX.Text = "X";


            lbNamaWisata.Text = myTiket.NamaWisata;
            labelAlamatWisata.Text = myTiket.AlamatWisata;
            labelKuantitas.Text = myTiket.Kuantitas.ToString();
            labelHargaTiket.Text = myTiket.HargaTiket.ToString();
            roundedPicboxWisata.Image = myTiket.Image;
            pbRating1.Text = myTiket.Rating.ToString();
            pbRating2.Text = myTiket.Rating.ToString();
            pbRating3.Text = myTiket.Rating.ToString();
            pbRating4.Text = myTiket.Rating.ToString();
            pbRating5.Text = myTiket.Rating.ToString();


            float rating = myTiket.Rating;
            if (rating >= 0.5 && rating < 1)
            {
                pbRating1.Image = Resources.lopGroup_7;
                pbRating2.Image = Resources.lop0Group_9;
                pbRating3.Image = Resources.lop0Group_9;
                pbRating4.Image = Resources.lop0Group_9;
                pbRating5.Image = Resources.lop0Group_9;
            }
            if (rating >= 1 && rating < 1.5)
            {
                pbRating1.Image = Resources.lop2Group_8;
                pbRating2.Image = Resources.lop0Group_9;
                pbRating3.Image = Resources.lop0Group_9;
                pbRating4.Image = Resources.lop0Group_9;
                pbRating5.Image = Resources.lop0Group_9;
            }
            if (rating >= 1.5 && rating < 2)
            {
                pbRating1.Image = Resources.lop2Group_8;
                pbRating2.Image = Resources.lopGroup_7;
                pbRating3.Image = Resources.lop0Group_9;
                pbRating4.Image = Resources.lop0Group_9;
                pbRating5.Image = Resources.lop0Group_9;
            }
            if (rating >= 2 && rating < 2.5)
            {
                pbRating1.Image = Resources.lop2Group_8;
                pbRating2.Image = Resources.lop2Group_8;
                pbRating3.Image = Resources.lop0Group_9;
                pbRating4.Image = Resources.lop0Group_9;
                pbRating5.Image = Resources.lop0Group_9;
            }
            if (rating >= 2.5 && rating < 3)
            {
                pbRating1.Image = Resources.lop2Group_8;
                pbRating2.Image = Resources.lop2Group_8;
                pbRating3.Image = Resources.lopGroup_7;
                pbRating4.Image = Resources.lop0Group_9;
                pbRating5.Image = Resources.lop0Group_9;
            }
            if (rating >= 3 && rating < 3.5)
            {
                pbRating1.Image = Resources.lop2Group_8;
                pbRating2.Image = Resources.lop2Group_8;
                pbRating3.Image = Resources.lop2Group_8;
                pbRating4.Image = Resources.lop0Group_9;
                pbRating5.Image = Resources.lop0Group_9;
            }
            if (rating >= 3.5 && rating < 4)
            {
                pbRating1.Image = Resources.lop2Group_8;
                pbRating2.Image = Resources.lop2Group_8;
                pbRating3.Image = Resources.lop2Group_8;
                pbRating4.Image = Resources.lopGroup_7;
                pbRating5.Image = Resources.lop0Group_9;
            }
            if (rating >= 4 && rating < 4.5)
            {
                pbRating1.Image = Resources.lop2Group_8;
                pbRating2.Image = Resources.lop2Group_8;
                pbRating3.Image = Resources.lop2Group_8;
                pbRating4.Image = Resources.lopGroup_7;
                pbRating5.Image = Resources.lop0Group_9;
            }
            if (rating >= 4.5 && rating < 5)
            {
                pbRating1.Image = Resources.lop2Group_8;
                pbRating2.Image = Resources.lop2Group_8;
                pbRating3.Image = Resources.lop2Group_8;
                pbRating4.Image = Resources.lop2Group_8;
                pbRating5.Image = Resources.lopGroup_7;
            }
            if (rating == 5)
            {
                pbRating1.Image = Resources.lop2Group_8;
                pbRating2.Image = Resources.lop2Group_8;
                pbRating3.Image = Resources.lop2Group_8;
                pbRating4.Image = Resources.lop2Group_8;
                pbRating5.Image = Resources.lop2Group_8;
            }

        }


        private void ButtonLihatWisata_Click(object sender, EventArgs e)
        {

            using (MyTicketRembangan updateForm = new MyTicketRembangan())
            {
                MytiketContext mytiketContext = new MytiketContext();
                updateForm.SetMyticket(MyTiket);
                DialogResult dr = updateForm.ShowDialog();
            }
        }

        public RoundedPanel CreateItem()
        {
            return roundedPanel;
        }
    }
}
