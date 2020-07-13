﻿using PC_Project.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerForm
{
    public partial class ManageGameform : Form
    {
        public ManageGameform()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txbPhoto.Text == null)
                return;

            DataRepository.Game.AddPhoto((int)cbbGame.SelectedValue, txbPhoto.Text);
            MessageBox.Show($"{cbbGame.SelectedValue}{txbPhoto.Text}");
        }

        private void ManageGameform_Load(object sender, EventArgs e)
        {
            bdsGame.DataSource = DataRepository.Game.GetAll();
        }
    }
}
