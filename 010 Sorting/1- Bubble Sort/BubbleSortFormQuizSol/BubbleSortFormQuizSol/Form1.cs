using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubbleSortFormQuizSol
{
    public partial class Form1 : Form
    {
        List<int> dataList;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int[] rawData = new int[]  { 39, 24, 44, 31, 36, 9, 50, 23, 49, 2, 27, 43, 40, 10, 32, 48,22, 5, 3, 21, 26, 37, 11, 47, 6, 42, 20, 25, 
                    12, 19, 1, 28, 7, 35, 33, 18, 13, 41, 17, 4, 46, 29, 14, 16, 34, 8, 30, 45, 15, 38 };
            dataList = new List<int>();
            for (int i = 0; i < rawData.Length; i++)
            {
                dataList.Add(rawData[i]);
            }
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            labelOutput.Text = "";
            foreach (int item in dataList)
            {
                labelOutput.Text = labelOutput.Text + item.ToString() + " ";
            }
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            bool switchedAny = true;  // optimization, no need for outer loop to be as long as list if none where flipped on a pass thru
            int temp;
            int count = 0;
            int listLength = dataList.Count;
            //sorting an array
            for (int i = 1; (i <= (listLength - 1) && switchedAny) ; i++)
            {
                switchedAny = false;
                for (int j = 0; j < (listLength - 1); j++)
                {
                    if (dataList[j + 1] < dataList[j])
                    {
                        temp = dataList[j];
                        dataList[j] = dataList[j + 1];
                        dataList[j + 1] = temp;
                        //dataList.Reverse(j, 2);   // can use this List method, reverses the list start at node j, and does as many as specified in 2nd arguement
                        switchedAny = true;
                    }
                }
                count++;
            }

            labelCount.Text = (count).ToString();
            // make up some method arguments to keep buttonShow_Click happy
            object o = new object();
            EventArgs ev = new EventArgs();
            buttonShow_Click(o, ev); // call my event method
        }
    }
}
