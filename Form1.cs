using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Account_Simulator
{
    public partial class Form1 : Form
    {
        //BankAccount field with a $1000 starting balance.
        //1000 is passed into constructor.
        private BankAccount account = new BankAccount(1000);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Display the starting balance
            balanceLabel.Text = account.Balance.ToString("c");
        }

        private void depositButton_Click(object sender, EventArgs e)
        {
            //To hold the amount of deposit.
            decimal amount;
            if(decimal.TryParse(depositTextBox.Text, out amount))
            {
                //Deposits the amount into the account.
                //Uses account object to call deposit method and 
                //passes amount as an argument.
                account.Deposit(amount);
                //Displays the new balance.
                balanceLabel.Text = account.Balance.ToString("c");
                //Clear the text box for deposit amount.
                depositTextBox.Clear();
            }
            else
            {
                //Error message.
                MessageBox.Show("Please enter a valid number.");
            }
        }

        private void withdrawButton_Click(object sender, EventArgs e)
        {
            decimal amount;
            decimal workingBalance;
            //Logic to parse information from the withdrawTextBox.
            if (decimal.TryParse(withdrawTextBox.Text, out amount))
            {
                //Nested logic tests to make sure the user does not overdraw from the account.
                if (decimal.TryParse(balanceLabel.Text, out workingBalance))
                {
                    if (workingBalance >= 0)
                    {//Withdrawl from account.,
                        account.Withdraw(amount);
                        //Display the balance.
                        balanceLabel.Text = account.Balance.ToString("c");
                        //Clear the withdraw box.
                        withdrawTextBox.Clear();
                    }
                }
                else
                {
                    //Displays error message if user tries to overdraft.
                    MessageBox.Show("Overdrawn, you don't have the funds.");
                }
            }
            else
            {
                //Error message.
                MessageBox.Show("Please enter a valid number.");
            }

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //Closes the form.
            this.Close();
        }
    }
}
