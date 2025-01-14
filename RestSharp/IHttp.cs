﻿#region License

//   Copyright 2010 John Sheehan
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License. 

#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

using System.Net.Cache;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace RestSharp
{
    public interface IHttp
    {
        Action<Stream> ResponseWriter { get; set; }
        
        Action<Stream, IHttpResponse> AdvancedResponseWriter { get; set; }

        CookieContainer CookieContainer { get; set; }

        ICredentials Credentials { get; set; }

        /// <summary>
        /// Enable or disable automatic gzip/deflate/brotli decompression
        /// </summary>
        bool AutomaticDecompression { get; set; }

        /// <summary>
        /// Always send a multipart/form-data request - even when no Files are present.
        /// </summary>
        bool AlwaysMultipartFormData { get; set; }

        string UserAgent { get; set; }

        int Timeout { get; set; }

        int ReadWriteTimeout { get; set; }

        bool FollowRedirects { get; set; }

        bool Pipelined { get; set; }

        X509CertificateCollection ClientCertificates { get; set; }

        int? MaxRedirects { get; set; }

        bool UseDefaultCredentials { get; set; }

        Encoding Encoding { get; set; }

        IList<HttpHeader> Headers { get; }

        IList<HttpParameter> Parameters { get; }

        IList<HttpFile> Files { get; }

        IList<HttpCookie> Cookies { get; }

        string RequestBody { get; set; }

        string RequestContentType { get; set; }

        bool PreAuthenticate { get; set; }

        bool UnsafeAuthenticatedConnectionSharing { get; set; }

        RequestCachePolicy CachePolicy { get; set; }
        
        string ConnectionGroupName { get; set; }

        /// <summary>
        /// An alternative to RequestBody, for when the caller already has the byte array.
        /// </summary>
        byte[] RequestBodyBytes { get; set; }

        Uri Url { get; set; }

        string Host { get; set; }

        IList<DecompressionMethods> AllowedDecompressionMethods { get; set; }
            
        HttpWebRequest DeleteAsync(Action<HttpResponse> action);

        HttpWebRequest GetAsync(Action<HttpResponse> action);

        HttpWebRequest HeadAsync(Action<HttpResponse> action);

        HttpWebRequest OptionsAsync(Action<HttpResponse> action);

        HttpWebRequest PostAsync(Action<HttpResponse> action);

        HttpWebRequest PutAsync(Action<HttpResponse> action);

        HttpWebRequest PatchAsync(Action<HttpResponse> action);

        HttpWebRequest MergeAsync(Action<HttpResponse> action);

        HttpWebRequest AsPostAsync(Action<HttpResponse> action, string httpMethod);

        HttpWebRequest AsGetAsync(Action<HttpResponse> action, string httpMethod);

        HttpResponse Delete();

        HttpResponse Get();

        HttpResponse Head();

        HttpResponse Options();

        HttpResponse Post();

        HttpResponse Put();

        HttpResponse Patch();

        HttpResponse Merge();

        HttpResponse AsPost(string httpMethod);

        HttpResponse AsGet(string httpMethod);

        IWebProxy Proxy { get; set; }
        
        RemoteCertificateValidationCallback RemoteCertificateValidationCallback { get; set; }
        
        Action<HttpWebRequest> WebRequestConfigurator { get; set; }
    }
}
