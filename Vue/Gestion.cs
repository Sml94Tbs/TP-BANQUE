
using Banque_CorrigeV2_Bis.Exeptions;
using Banque_CorrigeV2_Bis.Modele;
using System;
using System.Collections.Generic;
using System.Windows.Forms;



namespace Banque_CorrigeV2_Bis
{


    public partial class Gestion : Form
    {





        public Gestion()
        {
            InitializeComponent();
        }

        private void crediterToolStripMenuItem_Click(object sender, EventArgs e)
        {

            lab.Visible = true;
            lab.Text = "Montant à créditer";

            bouton.Visible = true;
            bouton.Text = "Valider le crédit";

            tb.Visible = true;

        }



        private void debiterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lab.Visible = true;
            lab.Text = "Montant à débiter";

            bouton.Visible = true;
            bouton.Text = "Valider le débit";


            tb.Visible = true;
        }

        private void bouton_Click(object sender, EventArgs e)
        {




            Compte c = (Compte)lBox.SelectedItem;

          



            if (bouton.Text == "Valider le crédit")
            {

                // c.crediter(Convert.ToDouble(tb.Text));

                try
                {
                    Mgr.crediter(c, Convert.ToDouble(tb.Text));
                } catch(DebitExeption)
                {
                    throw new DebitExeption(tb.Text);
                }

            }


            // On ne débite que si le retour de la méthode est à true sinon on affiche un message

            if (bouton.Text == "Valider le débit")
            {
                /***if (!Mgr.debiter(c, Convert.ToDouble(tb.Text)))
                {
                    MessageBox.Show();              
                }***/


                try
                {
                    Mgr.debiter(c, Convert.ToDouble(tb.Text));

                }

                catch (DebitExeption ex)
                {

                    MessageBox.Show(ex.Message);    
                }
              

                tb.Clear();
            }




            if (bouton.Text == "Valider le découvert")
            {

               

                    if (c.GetType().Name == "CompteCourant")
                    {
                        if (!((CompteCourant)c).setDecouv(Convert.ToDouble(tb.Text))) { MessageBox.Show("attention changement de découvert interdit !"); }

                    }


             }

               

            rafraichirListBox();


        }

        private void découvertToolStripMenuItem_Click(object sender, EventArgs e)
        {


            lab.Visible = true;
            lab.Text = "Montant du nouveau découvert";

            bouton.Visible = true;
            bouton.Text = "Valider le découvert";


            tb.Visible = true;

        }



        private List<Compte> lstcpt = new List<Compte>();

        private void Gestion_Load(object sender, EventArgs e)
        {
           /*  Client cl1 = new Client(1, "Dupont", "toto", "Créteil");
             Client cl2 = new Client(2, "Abdala", "momo", "Cachan");

             Compte c1 = new CompteCourant(12, cl1);
             Compte c3 = new CompteCourant(11, cl2);
             Compte c4 = new CompteEpargne(9, cl1,1.1);

             lstcpt.Add(c1);
             lstcpt.Add(c3);
             lstcpt.Add(c4);*/

           lstcpt = Serialise.chargement();


           

            rafraichirListBox();
        }

        private void rafraichirListBox()
        {

            lBox.DataSource = null;
            lBox.DataSource = lstcpt;
            lBox.DisplayMember = "Description";

        }



        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Compte c = (Compte)lBox.SelectedItem;

            Client cl = c.Propriétaire;

            FormClient fc = new FormClient(cl);

            fc.ShowDialog();

            rafraichirListBox();


        }

        private void Gestion_FormClosing(object sender, FormClosingEventArgs e)
        {
            Serialise.sauvegarde(lstcpt);
        }
    }
}
