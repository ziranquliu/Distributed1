using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace DistributedUtil.Helper
{
    /// <summary>
    /// ftp帮助类
    /// </summary>
    public class FtpHelper
    {
        #region 字段
        string ftpURI;
        string ftpUserID;
        string ftpServerIP;
        string ftpPassword;
        string ftpRemotePath;
        #endregion

        /// <summary>  
        /// 连接FTP服务器
        /// </summary>  
        /// <param name="FtpServerIP">FTP连接地址</param>  
        /// <param name="FtpRemotePath">指定FTP连接成功后的当前目录, 如果不指定即默认为根目录</param>  
        /// <param name="FtpUserID">用户名</param>  
        /// <param name="FtpPassword">密码</param>  
        public FtpHelper(string FtpServerIP, string FtpRemotePath, string FtpUserID, string FtpPassword)
        {
            ftpServerIP = FtpServerIP;
            ftpRemotePath = FtpRemotePath;
            ftpUserID = FtpUserID;
            ftpPassword = FtpPassword;
            ftpURI = "ftp://" + ftpServerIP + "/" + ftpRemotePath + "/";
        }

        /// <summary>  
        /// 上传  
        /// </summary>   
        public void Upload(string filename, Stream fs)
        {
            FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + filename));
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            reqFTP.KeepAlive = false;
            reqFTP.UseBinary = true;
            reqFTP.ContentLength = fs.Length;
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            try
            {
                Stream strm = reqFTP.GetRequestStream();
                int contentLen = fs.Read(buff, 0, buffLength);
                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                strm.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>  
        /// 创建文件夹  
        /// </summary>   
        public void MakeDir(string dirName, string ftppath)
        {
            try
            {
                FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftppath + "/" + dirName));
                reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                ftpStream.Close();
                response.Close();
            }
            catch (Exception) { }
        }

        /// <summary>
        /// 检测目录是否存在
        /// </summary>
        /// <param name="pFtpServerIP"></param>
        /// <param name="pFtpUserID"></param>
        /// <param name="pFtpPW"></param>
        /// <returns>false不存在，true存在</returns>
        public bool DirectoryIsExist(string ftpdirname)
        {
            string[] value = GetFileList(new Uri(ftpURI + "/" + ftpdirname));
            if (value == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string[] GetFileList(Uri pFtpServerIP)
        {
            StringBuilder result = new StringBuilder();
            try
            {
                FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(pFtpServerIP);
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
            }
            catch
            {
                return null;
            }
        }


        /// <summary>  
        /// 切换当前目录  
        /// </summary>  
        /// <param name="IsRoot">true:绝对路径 false:相对路径</param>   
        public void GotoDirectory(string DirectoryName, bool IsRoot)
        {
            if (IsRoot)
            {
                ftpRemotePath = DirectoryName;
            }
            else
            {
                ftpRemotePath += DirectoryName + "/";
            }
            ftpURI = "ftp://" + ftpServerIP + "/" + ftpRemotePath + "/";
        }

    }
}
