'''
    Created by Cyx on 2022.7.21
    FTP改变当前路径
'''

from FTP import FTP
import sys

try:
    # 获得命令行参数
    hostname = sys.argv[1]
    username = sys.argv[2]
    pwd = sys.argv[3]
    remote_path = sys.argv[4]
except Exception as err:
    #捕捉异常
    str = 'exception:' + str(err)
    
ftp = FTP(hostname, username, pwd)
ftp.connect()
ftp.change_path(remote_path)
ftp.disconnect()