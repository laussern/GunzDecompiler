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
using System.Threading;
using System.Diagnostics;

namespace GunzDecompilerC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string archivo;
            archivo = textBox1.Text.ToLower().Trim();
            Decompilar(archivo);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region COmpilar
        private static void Decompilar(string archivo)
        {
            if (!File.Exists(archivo))
            {
                MessageBox.Show("El archivo no existe","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            byte[] arr = File.ReadAllBytes(archivo).Skip(5).Take(1).ToArray();
            byte codigo = arr[0];

            crearMRS(codigo);

            Process cmd = new Process();
            cmd.StartInfo.FileName = "mrse.exe";
            cmd.StartInfo.Arguments = " d " + archivo;
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            cmd.Start();

            while (!cmd.HasExited)
                Thread.Sleep(1);

            MessageBox.Show("-- Decompilado! --","Anuncio:",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        #endregion
        #region encryptarMRS
        private static void crearMRS(byte codigo)
        {
            encryptarMRS(0x8a, 0xd0, 0xc0, 0xea, 3, 0xc0, 0xe0, 5, 10, 0xd0, 0x41, 0xf6, 210, 0x88, 0x54, 0x90, 0x90, 0x2c, codigo, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x41, 0x90, 0x90, 0x88, 0x44, 0x8a, 0xd0, 0xc0, 0xea, 5, 0xc0, 0xe0, 3, 10, 0xd0, 0x41, 0xf6, 210, 0x88, 0x54, 0x90, 0x90, 4, codigo, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x41, 0x90, 0x90, 0x88, 0x44);
        }
        private static void encryptarMRS(byte b1, byte b2, byte b3, byte b4, byte b5, byte b6, byte b7, byte b8, byte b9, byte b10, byte b11, byte b12, byte b13, byte b14, byte b15, byte c1, byte c2, byte c3, byte c4, byte c5, byte c6, byte c7, byte c8, byte c9, byte c10, byte c11, byte c12, byte c13, byte c14, byte c15, byte b21, byte b22, byte b23, byte b24, byte b25, byte b26, byte b27, byte b28, byte b29, byte b210, byte b211, byte b212, byte b213, byte b214, byte b215, byte c21, byte c22, byte c23, byte c24, byte c25, byte c26, byte c27, byte c28, byte c29, byte c210, byte c211, byte c212, byte c213, byte c214, byte c215)
        {
            byte[] mrs = Properties.Resources.mrs;
            byte[] zlib = Properties.Resources.zlib;
            for (int i = 0; i < mrs.Length; i++)
            {
                if (((((mrs[i] == b1) && (mrs[i + 1] == b2)) && ((mrs[i + 2] == b3) && (mrs[i + 3] == b4))) && (((mrs[i + 4] == b5) && (mrs[i + 5] == b6)) && ((mrs[i + 6] == b7) && (mrs[i + 7] == b8)))) && ((((mrs[i + 8] == b9) && (mrs[i + 9] == b10)) && ((mrs[i + 10] == b11) && (mrs[i + 11] == b12))) && (((mrs[i + 12] == b13) && (mrs[i + 13] == b14)) && (mrs[i + 14] == b15))))
                {
                    mrs[i] = c1;
                    mrs[i + 1] = c2;
                    mrs[i + 2] = c3;
                    mrs[i + 3] = c4;
                    mrs[i + 4] = c5;
                    mrs[i + 5] = c6;
                    mrs[i + 6] = c7;
                    mrs[i + 7] = c8;
                    mrs[i + 8] = c9;
                    mrs[i + 9] = c10;
                    mrs[i + 10] = c11;
                    mrs[i + 11] = c12;
                    mrs[i + 12] = c13;
                    mrs[i + 13] = c14;
                    mrs[i + 14] = c15;
                    i += 14;
                }
                if (((((mrs[i] == b21) && (mrs[i + 1] == b22)) && ((mrs[i + 2] == b23) && (mrs[i + 3] == b24))) && (((mrs[i + 4] == b25) && (mrs[i + 5] == b26)) && ((mrs[i + 6] == b27) && (mrs[i + 7] == b28)))) && ((((mrs[i + 8] == b29) && (mrs[i + 9] == b210)) && ((mrs[i + 10] == b211) && (mrs[i + 11] == b212))) && (((mrs[i + 12] == b213) && (mrs[i + 13] == b214)) && (mrs[i + 14] == b215))))
                {
                    mrs[i] = c21;
                    mrs[i + 1] = c22;
                    mrs[i + 2] = c23;
                    mrs[i + 3] = c24;
                    mrs[i + 4] = c25;
                    mrs[i + 5] = c26;
                    mrs[i + 6] = c27;
                    mrs[i + 7] = c28;
                    mrs[i + 8] = c29;
                    mrs[i + 9] = c210;
                    mrs[i + 10] = c211;
                    mrs[i + 11] = c212;
                    mrs[i + 12] = c213;
                    mrs[i + 13] = c214;
                    mrs[i + 14] = c215;
                    i += 14;
                }
            }
            File.WriteAllBytes("mrse.exe", mrs);
            File.WriteAllBytes("zlib.dll", zlib);
        }
        #endregion

        #region ASDF
        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Decompiler Original s00rk, Edición Prodigy. \nEscribe el nombre del archivo(ejemplo: system.mrs) y dar click Decompilar\nVisita mi blog: http://s00rk.blogspot.com","Ayuda");
            Process.Start("http://s00rk.blogspot.com");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.Delete(Environment.SystemDirectory + "\\mrse.exe");
            File.Delete(Environment.SystemDirectory + "\\zlib.dll");
        }
        #endregion
    }
}
