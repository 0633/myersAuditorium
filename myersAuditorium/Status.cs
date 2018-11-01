using System;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;
using Response;


public class Status
    {
    public string speakerStatus()
        {
        var speakStatClient = new RestClient();
        speakStatClient.BaseUrl = new Uri("http://10.211.1.17");
        speakStatClient.Authenticator = new HttpBasicAuthenticator("admin", "admin");

        var speakStatRequest = new RestRequest();
        speakStatRequest.Resource = "/cgi-bin/control.cgi";

        IRestResponse speakStatResponse = speakStatClient.Execute(speakStatRequest);

        string speakerState = speakStatResponse.Content.Substring(45, 3);

        return speakerState;
    }
    }
