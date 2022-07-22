'''
    Created by Cyx on 2022.7.21
    FTP连接
    调用：python connect.py ftp.dlptest.com dlpuser rNrKYTX9g7z3RgJRmxWuGHbeu
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
    
try:
    ftp = FTP(hostname, username, pwd)
    ftp.connect()
except Exception as err:
    #捕捉异常
    print('exception:' + str(err))

finally:
    ftp.disconnect()
    