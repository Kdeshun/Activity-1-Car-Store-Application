using CarClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarShopGUI
{
    public partial class Form1 : Form
    {
        Store myStore = new Store();
        BindingSource carInvBind = new BindingSource();
        BindingSource carShopBind = new BindingSource();


        public Form1()
        {
            InitializeComponent();
        }

        public void ClearAddCar()
        {
            tbYear.Text = "";
            tbMake.Text = "";
            tbModel.Text = "";
            tbPrice.Text = "";
            cbCondition.SelectedIndex = -1;
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            Car c = new Car(int.Parse(tbYear.Text), tbMake.Text, tbModel.Text, decimal.Parse(tbPrice.Text), cbCondition.SelectedIndex);
            //MessageBox.Show(c.ToString());
            myStore.CarList.Add(c);
            carInvBind.ResetBindings(false);

            ClearAddCar();
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            //get selected item
            Car selected = (Car)listInventory.SelectedItem;



            //add to cart
            myStore.ShopList.Add(selected);


            // update listbox control
            carShopBind.ResetBindings(false);
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            decimal total = myStore.Checkout();
            lblTotal.Text = "$" + total.ToString();

            carShopBind.ResetBindings(false);
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            carInvBind.DataSource = myStore.CarList;

            listInventory.DataSource = carInvBind;
            listInventory.DisplayMember = ToString();

            carShopBind.DataSource = myStore.ShopList;

            listShoppingCart.DataSource = carShopBind;
            listShoppingCart.DisplayMember = ToString();
        }

        private void tbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}