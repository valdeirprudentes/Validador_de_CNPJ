using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValidadorCnpj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Validacao valid = new Validacao();
            mtbCnpj.TextMaskFormat = MaskFormat.IncludeLiterals;
            string cnpj = mtbCnpj.Text;
            bool verFal = valid.validarCnpj(cnpj);

            if(verFal)
            {
                MessageBox.Show("CNPJ VÁLIDO");
            }
            else
            {
                MessageBox.Show("CNPJ INVÁLIDO");
            }

        }
    }
}
