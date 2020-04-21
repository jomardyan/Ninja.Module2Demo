using NinjaDomain.Classes;
using NinjaDomin.DataModel;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddEquipment.xaml
    /// </summary>
    public partial class AddEquipment : Window
    {
        public AddEquipment()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var context = new NinjaContext())
            {
                ComboType.Items.Add(EquipmentType.Tool);
                ComboType.Items.Add(EquipmentType.Weapon);
                ComboType.Items.Add(EquipmentType.OutWear);
                }
            }
        }
    }

