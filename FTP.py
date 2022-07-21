'''
    Created by Cyx on 2022.7.21
    FTP基本类
'''

import ftplib
import os

class FTP():
    ftp_server = ftplib.FTP()
    hostname = 'ftp.dlptest.com'
    username = 'dlpuser'
    pwd = 'rNrKYTX9g7z3RgJRmxWuGHbeu'
    
    def __init__(self, hostname = 'ftp.dlptest.com',
                        username = 'dlpuser',
                        pwd = 'rNrKYTX9g7z3RgJRmxWuGHbeu'):
        self.hostname = hostname
        self.username = username
        self.pwd = pwd        

    # 连接服务器
    def connect(self):
        # print(self.hostname)
        # print(self.username)
        # print(self.pwd)
        try:
            # Connect FTP Server, 默认调用login()
            self.ftp_server = ftplib.FTP(self.hostname, 
                                self.username, 
                                self.pwd)
        except Exception as err:
            print("connect falut: "+str(err))
            return -1
        else:
            print("success connect")
        # force UTF-8 encoding
        self.ftp_server.encoding = "utf-8"
        return 0

    # 关闭连接
    def disconnect(self):
        self.ftp_server.quit()

    # 列出当前目录信息
    def list_dir(self):
        self.ftp_server.dir()

    # 修改当前路径. 
    def change_path(self, remotePath):
        try:
            self.ftp_server.cwd(remotePath)
        except Exception as err:
            print("path fault: "+str(err))
        finally:
            print("present working path:"+str(self.ftp_server.pwd()))   # 打印当前路径

    # 删除目录
    def delete_dir(self, dir):
        try:
            self.ftp_server.rmd(dir)
        except Exception as err:
            print("delete dir fault: "+str(err))

    # 新建目录
    def make_dir(self, dir):        
        try:
            self.ftp_server.mkd(dir)
        except Exception as err:
            print("make new dir fault: "+str(err))

    # 上传文件（断点重传）
    def upload(self, file):
        if not os.path.exists(file):
            print("Local file doesn't exists")
            return
        try:
            with open(file, "rb") as f:
                self.ftp_server.storbinary(f"STOR {file}", f)
        except Exception as err:
            print("upload fault: "+str(err))
        print("upload succsessfully")
        return 0
    
    # 下载文件（断点重传）
    def download(self, file):
        try:
            # Write file in binary mode
            with open(file, "wb") as f:
                # Command for Downloading the file "RETR filename"
                self.ftp_server.retrbinary(f"RETR {file}", f.write)
        except Exception as err:
            print("download fault: "+str(err))
        print("download succsessfully")
        return 0
    


if __name__ == "__main__":
    ftp = FTP_client(r"ftp.dlptest.com",'dlpuser','rNrKYTX9g7z3RgJRmxWuGHbeu')
    # ftp = FTP()
    ftp.connect()
    # ftp.list_dir()
    # ftp.upload('./cyx.txt')
    # ftp.download('cyx.txt')
    
    
    

