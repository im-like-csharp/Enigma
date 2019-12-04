using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Энигма
{
    public partial class Form1 : Form
    {

        string rotor1 = "EKMFLGDQVZNTOWYHXUSPAIBRCJ",
               rotor2 = "AJDKSIRUXBLHWTMCQGZNPYFVOE",
               rotor3 = "BDFHJLCPRTXVZNYEIWGAKMUSQO",
               Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
               alphabet = "abcdefghijklmnopqrstuvwxyz",
               reflector = "YRUHQSLDPXNGOKMIEBFZCWVJAT";
        int r1 = 0,
            r2 = 0,
            r3 = 0;
        int[] x = new int[26]; // координаты для подсвечивания кнопки по X
        int[] y = new int[26]; // координаты для подсвечивания кнопки по Y
        //
        SoundPlayer click = new SoundPlayer(@"click.wav");
        TextBox[] txt = new TextBox[26]; // labels для коммутаторов
        int[] pair = new int[26]; // массив для проверки дублирования уже использующихся коммутаторов
        
        
        public Form1()
        {
            InitializeComponent();
            Q.Parent = pictureBox1;
            W.Parent = pictureBox1;
            E.Parent = pictureBox1;
            R.Parent = pictureBox1;
            T.Parent = pictureBox1;
            Z.Parent = pictureBox1;
            U.Parent = pictureBox1;
            I.Parent = pictureBox1;
            O.Parent = pictureBox1;
            A.Parent = pictureBox1;
            S.Parent = pictureBox1;
            D.Parent = pictureBox1;
            F.Parent = pictureBox1;
            G.Parent = pictureBox1;
            H.Parent = pictureBox1;
            J.Parent = pictureBox1;
            K.Parent = pictureBox1;
            P.Parent = pictureBox1;
            Y.Parent = pictureBox1;
            X.Parent = pictureBox1;
            C.Parent = pictureBox1;
            V.Parent = pictureBox1;
            B.Parent = pictureBox1;
            N.Parent = pictureBox1;
            M.Parent = pictureBox1;
            L.Parent = pictureBox1;
            r1 = Alphabet.IndexOf(Rot1.Text);
            r2 = Alphabet.IndexOf(Rot2.Text);
            r3 = Alphabet.IndexOf(Rot3.Text);
            x[0] = A.Location.X; x[1] = B.Location.X;
            x[2] = C.Location.X; x[3] = D.Location.X;
            x[4] = E.Location.X; x[5] = F.Location.X;
            x[6] = G.Location.X; x[7] = H.Location.X;
            x[8] = I.Location.X; x[9] = J.Location.X;
            x[10] = K.Location.X; x[11] = L.Location.X;
            x[12] = M.Location.X; x[13] = N.Location.X;
            x[14] = O.Location.X; x[15] = P.Location.X;
            x[16] = Q.Location.X; x[17] = R.Location.X;
            x[18] = S.Location.X; x[19] = T.Location.X;
            x[20] = U.Location.X; x[21] = V.Location.X;
            x[22] = W.Location.X; x[23] = X.Location.X;
            x[24] = Y.Location.X; x[25] = Z.Location.X;

            y[0] = A.Location.Y; y[1] = B.Location.Y;
            y[2] = C.Location.Y; y[3] = D.Location.Y;
            y[4] = E.Location.Y; y[5] = F.Location.Y;
            y[6] = G.Location.Y; y[7] = H.Location.Y;
            y[8] = I.Location.Y; y[9] = J.Location.Y;
            y[10] = K.Location.Y; y[11] = L.Location.Y;
            y[12] = M.Location.Y; y[13] = N.Location.Y;
            y[14] = O.Location.Y; y[15] = P.Location.Y;
            y[16] = Q.Location.Y; y[17] = R.Location.Y;
            y[18] = S.Location.Y; y[19] = T.Location.Y;
            y[20] = U.Location.Y; y[21] = V.Location.Y;
            y[22] = W.Location.Y; y[23] = X.Location.Y;
            y[24] = Y.Location.Y; y[25] = Z.Location.Y;

            txt[0] = Atext; txt[1] = Btext;
            txt[2] = Ctext; txt[3] = Dtext;
            txt[4] = Etext; txt[5] = Ftext;
            txt[6] = Gtext; txt[7] = Htext;
            txt[8] = Itext; txt[9] = Jtext;
            txt[10] = Ktext; txt[11] = Ltext;
            txt[12] = Mtext; txt[13] = Ntext;
            txt[14] = Otext; txt[15] = Ptext;
            txt[16] = Qtext; txt[17] = Rtext;
            txt[18] = Stext; txt[19] = Ttext;
            txt[20] = Utext; txt[21] = Vtext;
            txt[22] = Wtext; txt[23] = Xtext;
            txt[24] = Ytext; txt[25] = Ztext;

            for (int i = 0; i < 26; i++) pair[i] = -1;
        }

        bool active = true;

        private void Check(TextBox temp) // функция коммутации и проверки дублирования коммутации одной буквы 
        {
            active = false;
            bool b = false;
            for (int i = 0; i < 26; i++)
            {
                if (temp.Text == Convert.ToString(Alphabet[i]) || temp.Text == Convert.ToString(alphabet[i]))
                {
                    temp.Text = Convert.ToString(Alphabet[i]);
                    if (pair[Alphabet.IndexOf(temp.Text)] == -1)
                    {
                        pair[Alphabet.IndexOf(temp.Name[0])] = i;
                        pair[i] = Alphabet.IndexOf(temp.Name[0]);
                        txt[i].Text = Convert.ToString(temp.Name[0]);
                        b = true;
                    }
                    else
                    {
                        MessageBox.Show("Буква '" + temp.Text + "' уже закоммутирована");
                        temp.Text = "";
                    }
                    break;
                }
            }
            if (temp.Text == "" && pair[Alphabet.IndexOf(temp.Name[0])] != -1)
            {
                txt[pair[Alphabet.IndexOf(temp.Name[0])]].Text = "";
                pair[pair[Alphabet.IndexOf(temp.Name[0])]] = -1;
                pair[Alphabet.IndexOf(temp.Name[0])] = -1;
            }
            else
            if ( b == false || temp.Text == Convert.ToString(temp.Name[0]) ) temp.Text = "";
            active = true;
        }

        // далее функции переключения роторов
        private void U1_Click(object sender, EventArgs e)
        {
            r1 = ((--r1) + 26) % 26;
            Rot1.Text = Convert.ToString(Alphabet[r1]);
            richTextBox1.Clear();
            richTextBox2.Clear();
        }

        private void D1_Click(object sender, EventArgs e)
        {
            r1 = ((++r1) + 26) % 26;
            Rot1.Text = Convert.ToString(Alphabet[r1]);
            richTextBox1.Clear();
            richTextBox2.Clear();
        }

        private void U2_Click(object sender, EventArgs e)
        {
            r2 = ((--r2) + 26) % 26;
            Rot2.Text = Convert.ToString(Alphabet[r2]);
            richTextBox1.Clear();
            richTextBox2.Clear();
        }

        private void D2_Click(object sender, EventArgs e)
        {
            r2 = ((++r2) + 26) % 26;
            Rot2.Text = Convert.ToString(Alphabet[r2]);
            richTextBox1.Clear();
            richTextBox2.Clear();
        }

        private void U3_Click(object sender, EventArgs e)
        {
            r3 = ((--r3) + 26) % 26;
            Rot3.Text = Convert.ToString(Alphabet[r3]);
            richTextBox1.Clear();
            richTextBox2.Clear();
        }

        private void D3_Click(object sender, EventArgs e)
        {
            r3 = ((++r3) + 26) % 26;
            Rot3.Text = Convert.ToString(Alphabet[r3]);
            richTextBox1.Clear();
            richTextBox2.Clear();
        }

        // Основная функция CircleDown: 
        // 1. Шифрование
        // 2. Подсвечивание зашифрованной кнопки на форме, при нажатии
        private void CircleDown(object c)
        {
            click.Play();
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            string key = (c as Control).Name;

            if (pair[Alphabet.IndexOf(key)] != -1)
            {
                key = Convert.ToString(Alphabet[pair[Alphabet.IndexOf(key)]]);
            }


            int keyint = (Alphabet.IndexOf(key) + r1) % 26;
            key = Convert.ToString(rotor1[keyint]);
            int r21 = r2 - r1;
            if (r21 < 0) r21 += 26;
            keyint = (Alphabet.IndexOf(key) + r21) % 26;
            key = Convert.ToString(rotor2[keyint]);
            int r32 = r3 - r2;
            if (r32 < 0) r32 += 26;
            keyint = (Alphabet.IndexOf(key) + r32) % 26;
            key = Convert.ToString(rotor3[keyint]);
            keyint = Alphabet.IndexOf(key) - r3;
            if (keyint < 0) keyint += 26; 
            key = Convert.ToString(reflector[keyint]);
            keyint = Alphabet.IndexOf(key);
            ///
            keyint = (keyint + r3) % 26;
            keyint = rotor3.IndexOf(Alphabet[keyint]);
            key = Convert.ToString(Alphabet[keyint]);
            keyint = keyint - (r3 - r2);
            if (keyint < 0) keyint += 26;
            else keyint %= 26;
            keyint = rotor2.IndexOf(Alphabet[keyint]);
            key = Convert.ToString(Alphabet[keyint]);
            keyint = keyint - (r2 - r1);
            if (keyint < 0) keyint += 26;
            else keyint %= 26;
            keyint = rotor1.IndexOf(Alphabet[keyint]);
            key = Convert.ToString(Alphabet[keyint]);
            keyint -= r1;
            if (keyint < 0) keyint += 26;

            if (pair[keyint] != -1) keyint = pair[keyint];

            g.DrawRectangle(new Pen(Color.White, 4), (x[keyint] - 2), (y[keyint] - 4) - 180, 45, 45);
            pictureBox1.Image = bmp;
            richTextBox2.Text += Alphabet[keyint];
            g.Dispose();

            r1++;
            if (r1 == 26)
            {
                r2++;
                if (r2 == 26)
                {
                    r3++;
                    r3 %= 26;
                    Rot3.Text = Convert.ToString(Alphabet[r3]);
                }
                r2 %= 26;
                Rot2.Text = Convert.ToString(Alphabet[r2]);
            }
            r1 %= 26;
            Rot1.Text = Convert.ToString(Alphabet[r1]);
        }

        private void Atext_TextChanged(object sender, EventArgs e)
        {
            if (active) Check(sender as TextBox);
        }

        private void Btext_TextChanged(object sender, EventArgs e)
        {
            if (active) Check(sender as TextBox);
        }

        private void Ctext_TextChanged(object sender, EventArgs e)
        {
            if (active) Check(sender as TextBox);
        }

        private void Dtext_TextChanged(object sender, EventArgs e)
        {
            if (active) Check(sender as TextBox);
        }

        private void Etext_TextChanged(object sender, EventArgs e)
        {
            if (active) Check(sender as TextBox);
        }

        private void Ftext_TextChanged(object sender, EventArgs e)
        {
            if (active) Check(sender as TextBox);
        }

        private void Gtext_TextChanged(object sender, EventArgs e)
        {
            if (active) Check(sender as TextBox);
        }

        private void Htext_TextChanged(object sender, EventArgs e)
        {
            if (active) Check(sender as TextBox);
        }

        private void Itext_TextChanged(object sender, EventArgs e)
        {
            if (active) Check(sender as TextBox);
        }

        private void Jtext_TextChanged(object sender, EventArgs e)
        {
            if (active) Check(sender as TextBox);
        }

        private void Ktext_TextChanged(object sender, EventArgs e)
        {
            if (active) Check(sender as TextBox);
        }

        private void Ltext_TextChanged(object sender, EventArgs e)
        {
            if (active) Check(sender as TextBox);
        }

        private void Mtext_TextChanged(object sender, EventArgs e)
        {
            if (active) Check(sender as TextBox);
        }

        private void Ntext_TextChanged(object sender, EventArgs e)
        {
            if (active) Check(sender as TextBox);
        }

        private void Otext_TextChanged(object sender, EventArgs e)
        {
            if (active) Check(sender as TextBox);
        }

        private void Ptext_TextChanged(object sender, EventArgs e)
        {
            if (active) Check(sender as TextBox);
        }

        private void Qtext_TextChanged(object sender, EventArgs e)
        {
            if (active) Check(sender as TextBox);
        }

        private void Rtext_TextChanged(object sender, EventArgs e)
        {
            if (active) Check(sender as TextBox);
        }

        private void Stext_TextChanged(object sender, EventArgs e)
        {
            if (active) Check(sender as TextBox);
        }

        private void Ttext_TextChanged(object sender, EventArgs e)
        {
            if (active) Check(sender as TextBox);
        }

        private void Utext_TextChanged(object sender, EventArgs e)
        {
            if (active) Check(sender as TextBox);
        }

        private void Vtext_TextChanged(object sender, EventArgs e)
        {
            if (active) Check(sender as TextBox);
        }

        private void Wtext_TextChanged(object sender, EventArgs e)
        {
            if (active) Check(sender as TextBox);
        }

        private void Xtext_TextChanged(object sender, EventArgs e)
        {
            if (active) Check(sender as TextBox);
        }

        private void Ytext_TextChanged(object sender, EventArgs e)
        {
            if (active) Check(sender as TextBox);
        }

        private void Ztext_TextChanged(object sender, EventArgs e)
        {
            if (active) Check(sender as TextBox);
        }

        private void CircleUp()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
        }

        private void Rot1_TextChanged(object sender, EventArgs e)
        {
            r1 = Alphabet.IndexOf(Rot1.Text);
        }

        private void Rot2_TextChanged(object sender, EventArgs e)
        {
            r2 = Alphabet.IndexOf(Rot2.Text);
        }

        private void Rot3_TextChanged(object sender, EventArgs e)
        {
            r3 = Alphabet.IndexOf(Rot3.Text);
        }

        private void delAll_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
        }

        private void back_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length != 0)
                richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.Text.Length - 1);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            richTextBox2.SelectionStart = richTextBox2.Text.Length;
        }

        private void Q_MouseDown(object sender, MouseEventArgs e)
        {
            CircleDown(sender as Control);
            richTextBox1.Text += (sender as Control).Name;
        }

        private void W_MouseDown(object sender, MouseEventArgs e)
        {
            CircleDown(sender as Control);
            richTextBox1.Text += (sender as Control).Name;
        }

        private void E_MouseDown(object sender, MouseEventArgs e)
        {
            CircleDown(sender as Control);
            richTextBox1.Text += E.Name;
        }

        private void R_MouseDown(object sender, MouseEventArgs e)
        {
            CircleDown(sender as Control);
            richTextBox1.Text += (sender as Control).Name;
        }

        private void T_MouseDown(object sender, MouseEventArgs e)
        {
            CircleDown(sender as Control);
            richTextBox1.Text += (sender as Control).Name;
        }

        private void Z_MouseDown(object sender, MouseEventArgs e)
        {
            CircleDown(sender as Control);
            richTextBox1.Text += (sender as Control).Name;
        }

        private void U_MouseDown(object sender, MouseEventArgs e)
        {
            CircleDown(sender as Control);
            richTextBox1.Text += (sender as Control).Name;
        }

        private void I_MouseDown(object sender, MouseEventArgs e)
        {
            CircleDown(sender as Control);
            richTextBox1.Text += (sender as Control).Name;
        }

        private void O_MouseDown(object sender, MouseEventArgs e)
        {
            CircleDown(sender as Control);
            richTextBox1.Text += (sender as Control).Name;
        }

        private void A_MouseDown(object sender, MouseEventArgs e)
        {
            CircleDown(sender as Control);
            richTextBox1.Text += (sender as Control).Name;
        }

        private void S_MouseDown(object sender, MouseEventArgs e)
        {
            CircleDown(sender as Control);
            richTextBox1.Text += (sender as Control).Name;
        }

        private void D_MouseDown(object sender, MouseEventArgs e)
        {
            CircleDown(sender as Control);
            richTextBox1.Text += (sender as Control).Name;
        }

        private void F_MouseDown(object sender, MouseEventArgs e)
        {
            CircleDown(sender as Control);
            richTextBox1.Text += (sender as Control).Name;
        }

        private void G_MouseDown(object sender, MouseEventArgs e)
        {
            CircleDown(sender as Control);
            richTextBox1.Text += (sender as Control).Name;
        }

        private void H_MouseDown(object sender, MouseEventArgs e)
        {
            CircleDown(sender as Control);
            richTextBox1.Text += (sender as Control).Name;
        }

        private void J_MouseDown(object sender, MouseEventArgs e)
        {
            CircleDown(sender as Control);
            richTextBox1.Text += (sender as Control).Name;
        }

        private void K_MouseDown(object sender, MouseEventArgs e)
        {
            CircleDown(sender as Control);
            richTextBox1.Text += (sender as Control).Name;
        }

        private void P_MouseDown(object sender, MouseEventArgs e)
        {
            CircleDown(sender as Control);
            richTextBox1.Text += (sender as Control).Name;
        }

        private void Y_MouseDown(object sender, MouseEventArgs e)
        {
            CircleDown(sender as Control);
            richTextBox1.Text += (sender as Control).Name;
        }

        private void X_MouseDown(object sender, MouseEventArgs e)
        {
            CircleDown(sender as Control);
            richTextBox1.Text += (sender as Control).Name;
        }

        private void C_MouseDown(object sender, MouseEventArgs e)
        {
            CircleDown(sender as Control);
            richTextBox1.Text += (sender as Control).Name;
        }

        private void V_MouseDown(object sender, MouseEventArgs e)
        {
            CircleDown(sender as Control);
            richTextBox1.Text += (sender as Control).Name;
        }

        private void B_MouseDown(object sender, MouseEventArgs e)
        {
            CircleDown(sender as Control);
            richTextBox1.Text += (sender as Control).Name;
        }

        private void N_MouseDown(object sender, MouseEventArgs e)
        {
            CircleDown(sender as Control);
            richTextBox1.Text += (sender as Control).Name;
        }

        private void M_MouseDown(object sender, MouseEventArgs e)
        {
            CircleDown(sender as Control);
            richTextBox1.Text += (sender as Control).Name;
        }

        private void L_MouseDown(object sender, MouseEventArgs e)
        {
            CircleDown(sender as Control);
            richTextBox1.Text += (sender as Control).Name;
        }

        private void Q_MouseUp(object sender, MouseEventArgs e)
        {
            CircleUp();
        }

        private void W_MouseUp(object sender, MouseEventArgs e)
        {
            CircleUp();
        }

        private void E_MouseUp(object sender, MouseEventArgs e)
        {
            CircleUp();
        }

        private void R_MouseUp(object sender, MouseEventArgs e)
        {
            CircleUp();
        }

        private void T_MouseUp(object sender, MouseEventArgs e)
        {
            CircleUp();
        }

        private void Z_MouseUp(object sender, MouseEventArgs e)
        {
            CircleUp();
        }

        private void U_MouseUp(object sender, MouseEventArgs e)
        {
            CircleUp();
        }

        private void I_MouseUp(object sender, MouseEventArgs e)
        {
            CircleUp();
        }

        private void O_MouseUp(object sender, MouseEventArgs e)
        {
            CircleUp();
        }

        private void A_MouseUp(object sender, MouseEventArgs e)
        {
            CircleUp();
        }

        private void S_MouseUp(object sender, MouseEventArgs e)
        {
            CircleUp();
        }

        private void D_MouseUp(object sender, MouseEventArgs e)
        {
            CircleUp();
        }

        private void F_MouseUp(object sender, MouseEventArgs e)
        {
            CircleUp();
        }

        private void G_MouseUp(object sender, MouseEventArgs e)
        {
            CircleUp();
        }

        private void H_MouseUp(object sender, MouseEventArgs e)
        {
            CircleUp();
        }

        private void J_MouseUp(object sender, MouseEventArgs e)
        {
            CircleUp();
        }

        private void K_MouseUp(object sender, MouseEventArgs e)
        {
            CircleUp();
        }

        private void P_MouseUp(object sender, MouseEventArgs e)
        {
            CircleUp();
        }

        private void Y_MouseUp(object sender, MouseEventArgs e)
        {
            CircleUp();
        }

        private void X_MouseUp(object sender, MouseEventArgs e)
        {
            CircleUp();
        }

        private void C_MouseUp(object sender, MouseEventArgs e)
        {
            CircleUp();
        }

        private void V_MouseUp(object sender, MouseEventArgs e)
        {
            CircleUp();
        }

        private void B_MouseUp(object sender, MouseEventArgs e)
        {
            CircleUp();
        }

        private void N_MouseUp(object sender, MouseEventArgs e)
        {
            CircleUp();
        }

        private void M_MouseUp(object sender, MouseEventArgs e)
        {
            CircleUp();
        }

        private void L_MouseUp(object sender, MouseEventArgs e)
        {
            CircleUp();
        }
    }
}
