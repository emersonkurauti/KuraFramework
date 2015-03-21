using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace KuraFrameWork.Componentes_Visuais
{
    public partial class ucImagens : UserControl
    {
        public ucImagens()
        {
            InitializeComponent();
        }

        public virtual void btnCarregar_Click(object sender, EventArgs e)
        {
            if (dlgImagem.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < dlgImagem.SafeFileNames.Length; i++)
                {
                    string strPath = Path.GetDirectoryName(dlgImagem.FileName) + "\\";
                    AddImagem(Image.FromFile(strPath + dlgImagem.SafeFileNames[i]));
                }
            }
        }

        public virtual void btnRemoverImagem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsvImagens.Items.Count; i++)
                if (lsvImagens.Items[i].Checked)
                    lsvImagens.Items[i--].Remove();
        }

        public virtual void btnLimparLista_Click(object sender, EventArgs e)
        {
            lsvImagens.Items.Clear();
        }

        public virtual void AddImagem(Image imagem, string strDesc = "")
        {
            imgListaImagens.Images.Add(imagem);
            if (strDesc == "")
                lsvImagens.Items.Add((imgListaImagens.Images.Count - 1).ToString(), imgListaImagens.Images.Count - 1);
            else
                lsvImagens.Items.Add(strDesc, imgListaImagens.Images.Count - 1);
        }

        public virtual byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public virtual Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static byte[] StrToByteArray(string str)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetBytes(str);
        }

        public static string ByteArrayToStr(byte[] barr)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetString(barr, 0, barr.Length);
        }
    }
}
