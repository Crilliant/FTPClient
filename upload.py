'''
    Created by Cyx on 2022.7.16
    FTP上传文件
'''

import utils
import sys

def upload(hostname, username, pwd, filename): 
    # 建立连接
    ftp_server = utils.connect(hostname, username, pwd)  
    # Read file in binary mode
    with open(filename, "rb") as file:
        # Command for Uploading the file "STOR filename"
        ftp_server.storbinary(f"STOR {filename}", file)
    # Close the Connection
    ftp_server.quit()

if __name__ == "__main__":
    try:
        # 获得命令行参数
        hostname = sys.argv[1]
        username = sys.argv[2]
        pwd = sys.argv[3]
        filename = sys.argv[4]
    except Exception as err:
        #捕捉异常
        str = 'exception:' + str(err)
    else:
        upload(hostname, username, pwd, filename) 
        str = 'successfully upload'       

    print(str)
