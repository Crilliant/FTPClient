'''
    Created by Cyx on 2022.7.16
    FTP建立连接
'''

import ftplib
import sys

# 连接服务器
def connect(hostname, username, pwd):
    try:
        # Connect FTP Server
        ftp_server = ftplib.FTP(hostname, username, pwd)
    except Exception as err:
        print("connect falut: "+str(err))
    else:
        print("success connect")

    # force UTF-8 encoding
    ftp_server.encoding = "utf-8"
    return ftp_server

if __name__ == "__main__":
    try:
        # 获得命令行参数
        hostname = sys.argv[1]
        username = sys.argv[2]
        pwd = sys.argv[3]
    except Exception as err:
        #捕捉异常
        str = 'exception:' + str(err)

    # print(str)
   # 建立连接
    ftp_server = connect(hostname, username, pwd)  
    # Get list of files
    ftp_server.dir()

    # Close the Connection
    ftp_server.quit()
