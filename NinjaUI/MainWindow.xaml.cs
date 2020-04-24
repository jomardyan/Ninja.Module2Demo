using NinjaDomain.Classes;
using NinjaDomin.DataModel;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using FluentValidation;
using FluentValidation.Results;
using System.Linq;
using System.CodeDom;
using System.Data.Entity;
using System.Windows.Documents;
using System.Collections.Generic;
using System.Windows.Data;

namespace NinjaUI
{

    public class NinjarValidator : AbstractValidator<Ninja>
    {
        public NinjarValidator()
        {
            RuleFor(Ninja => Ninja.Name).NotEmpty();
            RuleFor(Ninja => Ninja.ClanId).InclusiveBetween(1, 10); 
        }
    }


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();

        }

        //Delagate to print mesage to debug line

        private void Button_add_Click(object sender, RoutedEventArgs e)
        {
            bool? ninjaserver = null;

            if (CBBOX.SelectedIndex == 0)
            {
                //MessageBox.Show("True");
                ninjaserver = true;
            }
            else if (CBBOX.SelectedIndex == 1)
            {
                //MessageBox.Show("False");
                ninjaserver = true;
            }

            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            var cid = (Clan) ComboClans.SelectedItem;

            var ninja = new Ninja
            {
                Name = TB_NAME.Text,
                ServerInOniwaban = Convert.ToBoolean(ninjaserver),
                DateOfBirth = DataP.SelectedDate.HasValue ? (DateTime)DataP.SelectedDate : DateTime.Now,
                DataCreated = DateTime.Now,
                DataModified = DateTime.Now,
                ClanId = cid.Id
            };


            try
            {
                NinjarValidator validator = new NinjarValidator();
                validator.ValidateAndThrow(ninja);
                using (var context = new NinjaContext())
                {
                    context.Database.Log = NinjaTools.print;
                    context.Ninjas.Add(ninja);
                    context.SaveChanges();

                    StatusLabel.Foreground = Brushes.Green;
                    StatusLabel.Content = "Success, Ninja ID: " + ninja.Id;
                }
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Clan> x; 

            using (var context = new NinjaContext())
            {
                //var clans = context.Clans.OrderBy(n => n.ClanName).Select(n => n.ClanName).ToList();

                var clans2 = context.Clans.AsNoTracking().OrderBy(c => c.ClanName).ToList();

                x = clans2; 

            }

            CollectionViewSource clanViewSource = (CollectionViewSource)this.FindResource("clanViewSource");
            // Load data by setting the CollectionViewSource.Source property:
            clanViewSource.Source = x;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new ClansWindow();
            window.Show(); 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            using (var context = new NinjaContext())
            {
                context.Database.Log = NinjaTools.print;
                var q = from b in context.Clans
                        select b.ClanName;
                ComboClans.Items.Clear();
                foreach (var item in q)
                {
                    ComboClans.Items.Add(item);
                }
                ComboClans.Items.Refresh();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var AddEquipment = new AddEquipment();
            AddEquipment.Show(); 
        }
    }
}