using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTP
{
    public partial class MainForm : Form
    {
        public string DomainName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        //服务器当前目录下文件
        public List<SimpleFile> CurFiles = new List<SimpleFile>();
        //服务器当前目录
        public string CurDir { get; set; }
        //本地当前目录
        public string LocalCurDir { get; set; }


        public MainForm()
        {
            InitializeComponent();

            CurDir = "/";

            //初始化域名、用户名、密码
            //DomainName = "ftp.dlptest.com";
            //Username = "dlpuser";
            //Password = "rNrKYTX9g7z3RgJRmxWuGHbeu";


            //设置窗口图标
            Icon wndIcon = getExtractIcon("%SystemRoot%\\system32\\shell32.dll", 146);
            this.Icon = wndIcon;

            // 获取目录中的图标
            Icon file = getExtractIcon("%SystemRoot%\\system32\\shell32.dll", 0);
            Icon folder = getExtractIcon("%SystemRoot%\\system32\\shell32.dll", 3);
            Icon disk = getExtractIcon("%SystemRoot%\\system32\\shell32.dll", 8);
            Icon computer = getExtractIcon("%SystemRoot%\\system32\\shell32.dll", 15);
            Icon upload = getExtractIcon("%SystemRoot%\\system32\\shell32.dll", 68);
            Bitmap bm = ((Icon)upload.Clone()).ToBitmap();
            bm.RotateFlip(RotateFlipType.Rotate180FlipY);
            Icon download = Icon.FromHandle(bm.GetHicon());
            Icon transSuccess = getExtractIcon("%SystemRoot%\\system32\\shell32.dll", 144);
            FileIcon.Images.Add("file", file);
            FileIcon.Images.Add("folder", folder);
            FileIcon.Images.Add("disk", disk);
            FileIcon.Images.Add("computer", computer);
            FileIcon.Images.Add("upload", upload);
            FileIcon.Images.Add("download", download);
            FileIcon.Images.Add("transSuccess", transSuccess);

            // 初始化本地目录树
            InitLocalDirTree();
        }

        [DllImport("shell32.dll")]
        public static extern int ExtractIcon(IntPtr h, string strx, int ii);
        /// <summary>
        /// get the icon of the file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="iIndex"></param>
        /// <returns></returns>
        public Icon getExtractIcon(string fileName, int iIndex)
        {
            try
            {
                IntPtr hIcon = (IntPtr)ExtractIcon(this.Handle, fileName, iIndex);
                if (hIcon != IntPtr.Zero)
                {
                    Icon icon = Icon.FromHandle(hIcon);
                    return icon;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误提示", 0, MessageBoxIcon.Error);
            }
            return null;
        }

        private void InitLocalDirTree()
        {
            // 添加根节点 - 我的电脑
            TreeNode main = new TreeNode("我的电脑");
            main.ImageKey = "computer";
            main.SelectedImageKey = "computer";
            LocalTreeView.Nodes.Add(main);
            ListViewShow(main);
            // 添加子节点 - 磁盘的各个分区
            //string[] disksNames = Directory.GetLogicalDrives();
            //foreach(var i in disksNames)
            //{
            //    TreeNode d = new TreeNode(i, 1, 1);
            //    main.Nodes.Add(d);
            //}
        }

        /// <summary>
        /// 将当前目录中的文件与子目录显示在目录列表中
        /// </summary>
        /// <param name="NodeDir"></param>
        private void ListViewShow(TreeNode NodeDir)
        {
            // 清空原有的列表
            LocalListView.Items.Clear();
            try
            {
                if (NodeDir.Parent == null)     // 如果当前TreeView的父结点为空，就把我的电脑下的分区名称添加进来
                {
                    // 创建ListViewItem时，其内容应为图标，其SubItem依次添加名称、大小、创建时间
                    foreach (string DrvName in Directory.GetLogicalDrives())     // 获得硬盘分区名
                    {
                        ListViewItem ItemList = new ListViewItem(DrvName);
                        ItemList.ImageKey = "disk";
                        ItemList.SubItems.Add("");
                        ItemList.SubItems.Add("");
                        LocalListView.Items.Add(ItemList);
                        LocalCurDir = "";
                    }
                }
                else     // 如果当前TreeView的父结点不为空，把点击的结点，做为一个目录文件的总结点
                {
                    foreach (string DirName in Directory.GetDirectories((string)NodeDir.Tag))     // 编历当前分区或文件夹所有目录
                    {
                        DirectoryInfo di = new DirectoryInfo(DirName);
                        ListViewItem ItemList = new ListViewItem(di.Name);
                        ItemList.ImageKey = "folder";
                        ItemList.SubItems.Add("");
                        ItemList.SubItems.Add("");
                        LocalListView.Items.Add(ItemList);
                    }
                    foreach (string FileName in Directory.GetFiles((string)NodeDir.Tag))     // 编历当前分区或文件夹所有文件
                    {
                        FileInfo fi = new FileInfo(FileName);
                        ListViewItem ItemList = new ListViewItem(fi.Name);
                        ItemList.ImageKey = "file";
                        ItemList.SubItems.Add(ConvertSize(fi.Length));
                        ItemList.SubItems.Add(fi.CreationTime.ToString());
                        LocalListView.Items.Add(ItemList);
                    }
                    LocalCurDir = Path.Combine(LocalCurDir, NodeDir.Tag.ToString());
                }
            }
            catch { }
        }

        /// <summary>
        /// 获取当有文件夹内的文件和目录
        /// </summary>
        /// <param name="DirFileName"></param>
        private void ListViewShow(string DirFileName)
        {
            // 清空原有的列表
            LocalListView.Items.Clear();
            try
            {
                foreach (string DirName in Directory.GetDirectories(DirFileName))
                {
                    DirectoryInfo di = new DirectoryInfo(DirName);
                    ListViewItem ItemList = new ListViewItem(di.Name);
                    ItemList.ImageKey = "folder";
                    ItemList.SubItems.Add("");
                    ItemList.SubItems.Add("");
                    LocalListView.Items.Add(ItemList);
                }
                foreach (string FileName in Directory.GetFiles(DirFileName))
                {
                    FileInfo fi = new FileInfo(Path.Combine(DirFileName, FileName));
                    ListViewItem ItemList = new ListViewItem(fi.Name);
                    ItemList.ImageKey = "file";
                    ItemList.SubItems.Add(ConvertSize(fi.Length));
                    ItemList.SubItems.Add(fi.CreationTime.ToString());
                    LocalListView.Items.Add(ItemList);
                }
                LocalCurDir = Path.Combine(LocalCurDir, DirFileName);
            }
            catch { }
        }

        /// <summary>
        /// 显示树形结构
        /// </summary>
        /// <param name="NodeDir"></param>
        private void TreeViewShow(TreeNode NodeDir)     // 初始化TreeView控件
        {
            try
            {
                if (NodeDir.Nodes.Count == 0)     // 仅在第一次进行显示时添加子结点
                {
                    if (NodeDir.Parent == null)     // 如果结点为空，添加并显示硬盘分区
                    {
                        foreach (string DrvName in Directory.GetLogicalDrives())
                        {
                            TreeNode aNode = new TreeNode(DrvName);
                            aNode.ImageKey = "disk";
                            aNode.SelectedImageKey = "disk";
                            aNode.Tag = DrvName;
                            NodeDir.Nodes.Add(aNode);
                        }
                    }
                    else     // 不为空，添加并显示分区下文件夹
                    {
                        foreach (string DirName in Directory.GetDirectories((string)NodeDir.Tag))
                        {
                            TreeNode aNode = new TreeNode(DirName);
                            aNode.ImageKey = "folder";
                            aNode.SelectedImageKey = "folder";
                            aNode.Tag = DirName;
                            NodeDir.Nodes.Add(aNode);
                        }
                    }
                }
            }
            catch { }
        }

        //文件大小显示
        private string ConvertSize(Int64 size)
        {
            if (size < 1024)
                return $"{size}B";
            else if (size >= 1024 && size < 1048576)
                return $"{Convert.ToDouble((double)size / 1024.0).ToString("0.00")}KB";
            else if (size >= 1048576 && size < 1073741824)
                return $"{Convert.ToDouble((double)size / 1048576.0).ToString("0.00")}MB";
            else
                return $"{Convert.ToDouble((double)size / 1073741824.0).ToString("0.00")}GB";
        }

        //连接
        public void Connect(string sArgName, string args = "", params string[] teps)
        {
            

            Process p = new Process();
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + sArgName;
            p.StartInfo.FileName = @"python.exe";
            string sArguments = path;
            foreach(string sigstr in teps)
            {
                sArguments += " " + sigstr;
            }
            sArguments += " " + args;

            p.StartInfo.Arguments = sArguments;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;

            p.Start();
            StreamReader reader = p.StandardOutput;
            string output = reader.ReadToEnd();
            Log.Items.Add(output);
            p.WaitForExit();
        }

        //断开
        public void DisConnect(string sArgName, string args = "")
        {
            Process p = new Process();
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + sArgName;
            p.StartInfo.FileName = @"python.exe";
            string sArguments = path;
            sArguments += " " + args;

            p.StartInfo.Arguments = sArguments;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;

            p.Start();
            StreamReader reader = p.StandardOutput;
            string output = reader.ReadToEnd();
            Log.Items.Add(output);
            p.WaitForExit();
        }

        //显示服务器目录
        public void ListDir(string sArgName, string args = "", params string[] teps)
        {
            Process p = new Process();
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + sArgName;
            p.StartInfo.FileName = @"python.exe";
            string sArguments = path;
            foreach (string sigstr in teps)
            {
                sArguments += " " + sigstr;
            }
            sArguments += " " + args;

            p.StartInfo.Arguments = sArguments;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;

            p.Start();
            StreamReader reader = p.StandardOutput;
            string output = reader.ReadToEnd();
            Log.Items.Add(output);
            ParseDirInfo(output);
            ShowServerDir();
            p.WaitForExit();
        }

        /// <summary>
        /// 解析FTPserver的目录信息
        /// </summary>
        /// <param name="dirInfo"></param>
        private void ParseDirInfo(string dirInfo)
        {
            // clear the old directory info
            CurFiles.Clear();

            string[] strs = dirInfo.Split('\n');
            string time;
            bool isDir;
            Int64 size;
            string name;
            Regex rgs = new Regex(" +[0-9]+ ");
            for(int i = 1; i < strs.Length; i++)
            {
                if (strs[i] == "" || strs[i][0] == '\0') continue;
                var it = strs[i].Substring(30);
                var m = rgs.Match(it);
                size = Int64.Parse(m.Value.Trim());
                isDir = (size == 0) ? true : false;
                time = it.Substring(m.Index + m.Length, 12);
                name = it.Substring(m.Index + m.Length + 13).Trim();
                CurFiles.Add(new SimpleFile(time, name, isDir, size));
            }
        }

        public void ShowServerDir()
        {
            // 清空原有的列表
            ServerListView.Items.Clear();
            try
            {
                // 若不是根目录，则添加返回上级目录选项
                if (CurDir != "/")
                {
                    ListViewItem back = new ListViewItem("..");
                    back.ImageKey = "folder";
                    back.SubItems.Add("");
                    back.SubItems.Add("");
                    ServerListView.Items.Add(back);
                }
                // 添加目录与文件
                foreach (var fd in CurFiles)
                {
                    ListViewItem ItemList = new ListViewItem(fd.name);
                    ItemList.ImageKey = (fd.isDir) ? "folder" : "file";
                    ItemList.SubItems.Add((fd.isDir) ? "" : ConvertSize(fd.size));
                    ItemList.SubItems.Add(fd.createTime);
                    ServerListView.Items.Add(ItemList);
                }
            }
            catch { }
        }

        //新建服务器目录
        public void MakeDir(string sArgName, string args = "", params string[] teps)
        {
            Process p = new Process();
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + sArgName;
            p.StartInfo.FileName = @"python.exe";
            string sArguments = path;
            foreach (string sigstr in teps)
            {
                sArguments += " " + sigstr;
            }
            sArguments += " " + args;

            p.StartInfo.Arguments = sArguments;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;

            p.Start();
            StreamReader reader = p.StandardOutput;
            string output = reader.ReadToEnd();
            Log.Items.Add(output);
            p.WaitForExit();
        }

        //删除服务器文件
        public void Delete(string sArgName, string args = "", params string[] teps)
        {
            Process p = new Process();
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + sArgName;
            p.StartInfo.FileName = @"python.exe";
            string sArguments = path;
            foreach (string sigstr in teps)
            {
                sArguments += " " + sigstr;
            }
            sArguments += " " + args;

            p.StartInfo.Arguments = sArguments;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;

            p.Start();
            StreamReader reader = p.StandardOutput;
            string output = reader.ReadToEnd();
            Log.Items.Add(output);
            p.WaitForExit();
        }

        //上传文件
        public void Upload(string sArgName, string args = "", params string[] teps)
        {
            Process p = new Process();
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + sArgName;
            p.StartInfo.FileName = @"python.exe";
            string sArguments = path;
            foreach (string sigstr in teps)
            {
                sArguments += " " + sigstr;
            }
            sArguments += " " + args;

            p.StartInfo.Arguments = sArguments;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;

            p.Start();
            StreamReader reader = p.StandardOutput;
            string output = reader.ReadToEnd();
            Log.Items.Add(output);
            p.WaitForExit();
        }

        public void Download(string sArgName, string args = "", params string[] teps)
        {
            Process p = new Process();
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + sArgName;
            p.StartInfo.FileName = @"python.exe";
            string sArguments = path;
            foreach (string sigstr in teps)
            {
                sArguments += " " + sigstr;
            }
            sArguments += " " + args;

            p.StartInfo.Arguments = sArguments;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;

            p.Start();
            StreamReader reader = p.StandardOutput;
            string output = reader.ReadToEnd();
            Log.Items.Add(output);
            p.WaitForExit();
        }

        public void ChangePath(string sArgName, string args = "", params string[] teps)
        {
            Process p = new Process();
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + sArgName;
            p.StartInfo.FileName = @"python.exe";
            string sArguments = path;
            foreach (string sigstr in teps)
            {
                sArguments += " " + sigstr;
            }
            sArguments += " " + args;

            p.StartInfo.Arguments = sArguments;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;

            p.Start();
            StreamReader reader = p.StandardOutput;
            string output = reader.ReadToEnd();
            Log.Items.Add(output);
            p.WaitForExit();
        }

        private void LocalTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ListViewShow(e.Node);
            TreeViewShow(e.Node);
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            DomainName = DomainNameTxt.Text;
            Username = UsernameTxt.Text;
            Password = PasswordTxt.Text;

            string[] strArr = new string[3];//参数列表
            string sArguments = @"connect.py";//这里是python的文件名字
            strArr[0] = DomainName;
            strArr[1] = Username;
            strArr[2] = Password;
            Connect(sArguments, "-u", strArr);
            ListDir(@"list_dir.py", "-u", strArr);
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            string sArguments = @"disconnect.py";//这里是python的文件名字
            DisConnect(sArguments, "-u");
        }

        private void MakeDirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DomainName = DomainNameTxt.Text;
            Username = UsernameTxt.Text;
            Password = PasswordTxt.Text;
            string DirName = Interaction.InputBox("请输入新建的目录名：");

            string[] strArr1 = new string[4];//参数列表
            string sArguments1 = @"make_dir.py";//这里是python的文件名字
            strArr1[0] = DomainName;
            strArr1[1] = Username;
            strArr1[2] = Password;
            strArr1[3] = DirName;
            MakeDir(sArguments1, "-u", strArr1);

            string[] strArr2 = new string[3];
            string sArguments2 = @"list_dir.py";
            strArr2[0] = DomainName;
            strArr2[1] = Username;
            strArr2[2] = Password;
            ListDir(sArguments2, "-u", strArr2);
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DomainName = DomainNameTxt.Text;
            Username = UsernameTxt.Text;
            Password = PasswordTxt.Text;
            string FileName = ServerListView.SelectedItems[0].SubItems[0].Text;

            string[] strArr1 = new string[4];//参数列表
            string sArguments1 = @"delete.py";//这里是python的文件名字
            strArr1[0] = DomainName;
            strArr1[1] = Username;
            strArr1[2] = Password;
            strArr1[3] = FileName;
            Delete(sArguments1, "-u", strArr1);

            string[] strArr2 = new string[3];
            string sArguments2 = @"list_dir.py";
            strArr2[0] = DomainName;
            strArr2[1] = Username;
            strArr2[2] = Password;
            ListDir(sArguments2, "-u", strArr2);
        }

        private void UploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DomainName = DomainNameTxt.Text;
            Username = UsernameTxt.Text;
            Password = PasswordTxt.Text;
            int i = LocalListView.SelectedIndices[0];
            string FilePath = Path.Combine(LocalCurDir, LocalListView.Items[i].SubItems[0].Text);

            string[] strArr1 = new string[4];//参数列表
            string sArguments1 = @"upload.py";//这里是python的文件名字
            strArr1[0] = DomainName;
            strArr1[1] = Username;
            strArr1[2] = Password;
            strArr1[3] = FilePath;
            Upload(sArguments1, "-u", strArr1);

            string[] strArr2 = new string[3];
            string sArguments2 = @"list_dir.py";
            strArr2[0] = DomainName;
            strArr2[1] = Username;
            strArr2[2] = Password;
            ListDir(sArguments2, "-u", strArr2);
        }

        private void LocalListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int i = LocalListView.SelectedIndices[0];
            // 如果是目录，则进行切换
            if (LocalListView.SelectedItems[0].SubItems[1].Text == "")
            {
                LocalCurDir = Path.Combine(LocalCurDir, LocalListView.Items[i].SubItems[0].Text);
                ListViewShow(LocalCurDir);
            }
            // 如果是文件，则进行上传
            else
            {
                DomainName = DomainNameTxt.Text;
                Username = UsernameTxt.Text;
                Password = PasswordTxt.Text;
                string FilePath = Path.Combine(LocalCurDir, LocalListView.Items[i].SubItems[0].Text);

                string[] strArr1 = new string[4];//参数列表
                string sArguments1 = @"upload.py";//这里是python的文件名字
                strArr1[0] = DomainName;
                strArr1[1] = Username;
                strArr1[2] = Password;
                strArr1[3] = FilePath;
                Upload(sArguments1, "-u", strArr1);

                string[] strArr2 = new string[3];
                string sArguments2 = @"list_dir.py";
                strArr2[0] = DomainName;
                strArr2[1] = Username;
                strArr2[2] = Password;
                ListDir(sArguments2, "-u", strArr2);
            }
        }

        private void DownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DomainName = DomainNameTxt.Text;
            Username = UsernameTxt.Text;
            Password = PasswordTxt.Text;
            int i = ServerListView.SelectedIndices[0];
            string FileName = ServerListView.Items[i].SubItems[0].Text;

            string[] strArr1 = new string[4];//参数列表
            string sArguments1 = @"download.py";//这里是python的文件名字
            strArr1[0] = DomainName;
            strArr1[1] = Username;
            strArr1[2] = Password;
            strArr1[3] = FileName;
            Upload(sArguments1, "-u", strArr1);

            string[] strArr2 = new string[3];
            string sArguments2 = @"list_dir.py";
            strArr2[0] = DomainName;
            strArr2[1] = Username;
            strArr2[2] = Password;
            ListDir(sArguments2, "-u", strArr2);
        }

        private void ServerListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DomainName = DomainNameTxt.Text;
            Username = UsernameTxt.Text;
            Password = PasswordTxt.Text;
            int i = ServerListView.SelectedIndices[0];
            string FilePath = Path.Combine(CurDir, ServerListView.Items[i].SubItems[0].Text);

            //if (ServerListView.Items[i].Text == "..")
            //{

            //}
            //如果是目录，则进行切换
            if(ServerListView.SelectedItems[0].SubItems[1].Text == "")
            {
                string[] strArr1 = new string[4];//参数列表
                string sArguments1 = @"change_path.py";//这里是python的文件名字
                strArr1[0] = DomainName;
                strArr1[1] = Username;
                strArr1[2] = Password;
                strArr1[3] = FilePath;
                Upload(sArguments1, "-u", strArr1);

                string[] strArr2 = new string[3];
                string sArguments2 = @"list_dir.py";
                strArr2[0] = DomainName;
                strArr2[1] = Username;
                strArr2[2] = Password;
                ListDir(sArguments2, "-u", strArr2);
            }
            //如果是文件，则进行下载
            else
            {
                string FileName = ServerListView.Items[i].SubItems[0].Text;

                string[] strArr1 = new string[4];//参数列表
                string sArguments1 = @"download.py";//这里是python的文件名字
                strArr1[0] = DomainName;
                strArr1[1] = Username;
                strArr1[2] = Password;
                strArr1[3] = FileName;
                Upload(sArguments1, "-u", strArr1);

                string[] strArr2 = new string[3];
                string sArguments2 = @"list_dir.py";
                strArr2[0] = DomainName;
                strArr2[1] = Username;
                strArr2[2] = Password;
                ListDir(sArguments2, "-u", strArr2);
            }
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.Items.Clear();
        }
    }
}
