using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Cache;
using System.IO;
using System.Threading;


using System.Xml;
using System.Xml.Serialization;
namespace LoadTesting
{

    [Serializable]
    public class postValue
    {
        string _strName = "";
        string _strValue = "";

        public string Name
        {
            get { return _strName; }
            set { _strName = value; }
        }

        public string Value
        {
            get { return _strValue; }
            set { _strValue = value; }
        }
    }

    public class progressResult
    {
        public int PercentageDone{get;set;}
        public int HttpRequestsDone{get;set;}
        public int HttpTotalRequests{get;set;}
    }


    [Serializable]
    public class httpTest
    {
        public event SetProgressBarCallback OnProgressChanged;
        public delegate void SetProgressBarCallback(progressResult result);


        private string _strUrl="";
        private string _strUserAgent = "";
        private string _strName = "";

        [NonSerialized]
        public List<testResult> testResults=new List<testResult>();

        public List<postValue>  postValues = new List<postValue>(); 
        private int _intNumberOfTests = 0;
        private int _intBatchSize = 0;
        private int _intSleepTime = 0;
        private DateTime _dtLastStartDate;
        private List<Thread> _ThreadHandles=new List<Thread>();

        public DateTime LastStartDate
        {
           get{ return _dtLastStartDate;}
        }

        public int BatchSize
        {
            get { return _intBatchSize; }
            set { _intBatchSize = value; }
        }

        public int SleepTime
        {
            get { return _intSleepTime; }
            set { _intSleepTime = value; }
        }

        public string Name
        {
            get { return _strName; }
            set { _strName = value; }
        }

        public int numberOfTests
        {
            get { return _intNumberOfTests; }
            set { _intNumberOfTests = value; }
        }

        public string userAgent
        {
            get { return _strUserAgent; }
            set { _strUserAgent = value; }
        }
        public string Url
        {
            get { return _strUrl; }
            set { _strUrl = value; }
        }

        private void ThreadProc(Object threadContext)
        {
            downloadUrl();
        }

        private int intStepsUpdate=0;
        private void StartTestProc(Object threadContext)
        {           
            testResults.Clear();
            _ThreadHandles.Clear();

            _dtLastStartDate = DateTime.Now;
           
            
            if (_intNumberOfTests < 0) { intStepsUpdate = 1; } else { intStepsUpdate = _intNumberOfTests / 100;}
            if (_intNumberOfTests < 100) { intStepsUpdate = 1; } 
            for (int i = 0; i < _intNumberOfTests; i++)
            {
               // ThreadPool.SetMaxThreads(_intBatchSize, _intBatchSize);
                //ThreadPool.QueueUserWorkItem(ThreadProc, doneEvents);
                
                Thread thrd = new Thread(ThreadProc);
                thrd.Start();
                if (_intSleepTime > 0 && _intBatchSize>0 && i>0)
                {
                    if(i % _intBatchSize ==0)
                    {
                        Thread.Sleep(new TimeSpan(0,0,0,0,_intSleepTime));
                    }
                    
                }
               _ThreadHandles.Add(thrd);



            }
        }
        private Thread thrdStartTests;
        public void startTest()
        {
            thrdStartTests = new Thread(StartTestProc);
            thrdStartTests.Start();
        }

        public void stopTest()
        {
            if(thrdStartTests!=null)
            {
                thrdStartTests.Abort();
            }
        }

        private static string fillInParameters(string url)
        {
            if(url.IndexOf("{rnd}")>-1)
            {
                var rnd = new Random();
                var nr=rnd.Next(0,500);
                url = url.Replace("{rnd}", Convert.ToString(nr));
            }
            return url;
        }

        private static HttpRequestCachePolicy noCachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
        public void downloadUrl()
        {
             
            var stopWatch =new  System.Diagnostics.Stopwatch();
            testResult tmpTest = new testResult();

            int intStatuscode = 0;
            long intTotalBytesRead = 0;
            try
            {
                 HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fillInParameters(_strUrl));
                 if (_strUserAgent != "")
                 {
                     request.UserAgent = _strUserAgent;
                 }
                 request.CachePolicy = noCachePolicy;
                 if (postValues.Count > 0)
                 {
                     request.Method = "POST";
                     request.ContentType = "application/x-www-form-urlencoded";
                     string strPostData = "";
                     foreach (postValue tmpValue in postValues)
                     {
                         strPostData += tmpValue.Name + "=" + System.Uri.EscapeDataString(tmpValue.Value);
                     }
                     byte[] byteArray = Encoding.UTF8.GetBytes(strPostData);
                     Stream postStream = request.GetRequestStream();
                     postStream.Write(byteArray, 0, byteArray.Length);
                     postStream.Close();
                 }
                 //request.CookieContainer.Capacity = 0;
                 stopWatch.Start();
                 HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                 stopWatch.Stop();

                 intTotalBytesRead=response.ContentLength;
                 /*if (HttpStatusCode.OK == response.StatusCode)
                 {
                     Stream dataStream = response.GetResponseStream();
                     dataStream.Close();
                 }

                 var bytesRead = default(int);
                 
                 var buffer = new byte[1024];
                 using (var memstream = new MemoryStream())
                 {
                     while ((bytesRead = dataStream.Read(buffer, 0, buffer.Length)) > 0)
                     {
                         intTotalBytesRead += bytesRead;
                     }
                 }*/
                 
                 intStatuscode = (int)response.StatusCode;
                 
                 response.Close();
             }
             catch (WebException e)
             {
                 using (WebResponse response = e.Response)
                 {
                     if (response != null)
                     {
                         HttpWebResponse httpResponse = (HttpWebResponse)response;
                         intStatuscode = (httpResponse != null) ? (int)httpResponse.StatusCode : 0;
                         intTotalBytesRead = response.ContentLength;
                     }
                 }
                 stopWatch.Stop();
             } 


             TimeSpan tmReqTime = stopWatch.Elapsed;
             TimeSpan tmDownTime = stopWatch.Elapsed;
             tmpTest.intConnectTimeMS = (long)tmReqTime.TotalMilliseconds;
             tmpTest.intDownTimeMS = (long)tmDownTime.TotalMilliseconds;
             tmpTest.intDownBytes = intTotalBytesRead;
             tmpTest.intHTTPStatus = intStatuscode;
             
             int intResultCount = 0;
             lock (testResults)
             { 
                    testResults.Add(tmpTest);
                    intResultCount = testResults.Count();
  
             }
             if (OnProgressChanged != null && intStepsUpdate>0)
             {
                 if (intResultCount % intStepsUpdate == 0 || _intNumberOfTests<100)
                 {
                      progressResult tmpResult = new progressResult();
                      tmpResult.HttpRequestsDone = _intNumberOfTests;
                      tmpResult.HttpTotalRequests = intResultCount;
                      tmpResult.PercentageDone = (int)(((double)intResultCount / (double)_intNumberOfTests) * 100d);
                      if (tmpResult.PercentageDone > 100) { tmpResult.PercentageDone = 100; }
                      OnProgressChanged(tmpResult);
                 }
             }



        }

    }
}
