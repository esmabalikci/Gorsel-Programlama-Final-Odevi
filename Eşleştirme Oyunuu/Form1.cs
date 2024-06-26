﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eşleştirme_Oyunuu
{
    public partial class Form1 : Form
    {
        List<string> icons = new List<string>()
        {
            "a","b",
            "a","b",
        };
        Random rdn = new Random();
        int randomindex;
        Timer t1 = new Timer();
        Timer t2 = new Timer();
        Timer gameTimer=new Timer();
        int elapsedTime = 0;

        Button first, second;
        public Form1()
        {
            InitializeComponent();
            InitializeGameTimer();
            t1.Tick += T_Tick;
            t1.Start();
            t1.Interval = 3000;
            show();
            t2.Tick += T2_Tick;
        }
        private void InitializeGameTimer()
        {
            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimer_Tick;
            

        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            elapsedTime++;
            
        }
        private void T2_Tick(object sender, EventArgs e)
        {
            t2.Stop();
            first.ForeColor = first.BackColor;
            second.ForeColor = second.BackColor;
            first = null;
            second = null;


        }
        private void T_Tick(object sender, EventArgs e)
        {
            t1.Stop();
            foreach (Button item in Controls)
            {
                item.ForeColor = item.BackColor;
            }
            gameTimer.Start();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Show();
        }
        private void show()
        {
            Button btn;
            foreach (Button item in Controls)
            {
                btn = item as Button;
                randomindex = rdn.Next(icons.Count);
                btn.Text = icons[randomindex];
                btn.ForeColor = Color.Black;
                icons.RemoveAt(randomindex);

            }
        }
        int sayac = 0;

        private void Buton(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (first == null)
            {
                first = btn; 
                first.ForeColor = Color.Black;
                return;

            }
            second = btn;
            second.ForeColor = Color.Black;
            if (first.Text == second.Text)
            {
                first.ForeColor = Color.Black;
                second.ForeColor = Color.Black;
                first = null;
                second = null;
                sayac++;
                if (sayac == 2)
                {
                    gameTimer.Stop();
                    MessageBox.Show($"Bütün ikonları eşleştirdiniz :) Süre:{elapsedTime} saniye", "Tebrikler");
                    Close();
                }

            }
            else
            {
                t2.Start();
                t2.Interval = 1000;
            }
          
        }
    }
}

    
