using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameStation.Libs
{
    class ListViewItemComparer : IComparer
    {
        public SortOrder Order = SortOrder.Ascending;
        public int Column;

        public ListViewItemComparer()
        {
            Column = 0;
        }
        public ListViewItemComparer(int column)
        {
            Column = column;
        }
        public int Compare(object x, object y)
        {
            int returnVal = 0;

            if(Column == 0 || Column == 4 || Column == 5) {
                string fValue = Basics.limpaString(((ListViewItem)x).SubItems[Column].Text);
                string sValue = Basics.limpaString(((ListViewItem)y).SubItems[Column].Text);
                int a = int.Parse(fValue);
                int b = int.Parse(sValue);

                returnVal = a.CompareTo(b);
            } else {
                returnVal = String.Compare(((ListViewItem)x).SubItems[Column].Text, ((ListViewItem)y).SubItems[Column].Text);
            }
            

            if (Order == SortOrder.Descending)
                return -returnVal;
            else
                return returnVal;
        }

        public SortOrder Swap(SortOrder order)
        {
            return order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
        }
    }
}
