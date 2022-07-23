'''
    Created by Cyx on 2022.7.16
    FTP列出当前目录信息
    调用：python list_dir.py ftp.dlptest.com dlpuser rNrKYTX9g7z3RgJRmxWuGHbeu
'''

from FTP import FTP
import sys

try:
    # 获得命令行参数
    hostname = sys.argv[1]
    username = sys.argv[2]
    pwd = sys.argv[3]
except Exception as err:
    #捕捉异常
    str = 'exception:' + str(err)
    
ftp = FTP(hostname, username, pwd)
ftp.connect()
ftp.list_dir()
ftp.disconnect()