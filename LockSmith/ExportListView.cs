using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public static class ExportListView
{
    
     
public static void SaveAsCSV(ListView lv)
{
        SaveFileDialog sfd = new SaveFileDialog();
        sfd.Filter = "CSV Files|*.csv";

        if (sfd.ShowDialog() != DialogResult.OK ) { return; }

        string strFilename = sfd.FileName;
        StreamWriter writer = new StreamWriter(strFilename);

        string strHeaders = "";

        foreach (ColumnHeader colTitle in lv.Columns) 
        {
            strHeaders += "\"" + colTitle.Text + "\",";
        }

        if (strHeaders.EndsWith(","))
        {
            strHeaders = strHeaders.Remove(strHeaders.Length - 1);
        }
        writer.WriteLine(strHeaders);

        foreach (ListViewItem row in lv.Items) 
        {
            string strRowText = "";
            foreach (ListViewItem.ListViewSubItem itm in row.SubItems) 
            {
                strRowText += "\"" + itm.Text + "\",";
            }
            if (strRowText.EndsWith(","))
            { 
                strRowText = strRowText.Remove(strRowText.Length - 1);
            }
            writer.WriteLine(strRowText);
        }

        writer.Close();
        MessageBox.Show("See file:\n\n" + strFilename,Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Information);
    }
     
     

}
