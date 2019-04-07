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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Galactica_Converter
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int swichInicator = 0; // 0: spaca to earth units   1: earth to space units
        public MainWindow()
        {
            // WELCOME WINDOW 
            WelcomeWindow welcome = new WelcomeWindow();
            welcome.Show();
            
            System.Threading.Thread.Sleep(3000); // WAIT 3 SEK
            welcome.Close();


            InitializeComponent();
            createUnits(0);
            

        }

        private void createUnits(int x)
        {
            //calcutating units
            string[] unitsSpace = {  "light-second", "light-minute",
                "astronimical unit", "light-year", "parsec"};

            string[] unitsEarth = { "metre [m]", "kilometre [km]", "nautical mile [nm]" };

            //clear comboBox is useful for switching between units group
            fromComboBox.Items.Clear();
            toComboBox.Items.Clear();

            if (x == 0) { 
            //creat comboBox Items
            foreach(string unit in unitsSpace)
            {
                fromComboBox.Items.Add(unit);
            }

            foreach (string unit in unitsEarth)
            {
                toComboBox.Items.Add(unit);
            }
            }
            else
            {
                foreach (string unit in unitsSpace)
                {
                    toComboBox.Items.Add(unit);
                }

                foreach (string unit in unitsEarth)
                {
                    fromComboBox.Items.Add(unit);
                }
            }
        }

        //converting units
        private void calculateBtn_Click(object sender, RoutedEventArgs e)
        {
            int x;
            int y;
            String value = "0";
           

            value = enterValueBox.Text;
            x = fromComboBox.SelectedIndex;
            y = toComboBox.SelectedIndex;
            decimal z = 0;
            try { 
            z = decimal.Parse(value);
            }
            catch (FormatException)
            {
                resultBlock.Text = "wrong entered value";
                return;
            }
            //validation 
            if (x >= 0 && y >= 0 && z>0) { 
                decimal result = Engine.calculate(x, y, z, swichInicator);
                String resultFormated;
                try
                { //Fromating result : 12 345 678 901
                    if (result > 1)
                    {
                        resultFormated = String.Format("{0:#,#}", result);
                    }
                    else
                    {   //it`s not working well
                        resultFormated = String.Format("{#.###,###,###,###,###,###,###}", result);
                    }
                }
                catch (FormatException)
                {
                    resultFormated = result.ToString();
                }
              
            resultBlock.Text = resultFormated;

            }
            else { resultBlock.Text = "entered value is under 0 or didn`t choose units"; }
                       
        } 

      // SWITCHING BETWEEN UNITS ( SPACE TO EARTH AND EARTH TO SPACE)
        private void switchUnits(object sender, RoutedEventArgs e)
        {
            

            if (swichInicator==0)
            {
                swichInicator++;
                createUnits(swichInicator);
            }
            else
            {
                swichInicator--;
                createUnits(swichInicator);
            }
        }
    }
}
