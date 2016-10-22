using System;
using System.Windows.Forms;
//AOB SigMaker - https://github.com/I-M-I/AOBSigMaker

namespace AOBSigMaker
{
    public partial class AOBSigMaker : Form
    {
        public AOBSigMaker()
        {
            InitializeComponent();
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            string ArrayA = arrayA.Text;
            string ArrayB = arrayB.Text;
            int ArrayLength = ArrayA.Length;          
            
            //Clear text, mainly for preventing duplicates when clicked again
            txtResult.Clear();
            txtResultMask.Clear();
            txtMaskWhole.Clear();
            txtArray.Clear();
            txtCode.Clear();


            if (arrayA.Text.Length != arrayB.Text.Length)
            {
                txtStatus.Text = "Array Size Mismatch!";
                return;
            }


            //Make array with wildcards (Half-Byte)
            for (int i = 0; i < ArrayLength; i++)
            {

                if (ArrayA[i] != ArrayB[i])
                {
                    txtResult.Text = txtResult.Text + "?";
                }
                else
                {
                    txtResult.Text = txtResult.Text + ArrayA[i];
                }

            }

            //Make Mask
            
            string arrayAnospaces = arrayA.Text.Replace(" ", "");
            string arrayBnospaces = arrayB.Text.Replace(" ", "");
            int ArrayLengthMask = arrayAnospaces.Length;

            for (int i = 0; i < ArrayLengthMask; i++)
            {


                if (arrayAnospaces[i] != arrayBnospaces[i])
                {
                    txtResultMask.Text = txtResultMask.Text + "?";
                }
                else
                {
                    txtResultMask.Text = txtResultMask.Text + "x";
                }

            }



       //Make array with wildcards (Whole-Byte)
            string FirstHalf ="";
            string SecondHalf = "";


            //Compare the first character of each byte
            for (int i = 0; i < ArrayLengthMask; i += 2)
            {


                if (arrayAnospaces[i] != arrayBnospaces[i])
                {
                    FirstHalf = FirstHalf + "?";
                }
                else
                {
                    FirstHalf = FirstHalf + "x";
                }

            }

            //Compare the second character of each byte
            for (int i = 1; i < ArrayLengthMask; i += 2)
            {


                if (arrayAnospaces[i] != arrayBnospaces[i])
                {
                    SecondHalf = SecondHalf + "?";
                }
                else
                {
                    SecondHalf = SecondHalf + "x";
                }

            }

            string ArrayAS = FirstHalf;
            string ArrayBS = SecondHalf;

            //Merge the two halves 
            for (int i = 0; i < ArrayLengthMask / 2; i++)
            {

                if (ArrayAS[i] != ArrayBS[i])
                {
                    txtMaskWhole.Text = txtMaskWhole.Text + "?";
                }
                else
                {
                    txtMaskWhole.Text = txtMaskWhole.Text + ArrayAS[i];
                }

            }


            //Convert to Style 1
            string Style1 = arrayA.Text.Replace(" ", ", 0x");

            txtArray.Text = "0x" + Style1;

            //Convert to Style 2
            string Style2 = arrayA.Text.Replace(" ", @"\x"); ;

            txtCode.Text = @"\x" + Style2;

            txtStatus.Text = "OK!";
        }

        private void btnCopyArrayA_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(arrayA.Text);
                txtStatus.Text = "Copied to Clipboard";
            }
            catch
            {
                txtStatus.Text = "Nothing to Copy";
            }
        }

        private void btnCopyArrayB_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(arrayB.Text);
                txtStatus.Text = "Copied to Clipboard";
            }
            catch
            {
                txtStatus.Text = "Nothing to Copy";
            }
        }

        private void btnCopyResult_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(txtResult.Text);
                txtStatus.Text = "Copied to Clipboard";
            }
            catch
            {
                txtStatus.Text = "Nothing to Copy";
            }
        }

        private void btnCopyHalfMask_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(txtResultMask.Text);
                txtStatus.Text = "Copied to Clipboard";
            }
            catch
            {
                txtStatus.Text = "Nothing to Copy";
            }
        }

        private void btnCopyFullMask_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(txtMaskWhole.Text);
                txtStatus.Text = "Copied to Clipboard";
            }
            catch
            {
                txtStatus.Text = "Nothing to Copy";
            }
        }

        private void btnCopyStyle1_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(txtCode.Text);
                txtStatus.Text = "Copied to Clipboard";
            }
            catch
            {
                txtStatus.Text = "Nothing to Copy";
            }
        }

        private void btnCopyStyle2_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(txtArray.Text);
                txtStatus.Text = "Copied to Clipboard";
            }
            catch
            {
                txtStatus.Text = "Nothing to Copy";
            }
        }
    }
}
