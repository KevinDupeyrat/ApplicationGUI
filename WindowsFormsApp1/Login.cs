﻿using System;
using System.Windows.Forms;
using LettreCooperation.modele;
using WindowsFormsApp1.Model;

namespace LettreCooperation
{
    public partial class Login : UserControl
    {

       
        public Login()
        {
            InitializeComponent();
            this.textBoxPass.PasswordChar = '•';

        }


        /// <summary>
        /// Méthode qui permet la vérification des informations de 
        /// connexion avec la base de données.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonConnexion_Click(object sender, EventArgs e)
        {

            if (this.textBoxUtilisateur.Text != "" && this.textBoxPass.Text != "")
            {
                ModelManager connexion = new ModelManager();
                Utilisateur connecte = connexion.seConnecter(this.textBoxUtilisateur.Text, this.textBoxPass.Text);

               
                if (connecte != null)
                {
                    this.Visible = false;
                    PagePrincipale.Utilisateur = connecte;

                    this.InitMainPage();

                    this.textBoxUtilisateur.Text = string.Empty;
                    this.textBoxPass.Text = string.Empty;

                    this.labelErrorConnect.Text = string.Empty;

                } else
                {
                    this.labelErrorConnect.Text = "Identifiants incorrects";
                }

            }
            else
            {
                this.labelErrorConnect.Text = "Merci de renseigner les champs vides.";
            }
           
        }


        /// <summary>
        /// Permet d'initialiser les élélements
        /// de la page principale après la connexion
        /// </summary>
        private void InitMainPage()
        {
            Panel panel = (Panel)this.Parent.Controls.Find("mainPanel", false)[0];
            panel.Visible = true;

            PictureBox imageHome = (PictureBox)this.Parent.Controls.Find("imageHome", false)[0];
            imageHome.Visible = true;

            PictureBox pictureLogout = (PictureBox)this.Parent.Controls.Find("pictureLogout", false)[0];
            pictureLogout.Visible = true;

            Label labelUser = (Label)this.Parent.Controls.Find("labelUser", false)[0];
            labelUser.Visible = true;



            Label labelWelcome = (Label)this.Parent.Controls.Find("labelUser", false)[0];
            labelWelcome.Text = PagePrincipale.Utilisateur.nom_utilisateur
        + " " + PagePrincipale.Utilisateur.prenom_utilisateur;

        }
    }
}
