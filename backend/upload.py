'''
    Created by Cyx on 2022.7.16
    FTP上传文件
    调用：python upload.py ftp.dlptest.com dlpuser rNrKYTX9g7z3RgJRmxWuGHbeu 本地文件路径
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

try:
    ftp.connect()
    ftp.upload(file)
except Exception as err:
    #捕捉异常
    str = 'exception:' + str(err)
finally:
    ftp.disconnect()