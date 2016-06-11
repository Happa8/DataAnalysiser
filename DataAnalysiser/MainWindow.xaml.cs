﻿using System;
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
                Q2_result.Text = DataAnalysisSystem.calc_q2(data_entry_array).ToString();
                Q1_result.Text = DataAnalysisSystem.calc_q1(data_entry_array).ToString();
                Q3_result.Text = DataAnalysisSystem.calc_q3(data_entry_array).ToString();
                IQR_result.Text = DataAnalysisSystem.calc_IQR(data_entry_array).ToString();
                QD_result.Text = DataAnalysisSystem.calc_QD(data_entry_array).ToString();
                S2_result.Text = DataAnalysisSystem.calc_S2(data_entry_array).ToString();
                S_result.Text = DataAnalysisSystem.calc_S(data_entry_array).ToString();
                     
                //textboxの中身をリセット
                numerical_entry.Clear();
            }
        }
    }
}
