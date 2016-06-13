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

namespace DataAnalysiser
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public double[] data_entry_array = new double[0];

        public MainWindow()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void numerical_entry_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            bool yes_parse = false;
            {
                // 既存のテキストボックス文字列に、
                // 今新規に一文字追加された時、その文字列が
                // 数値として意味があるかどうかをチェック
                {
                    float xx;
                    var tmp = numerical_entry.Text + e.Text;
                    yes_parse = Single.TryParse(tmp, out xx);
                }
                // 最初の一文字の場合に限り、プラス文字とマイナス文字の
                // 入力は許可する。
                yes_parse |=
                    (numerical_entry.Text.Length == 0) &&
                    (e.Text == "+") || (e.Text == "-");
            }
            // 更新したい場合は false, 更新したくない場合は true
            // を返すべし。（混乱しやすいので注意！）
            e.Handled = !yes_parse;
            //from(http://d.hatena.ne.jp/nurs/20150427/1430150521)
        }

        private void numerical_entry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && numerical_entry.Text != "" && numerical_entry.Text !="-")
            {
                //データ入れとく配列の長さを取得し、配列の長さを一個分増やす
                Array.Resize(ref data_entry_array, data_entry_array.Length + 1);
                data_entry_array[data_entry_array.Length - 1] = double.Parse(numerical_entry.Text);

                Array.Sort(data_entry_array);
                string DataString = string.Join(",", data_entry_array);
                numerical_entry_show.Text = DataString;

                Console.WriteLine(data_entry_array.Length / 2 + 1);
                update();
                     
                //textboxの中身をリセット
                numerical_entry.Clear();
            }
        }

        private void update()
        {
            Ave_result.Text = DataAnalysisSystem.calc_Ave(data_entry_array).ToString();
            Q2_result.Text = DataAnalysisSystem.calc_q2(data_entry_array).ToString();
            Q1_result.Text = DataAnalysisSystem.calc_q1(data_entry_array).ToString();
            Q3_result.Text = DataAnalysisSystem.calc_q3(data_entry_array).ToString();
            IQR_result.Text = DataAnalysisSystem.calc_IQR(data_entry_array).ToString();
            QD_result.Text = DataAnalysisSystem.calc_QD(data_entry_array).ToString();
            S2_result.Text = DataAnalysisSystem.calc_S2(data_entry_array).ToString();
            S_result.Text = DataAnalysisSystem.calc_S(data_entry_array).ToString();
            minScale.Text = BoxplotSystem.setScale(data_entry_array)[0].ToString();
            maxScale.Text = BoxplotSystem.setScale(data_entry_array)[1].ToString();
            OneScaleText.Text = BoxplotSystem.setOneScale(data_entry_array).ToString();
            drawBoxplot(data_entry_array);
        }

        private void clearData()
        {
            Array.Clear(data_entry_array, 0, data_entry_array.Length);
            Array.Resize(ref data_entry_array, 0);
            BoxplotMainLine.X1 = 0;
            BoxplotMainLine.X2 = 0;
            BoxplotQ1Line.X1 = 0;
            BoxplotQ1Line.X2 = 0;
            BoxplotQ3Line.X1 = 0;
            BoxplotQ3Line.X2 = 0;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            clearData();
            numerical_entry_show.Text = "";
            Ave_result.Text = "";
            Q2_result.Text = "";
            Q1_result.Text = "";
            Q3_result.Text = "";
            IQR_result.Text = "";
            QD_result.Text = "";
            S2_result.Text = "";
            S_result.Text = "";
            minScale.Text = "";
            maxScale.Text = "";
            OneScaleText.Text = "";
        }

        public void drawBoxplot(double[] dataarray)
        {
            double oneScale = BoxplotSystem.setOneScale(dataarray);
            double maxValue = dataarray[dataarray.Length - 1];
            double minValue = dataarray[0];
            double maxScale = BoxplotSystem.setScale(dataarray)[1];
            double minScale = BoxplotSystem.setScale(dataarray)[0];

            double leftMargin = (minValue - minScale) / oneScale * 20;
            double rightMargin = (maxScale - maxValue) / oneScale * 20;
            double width = (maxValue - minValue) / oneScale * 20;

            BoxplotMainLine.X1 = leftMargin;
            BoxplotMainLine.X2 = 200 - rightMargin;

            BoxplotQ1Line.X1 = leftMargin;
            BoxplotQ1Line.X2 = leftMargin;
            BoxplotQ3Line.X1 = 200 - rightMargin;
            BoxplotQ3Line.X2 = 200 - rightMargin;

        }
    }
}
