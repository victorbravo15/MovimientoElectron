using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace parabola
{
    public partial class Form1 : Form
    {
        private Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void draw_btn_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = false;
            if ((textBox1.Text == "0") || (textBox1.Text == "270") || (textBox1.Text == "360") || (textBox1.Text == "180"))
            {
                MessageBox.Show("Ángulo no valido");
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Ingresa el ángulo");
            }
            
            if (textBox2.Text == "")
            {
                MessageBox.Show("Ingresa la velocidad");
            }

            if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox1.Text != "0") && (textBox1.Text != "180") && (textBox1.Text != "360"))
            {
                
                int origo_y = drawingboard.Height / 2;
                int origo_x = drawingboard.Width / 2;
                int origo_x2 = drawingboard2.Width / 2;
                int origo_y2 = drawingboard2.Height / 2;
                double ang = (double.Parse(textBox1.Text)) * (Math.PI / 180);
                double vo = (double.Parse(textBox2.Text));
                double me = 9.11 * (Math.Pow(10, (-31)));
                double qe = 1.6 * (Math.Pow(10, (-19)));
                double camp = 3.5 * Math.Pow(10, 3);
                double ge = (qe * camp) / me;
                double x, y, y2, x2;
                double t = (vo * (Math.Sin(ang))) / ge;
                double xmax = vo * (Math.Cos(ang)) * 2 * t * 100;
                double ymax = (vo * (Math.Sin(ang)) * t - 0.5 * ge * (Math.Pow(t, 2))) * 100;
                double xy = vo * (Math.Cos(ang)) * t * 100;
                
                label4.Text = xmax.ToString();
                label12.Text = t.ToString();
                label6.Text = (t * 2).ToString();         
                label10.Text = ymax.ToString();
                label14.Text = xy.ToString();
                 //pen
                Bitmap pen1 = new Bitmap(1, 1);
                pen1.SetPixel(0, 0, Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
                System.Drawing.Graphics g2 = drawingboard2.CreateGraphics();
                for (double i = 0; i <= 100000; i += 1)
                {

                    x2 = ((vo * (Math.Cos(ang))) / 1000000) + i;
                    y2 = 0;
                    g2.DrawImage(pen1, origo_x2 + (int)x2, origo_y2 + (int)y2);
                    

                    if (y2 <= 0.01 - origo_y2) { break; }
                }
                Bitmap pen2 = new Bitmap(1, 1);
                pen2.SetPixel(0, 0, Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
                System.Drawing.Graphics g1 = drawingboard2.CreateGraphics();
                
                for (double i = 0; i <= 100000; i += 1)
                {

                    x2 = 0;
                    y2 = i + ((vo * (Math.Sin(ang))) / 1000000);
                    g1.DrawImage(pen2, origo_x2 - (int)x2, origo_y2 - (int)y2);

                    if (y2 <= 0.01-origo_y2 ) { break; }
                }
                Bitmap pen3 = new Bitmap(1, 1);
                pen3.SetPixel(0, 0, Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
                System.Drawing.Graphics g0 = drawingboard2.CreateGraphics();
                for (double i = 0; i <= 100000; i += 1)
                {

                    x2 = ((vo * (Math.Cos(ang))) / 1000000) + i;
                    y2 = i + ((vo * (Math.Sin(ang))) / 1000000);
                    g0.DrawImage(pen3, origo_x2 + (int)x2, origo_y2 - (int)y2);

                    if (y2 <= 0.01 - origo_y2) { break; }
                }
                if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox1.Text != "0") && (textBox1.Text != "180"))
                {

                    Bitmap pen = new Bitmap(1, 1);
                    pen.SetPixel(0, 0, Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
                    System.Drawing.Graphics g = drawingboard.CreateGraphics();
                    if (((double.Parse(textBox1.Text)) < 0 && ((double.Parse(textBox1.Text)) > -180))|| ((double.Parse(textBox1.Text)) > 180))
                    {
                        
                        for (double i = 0; i <= 100000; i += t / 500)
                        {

                            x = vo * (Math.Cos(ang)) * i * 5000;
                            y = 5000 * (vo * (Math.Sin(ang)) * i - 0.5 * ge * (Math.Pow(i, 2)));
                            g.DrawImage(pen, origo_x - (int)x, origo_y + (int)y);

                            if (y <= 0.01 - origo_y) { break; }

                        } if (((double.Parse(textBox1.Text)) > 180 && ((double.Parse(textBox1.Text)) < 270)) || ((double.Parse(textBox1.Text)) < -90 && ((double.Parse(textBox1.Text)) > -180)))
                        {

                            label4.Text = (xmax).ToString();
                            label12.Text = (-t).ToString();
                            label6.Text = (-t * 2).ToString();
                            label10.Text = ymax.ToString();
                            label14.Text = (xy).ToString();
                            panel1.Visible = false;
                            panel2.Visible = true;
                        }
                        if (((double.Parse(textBox1.Text)) > 270) || ((double.Parse(textBox1.Text)) < 0 && ((double.Parse(textBox1.Text)) > -90)))
                        {
                            label4.Text = (-xmax).ToString();
                            label12.Text = (-t).ToString();
                            label6.Text = (-t * 2).ToString();
                            label10.Text = ymax.ToString();
                            label14.Text = (-xy).ToString();
                            panel1.Visible = false;
                            panel2.Visible = true;
                        }
                       
                       
                    }

                    else
                    {
                        panel2.Visible = false;
                        panel1.Visible = true;
                        for (double i = 0; i <= 100000; i += t / 500)
                        {

                            x = vo * (Math.Cos(ang)) * i * 5000;
                            y = 5000 * (vo * (Math.Sin(ang)) * i - 0.5 * ge * (Math.Pow(i, 2)));
                            g.DrawImage(pen, origo_x + (int)x, origo_y - (int)y);

                            if (y <= 0.01 - origo_y) { break; }

                        }
                        if (((double.Parse(textBox1.Text)) < -180 && (((double.Parse(textBox1.Text)) > -270))))
                        {
                            label4.Text = (-xmax).ToString();
                            label12.Text = (t).ToString();
                            label6.Text = (t * 2).ToString();
                            label10.Text = ymax.ToString();
                            label14.Text = (-xy).ToString();
                        }
                        if (((double.Parse(textBox1.Text)) > 90))
                        {
                            label4.Text = (-xmax).ToString();
                            label12.Text = (t).ToString();
                            label6.Text = (t * 2).ToString();
                            label10.Text = ymax.ToString();
                            label14.Text = (-xy).ToString();
                        }
                    }
                }
               
                
            }
            
               
            }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
