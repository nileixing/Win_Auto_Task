using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Win_Auto_Task
{
    class PubFun
    {  
        public static void WriteLog(string aMessage)
        {
            string filename = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "logs/log" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            if (!Directory.Exists(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + ("logs/")))
                Directory.CreateDirectory(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + ("logs/"));
            StreamWriter sr = null;

            var st = new System.Diagnostics.StackTrace();
            string name = st.GetFrame(1).ToString().Trim();

            try
            {
                if (!File.Exists(filename))
                {
                    sr = File.CreateText(filename);
                }
                else
                {
                    sr = File.AppendText(filename);
                }
                sr.WriteLine(string.Format("[{0}] \r\n [{2}] \r\n {1} \r\n ",
                    DateTime.Now.ToString("yy-MM-dd HH:mm:ss") + "." +
                    DateTime.Now.Millisecond.ToString().PadLeft(3, '0'), aMessage, name));
                sr.WriteLine();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
        } 

        public static string GetPage(string posturl, string postData, string token)
        {
            Stream outstream = null;
            Stream instream = null;
            StreamReader sr = null;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            Encoding encoding = Encoding.GetEncoding("GBK");

            //postData = postData.Replace("配送中心","pszx");
            byte[] data = Encoding.UTF8.GetBytes(postData);
            //encoding.GetBytes(postData);

            // 准备请求...  
            try
            {
                // 设置参数  
                request = WebRequest.Create(posturl) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = true;
                request.Method = "POST";
                request.Headers.Set("Authorization", "Bearer " + token);
                //request.ContentType = "application/x-www-form-urlencoded";
                request.ContentType = "application/json";
                request.ContentLength = data.Length;
                outstream = request.GetRequestStream();
                outstream.Write(data, 0, data.Length);
                outstream.Close();
                //发送请求并获取相应回应数据  
                response = request.GetResponse() as HttpWebResponse;

                //直到request.GetResponse()程序才开始向目标网页发送Post请求  
                instream = response.GetResponseStream();
                sr = new StreamReader(instream, Encoding.UTF8);
                //返回结果网页（html）代码  
                string content = sr.ReadToEnd();
                return content;
            }
            catch (Exception ex)
            {
                string err = "{\"code\": -999,\"message\": \"" + ex.Message + "\"}";
                //    err ="{\"data\": {\"retmessage\": \"医保通返回：007，现金销售信息上传:交易明细json体不是正确的json数据结构，无法执行上传操作！\",\"returncode\": \"-1\"},\"detailMessage\": \"\",\"mainMessage\": \"\", \"messageCode\": \"0\"}";

                return err;
            }
            finally
            {
                try
                {
                    response.Close();
                    sr.Close();
                }
                catch { }
            }
        }

        public static string GetPage(string posturl, string postData)
        {
            PubFun.WriteLog("posturl:" + posturl + "\r\npostData:" + postData);
            Stream stream = null;
            Stream stream2 = null;
            StreamReader streamReader = null;
            HttpWebResponse httpWebResponse = null;
            HttpWebRequest httpWebRequest = null;
            Encoding encoding = Encoding.GetEncoding("GBK");
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            try
            {
                ServicePointManager.Expect100Continue = false;
                httpWebRequest = (WebRequest.Create(posturl) as HttpWebRequest);
                CookieContainer cookieContainer2 = httpWebRequest.CookieContainer = new CookieContainer();
                httpWebRequest.AllowAutoRedirect = true;
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.ContentLength = bytes.Length;
                stream = httpWebRequest.GetRequestStream();
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
                httpWebResponse = (httpWebRequest.GetResponse() as HttpWebResponse);
                stream2 = httpWebResponse.GetResponseStream();
                streamReader = new StreamReader(stream2, Encoding.UTF8);
                string res = streamReader.ReadToEnd();
                PubFun.WriteLog(res);
                return res;
            }
            catch (Exception ex)
            {
                return "{\"code\": -999,\"message\": \"" + ex.Message + "\"}";
            }
            finally
            {
                try
                {
                    httpWebResponse.Close();
                    streamReader.Close();
                }
                catch
                {
                }
            }
        }

        public static string GetPage_Https(string url, string postData)
        {
            HttpWebRequest request = null;
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                request = WebRequest.Create(url) as HttpWebRequest;
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request.ProtocolVersion = HttpVersion.Version11;
                // 这里设置了协议类型。
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;// SecurityProtocolType.Tls1.2; 
                request.KeepAlive = false;
                ServicePointManager.CheckCertificateRevocationList = true;
                ServicePointManager.DefaultConnectionLimit = 100;
                ServicePointManager.Expect100Continue = false;
                string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "appst.cer";
                X509Certificate cert = new X509Certificate(filePath);
                //将证书添加客户端证书集合 
                request.ClientCertificates.Add(cert);
            }
            else
            {
                request = (HttpWebRequest)WebRequest.Create(url);
            }

            request.Method = "POST";    //使用get方式发送数据
            request.ContentType = "application/x-www-form-urlencoded";
            request.Referer = null;
            request.AllowAutoRedirect = true;
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.2; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            request.Accept = "*/*";

            byte[] data = Encoding.UTF8.GetBytes(postData);
            Stream newStream = request.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            //获取网页响应结果
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            //client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            string result = string.Empty;
            using (StreamReader sr = new StreamReader(stream))
            {
                result = sr.ReadToEnd();
            }

            return result;
        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        }

        public static string GetPage_Get(string Url, string postDataStr)
        {
            Stream myResponseStream = null;
            StreamReader myStreamReader = null;
            string retString = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                myResponseStream = response.GetResponseStream();
                myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                retString = myStreamReader.ReadToEnd();

                PubFun.WriteLog("posturl:" + Url + "\r\npostData:" + retString);
            }
            catch (Exception ex)
            {
                string err = "{\"code\": -999,\"message\": \"" + ex.Message + "\"}";
                //    err ="{\"data\": {\"retmessage\": \"医保通返回：007，现金销售信息上传:交易明细json体不是正确的json数据结构，无法执行上传操作！\",\"returncode\": \"-1\"},\"detailMessage\": \"\",\"mainMessage\": \"\", \"messageCode\": \"0\"}";

                return err;
            }
            finally
            {
                try
                {
                    myStreamReader.Close();
                    myResponseStream.Close();
                }
                catch { }
            }
            return retString;
        }

        public static DataSet Query(string SQLString,string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    WriteLog(connectionString + "\r\n" + SQLString + "\r\n" + ex.Message.ToString());
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        public static DataSet Query(string SQLString, IDataParameter[] sqlps,string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    DataSet dataSet = new DataSet();
                    connection.Open();
                    SqlDataAdapter sqlDA = new SqlDataAdapter();
                    SqlCommand comm = BuildQueryCommand(connection, SQLString, sqlps);
                    sqlDA.SelectCommand = comm;
                    sqlDA.Fill(dataSet, "ds");

                    WriteLog("strsql:" + SQLString + "\r\n" + "Parameters:" + comm.Parameters[0].Value + "\r\n" + comm.Parameters[0].ParameterName + "\r\n" + comm.Parameters[1].Value);
                    connection.Close();

                    WriteLog(dataSet.Tables[0].Rows[0][1].ToString());
                    return dataSet;
                }
            }
            catch (SqlException ex)
            {
                WriteLog_Error(ex);
                return new DataSet();
            }
        }
         
        public static DataTable Query_dt(string SQLString,string connectionString)
        {
            try
            {
                //PubFun.WriteLog("SQLString:" + SQLString + "connectionString:" + connectionString);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        connection.Open();
                        SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                        command.Fill(ds, "ds");
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }

                    if (ds.Tables.Count > 0)
                    {
                        return ds.Tables[0];
                    }

                    return new DataTable();
                }
            }
            catch
            {
                WriteLog(SQLString + "\r\n" + connectionString);
                return new DataTable();
            }
        } 

        private static Encoding _encoding = System.Text.Encoding.GetEncoding("GB2312"); 

        internal static void WriteLog_Error(Exception ex)
        {
            string aMessage = ex.Message + "\r\n" + ex.StackTrace;

            string filename = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "errs/log" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            if (!Directory.Exists(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + ("errs/")))
                Directory.CreateDirectory(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + ("errs/"));
            StreamWriter sr = null;

            var st = new System.Diagnostics.StackTrace();
            string name = st.GetFrame(1).ToString().Trim();

            try
            {
                if (!File.Exists(filename))
                {
                    sr = File.CreateText(filename);
                }
                else
                {
                    sr = File.AppendText(filename);
                }
                sr.WriteLine(string.Format("[{0}] \r\n [{2}] \r\n {1} \r\n ",
                    DateTime.Now.ToString("yy-MM-dd HH:mm:ss") + "." +
                    DateTime.Now.Millisecond.ToString().PadLeft(3, '0'), aMessage, name));
                sr.WriteLine();
            }
            catch (Exception e)
            {

            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
        }  
    
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // 检查未分配值的输出参数,将其分配以DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        } 
    }
}
