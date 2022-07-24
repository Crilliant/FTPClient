using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTP
{
    public class SimpleFile
    {
        public string createTime;
        public string name;
        public bool isDir;
        public bool download;//true: download; false: upload
        public Int64 size;

        public SimpleFile(string createTime, string name, bool isDir, Int64 size, bool download = true)
        {
            this.createTime = createTime;
            this.name = name;
            this.isDir = isDir;
            this.download = download;
            this.size = size;
        }
    }
}
