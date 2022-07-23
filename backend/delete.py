'''
    Created by Cyx on 2022.7.21
    FTP删除文件
    调用：python delete.py ftp.dlptest.com dlpuser rNrKYTX9g7z3RgJRmxWuGHbeu 服务器文件名
'''

from FTP import FTP
import sys

try:
    # 获得命令行参数
    hostname = sys.argv[1]
    username = sys.argv[2]
    pwd = sys.argv[3]
    file = sys.argv[4]
except Exception as err:
    #捕捉异常
    str = 'exception:' + str(err)
    
ftp = FTP(hostname, username, pwd)
ftp.connect()
ftp.delete(file)
ftp.disconnect()