﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Managerform;
using PC_Project.Data;
using DevExpress.XtraGrid.Views.Grid;

namespace ManagerForm
{
    //add colors
    public partial class Managerform : DevExpress.XtraEditors.XtraForm
    {
        public Managerform()
        {
            InitializeComponent();
            timSeat.Start();
        }

        
        private void gridControl1_Load(object sender, EventArgs e)
        {
            bdsSeat.DataSource = DataRepository.Seat.GetWithCustomer();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Seat seat = bdsSeat.Current as Seat;

            if (seat.CustomerID == null)
            {
                if (MessageBox.Show("고장 상태를 해제하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    seat.Breakdown = false;
                    DataRepository.Seat.Update(seat);
                    return;
                }
                else
                {
                    return;
                }
            }
            AddTimeform addTimeform = new AddTimeform(seat.CustomerID);
            addTimeform.Show();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            Seat seat = bdsSeat.Current as Seat;

            if (seat == null)
                return;

            lblSeat.Text = seat.SeatID.ToString();
            if (seat.CustomerID != null)
            {
                Customer customer = DataRepository.Customer.Get(seat.CustomerID.Value);
                lblName.Text = customer.Name;
                lblId.Text = customer.LoginID.ToString();
                lblRemainingTime.Text = customer.RemainingTime.ToString();
                lblRank.Text = customer.Rank.ToString();
            }
            else
            {
                lblName.Text = "--";
                lblId.Text = "--";
                lblRemainingTime.Text = "--";
                lblRank.Text = "--";
            }
        }

        private void btnAddtime_Click(object sender, EventArgs e)
        {
            AddTimeform addtimeform = new AddTimeform();
            addtimeform.Show();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ManageCustomerform deletecustomerform = new ManageCustomerform();
            deletecustomerform.Show();
        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            Revenueform revenueform = new Revenueform();
            revenueform.Show();
        }

        private void btnChatting_Click(object sender, EventArgs e)
        {
            ManagerChattingform managerChattingform = new ManagerChattingform();
            managerChattingform.Show();
        }

        private void btnManageProducts_Click(object sender, EventArgs e)
        {
            ManageProductform manageProductform = new ManageProductform();
            manageProductform.Show();
        }

        private void btnManageGame_Click(object sender, EventArgs e)
        {
            ManageGameform manageGameform = new ManageGameform();
            manageGameform.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bdsSeat.DataSource = DataRepository.Seat.GetWithCustomer();
        }
    }
}