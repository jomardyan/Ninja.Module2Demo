using NinjaDomain.Classes;
using NinjaDomin.DataModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;   
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NinjaUI
{
    /// <summary>
    /// Interaction logic for Clans.xaml
    /// </summary>
    public partial class ClansWindow : Window
    {

        public ClansWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ClanName.Text.Length > 0)
            {
                Clan clan1 = new Clan { 
                    ClanName = ClanName.Text, 
                    DataCreated = DateTime.Now, 
                    DataModified = DateTime.Now };

                using (var context = new NinjaContext())
                {
                
                        context.Database.Log = NinjaTools.print;
                        context.Clans.Add(clan1);
                        context.SaveChanges();
                    
                    
                }
            }
            else
            {
                MessageBox.Show("Please enter Clan Name");

            }
        }
    }
}
