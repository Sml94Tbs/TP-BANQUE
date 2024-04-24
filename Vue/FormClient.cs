
using System;
using System.Windows.Forms;

namespace Banque_CorrigeV2_Bis
{
    public partial class FormClient : Form
    {

        private Client c;

        public FormClient(Client unClient)
        {
            InitializeComponent();

            this.c = unClient;
        }

        public FormClient()
        {
            InitializeComponent();


        }



        private void FormClient_Load(object sender, EventArgs e)
        {

            tbNum.Text = c.Num.ToString();
            tbNom.Text = c.Nom;
            tbPrenom.Text = c.Prenom;
            tbAdresse.Text = c.Adresse;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.Adresse = tbAdresse.Text;
            this.Close();
        }



    }
}
