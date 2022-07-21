'''
    Created by Cyx on 2022.7.21
    FTP连接
    调用：python connect.py r'ftp.dlptest.com' r'dlpuser' r'rNrKYTX9g7z3RgJRmxWuGHbeu'
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
    print('exception:' + str(err))
else:
    ftp = FTP(hostname, username, pwd)
    ftp.connect()
    ftp.disconnect()
    