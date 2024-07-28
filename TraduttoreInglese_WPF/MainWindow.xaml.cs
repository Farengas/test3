using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace WPF_PronunciaInglese
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly string[] Units = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        private static readonly string[] Teens = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private static readonly string[] Tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        private static readonly string[] Thousands = { "", "Thousand", "Million", "Billion" };
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OnConvertButtonClick(object sender, RoutedEventArgs e)
        {
            if (long.TryParse(NumberInput.Text, out long number)){
                string words = ConvertNumberToWords(number);
                ResultText.Text = words;
            }else           
                MessageBox.Show("Please enter a valid number.");           
        }
        private string ConvertNumberToWords(long number)
        {
            if (number == 0)
                return Units[0];
            if (number < 0)
                return "Minus " + ConvertNumberToWords(-number);
            List<string> parts = new List<string>();
            int thousandGroup = 0;
            while (number > 0){
                int part = (int)(number % 1000);
                if (part > 0){
                    string partWords = ConvertPartToWords(part);
                    if (thousandGroup > 0)
                        partWords += " " + Thousands[thousandGroup];
                    parts.Insert(0, partWords);
                }
                number /= 1000;
                thousandGroup++;
            }
            return string.Join(", ", parts);
        }
        private string ConvertPartToWords(int number)
        {
            List<string> parts = new List<string>();
            if (number >= 100){
                parts.Add(Units[number / 100] + " Hundred");
                number %= 100;
            }
            if (number >= 20){
                parts.Add(Tens[number / 10]);
                number %= 10;
            }else if (number >= 10){
                parts.Add(Teens[number - 10]);
                number = 0;
            }
            if (number > 0)
                parts.Add(Units[number]);           
            return string.Join(" ", parts);
        }
    }
}