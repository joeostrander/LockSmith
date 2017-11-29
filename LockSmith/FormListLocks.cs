using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trinet.Networking;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace LockSmith
{
    public partial class FormListLocks : Form
    {

        
        public string strFilePath;
        
        private struct FileLockInfo
        {
            public string remotePath;
            public int numberOfLocks;
            public string permissions;
            public string userName;
            public int id;
        }

        private static List<FileLockInfo> listFileInfo = new List<FileLockInfo>();

        [DllImport("netapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern int NetFileClose(string servername,int id);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern void SetLastError(uint dwErrorCode);

        int intUncColumnNumber = 4;
        int intIdColumnNumber = 5;

        public FormListLocks()
        {
            InitializeComponent();
        }

        private void ComboBoxServer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void FormListLocks_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName;

            if (!String.IsNullOrEmpty(strFilePath))
            {
                textBox1.Text = strFilePath;
                banana();
            }

        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();

        }

        private void banana()
        {
            string filePath = textBox1.Text;

            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }
            

            if (!File.Exists(filePath))
            {
                MessageBox.Show("File not found:\n\n" + filePath, "File not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            FileInfo fileInfo = new FileInfo(filePath);

            string uncPath = Extensions.UncPath(fileInfo);

            if (string.IsNullOrEmpty(uncPath))
            {
                MessageBox.Show("Error getting UNC path for:\n\n" + filePath, "Bad UNC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            ListView1.Items.Clear();
            listFileInfo.Clear();

            string remoteFileName = ShareCollection.UncPathToRemoteFilePath(uncPath);
            
            if (!string.IsNullOrEmpty(remoteFileName))
            {
                string server = GetServerNameFromUNC(uncPath);
                FileEnum(remoteFileName, server);
            }
            else
            {
                MessageBox.Show("Error getting remote file name", "Remote file name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (listFileInfo.Count > 0)
            {

                int i = 0;
                foreach (FileLockInfo info in listFileInfo)
                {
                    ListViewItem lvi = new ListViewItem(info.remotePath);
                    lvi.SubItems.Add(info.userName);
                    lvi.SubItems.Add(info.numberOfLocks.ToString());
                    lvi.SubItems.Add(info.permissions);
                    lvi.SubItems.Add(uncPath);
                    lvi.SubItems.Add(info.id.ToString());

                    ListView1.Items.Add(lvi);

                }

                ColorLines(ListView1, false);

            }


        }

        private string GetServerNameFromUNC(string remoteFileName)
        {
            Console.WriteLine("file:  {0}", remoteFileName);
            string pattern = @"\\\\(?<server>[^\\]+)\\";
            Regex rx = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection colMatches = rx.Matches(remoteFileName);
            if (colMatches.Count > 0)
            {
                return colMatches[0].Groups["server"].Value;
            } 
            else
            {
                return null;
            }

        }

        private static void FileEnum(string sPath, string sServer = "")
        {
            int EntriesRead = 0;
            int TotalRead = 0;
            IntPtr ResumeHandle = IntPtr.Zero;
            IntPtr bufptr = IntPtr.Zero;
            int ret;

            IntPtr ptrEntry;

            GCHandle handle = GCHandle.Alloc(sServer, GCHandleType.Pinned);
            IntPtr ptrServer;

            int totalEntries = 0;
            int idx = totalEntries;


            do
            {

                Console.WriteLine("Server:  {0}", sServer);
                ret = OpenFiles.NetFileEnum(sServer, sPath, null, 3, ref bufptr, OpenFiles.MAX_PREFERRED_LENGTH, out EntriesRead, out TotalRead, ResumeHandle);
                OpenFiles.SetLastError((uint)ret);

                string errorMessage = new Win32Exception(Marshal.GetLastWin32Error()).Message;
                if (ret != (int)OpenFiles.NERR.ERROR_MORE_DATA && ret != (int)OpenFiles.NERR.NERR_Success)
                {
                    Console.WriteLine("Error:  " + errorMessage);
                    //break;
                    //return;
                }

                for (int i = 0; i < EntriesRead; i++)
                {

                    OpenFiles.FILE_INFO_3 entry = new OpenFiles.FILE_INFO_3();
                    ptrEntry = bufptr + (Marshal.SizeOf(entry) * i);
                    entry = (OpenFiles.FILE_INFO_3)Marshal.PtrToStructure(ptrEntry, typeof(OpenFiles.FILE_INFO_3));

                    idx = totalEntries + i;
                    //if (i == 0)
                    //{
                    //    Console.WriteLine("#,Locks,\"Server Path\",Permissions,\"User ID\"");
                    //}
                    Console.WriteLine("{0},{1},\"{2}\",\"{3}\",{4}", i + 1, entry.fi3_NumLocks, entry.fi3_PathName, entry.fi3_Permissions, entry.fi3_UserName);


                    FileLockInfo info = new FileLockInfo();
                    info.numberOfLocks = entry.fi3_NumLocks;
                    info.remotePath = entry.fi3_PathName.ToString();
                    info.permissions = entry.fi3_Permissions.ToString();
                    info.userName = entry.fi3_UserName.ToString();
                    info.id = entry.fi3_Id;

                    listFileInfo.Add(info);

                }

            } while (ret == (int)OpenFiles.NERR.ERROR_MORE_DATA);
        }



        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All Files|*.*";
            openFileDialog1.Title = "Select a file:";
            openFileDialog1.FileName = "";
            //openFileDialog1.InitialDirectory = 
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string fileName = textBox1.Text;
            if (string.IsNullOrEmpty(fileName))
            {
                MessageBox.Show("Select a file!", "Select file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!System.IO.File.Exists(fileName))
            {
                MessageBox.Show("Could not find file:\n\n"+fileName, "File not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            banana();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            banana();
        }

        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            banana();
        }

        private void ContextMenuStripListView_Opening(object sender, CancelEventArgs e)
        {
            if (ListView1.Items.Count==0)
            {
                e.Cancel = true;
                return;
            }
        }

        private void CloseFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ( ListView1.SelectedItems.Count == 0 ) { return; }

            int intClosedCount = 0;
            int intFailedCount = 0;
            string output = "";

            foreach (ListViewItem lvi in ListView1.SelectedItems) {

                string strUNC = lvi.SubItems[intUncColumnNumber].Text;
                string strID = lvi.SubItems[intIdColumnNumber].Text;

                Boolean boolExists = IsValidUncPath(strUNC);
                string strServer = GetServerNameFromUNC(strUNC);

                if (boolExists) {
                    int ret = NetFileClose(strServer, int.Parse(strID));
                    if (ret == 0 || ret == 2314) {
                        intClosedCount += 1;
                            ListView1.Items.Remove(lvi);
                        } else
                    {

                        SetLastError((uint)ret);
                        string errorMessage = "(" + ret.ToString() + ") " + (new Win32Exception(Marshal.GetLastWin32Error()).Message);
                        intFailedCount += 1;
                        output += "Failed:  " + strUNC + "\n" + errorMessage + "\n\n";
                    }

                }
                    else
                {
                    intFailedCount += 1;
                        output += "Not found:  " + strUNC;
                    }
            }

            ColorLines(ListView1, false);

            if (intClosedCount > 0)
            {
                MessageBox.Show("Closed " + intClosedCount + " file(s)", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (intFailedCount > 0) {
                MessageBox.Show("Failed to close " + intFailedCount + " file(s):\n" + output, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        
        private void ColorLines(ListView lv, Boolean boolRenumber)
        {
            int count = 0;
            foreach (ListViewItem line in lv.Items) 
            {
                count += 1;

                if ( boolRenumber ) {
                    line.SubItems[0].Text = count.ToString();
                }

                if ( count % 2 == 0 ) 
                {
                    line.BackColor = Color.OldLace;
                }
                else
                {
                    line.BackColor = Color.White;
                }

                line.ForeColor = Color.Black;

            }
        }


        private Boolean IsValidUncPath(string strUNC)
        {
            if (System.IO.Directory.Exists(strUNC) || System.IO.File.Exists(strUNC))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ClearResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView1.Items.Clear();
        }

        private void ExportListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportListView.SaveAsCSV(ListView1);
        }

        private void ShowInExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (ListView1.SelectedItems.Count == 0 ) { return; }

            if ( ListView1.SelectedItems.Count > 1 ) 
            {
                MessageBox.Show("Please select only 1 item.", Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            string strUnc = ListView1.SelectedItems[0].SubItems[intUncColumnNumber].Text;

            if (IsValidUncPath(strUnc)) 
            {
                ExploreFolder(strUnc);
            } 
            else
            {
                MessageBox.Show("Not found:\n\n" + strUnc, Application.ProductName,MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ExploreFolder(string strPath)
        {
            try
            {
                Process proc = new Process();
                proc.StartInfo = new ProcessStartInfo("explorer.exe", "/e,/select,\"" + strPath + "\"");
                proc.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
