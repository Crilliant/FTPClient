'''
    Created by Cyx on 2022.7.16
    FTP列出当前目录
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