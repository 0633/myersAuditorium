using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using rv;
using RestSharp;
using RestSharp.Authenticators;

/// <summary>
/// Operational Methods
/// 
/// Includes Projector On/Off, Screen Up/Down, Speaker Power Toggle, Extron Switch Selection
/// </summary>
public class Ops
{
	
        //Sets Extron Switch on COM1 to Specified Input. Current inputs are 1= Unused(VGA Only) 2=BoothPC 3=Sharelink 4=Blu-ray

        public void SetProjInput2()
        {
            System.Diagnostics.Process input2 = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfoInput2 = new System.Diagnostics.ProcessStartInfo();
            startInfoInput2.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfoInput2.FileName = "cmd.exe";
            startInfoInput2.Arguments = "/C mode COM1 BAUD=9600 PARITY=n DATA=8 & echo 2! > COM1";
            input2.StartInfo = startInfoInput2;
            input2.Start();
        }

        public void setProjInput3()
        {
            System.Diagnostics.Process input3 = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfoInput3 = new System.Diagnostics.ProcessStartInfo();
            startInfoInput3.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfoInput3.FileName = "cmd.exe";
            startInfoInput3.Arguments = "/C mode COM1 BAUD=9600 PARITY=n DATA=8 & echo 3! > COM1";
            input3.StartInfo = startInfoInput3;
            input3.Start();
        }

        public void setProjInput4()
        {
            System.Diagnostics.Process input4 = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfoInput4 = new System.Diagnostics.ProcessStartInfo();
            startInfoInput4.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfoInput4.FileName = "cmd.exe";
            startInfoInput4.Arguments = "/C mode COM1 BAUD=9600 PARITY=n DATA=8 & echo 4! > COM1";
            input4.StartInfo = startInfoInput4;
            input4.Start();
        }


        //Uses USB-HID-Relay to Lower/Raise the screen. Down is on Relay 2, Up is on Relay 1. Relays must be pulsed to apublic void damaging the screen.
        public void setScreenDown()
        {
            System.Diagnostics.Process usbrelayOn2 = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfousbrelayOn2 = new System.Diagnostics.ProcessStartInfo();
            startInfousbrelayOn2.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfousbrelayOn2.FileName = "usbrelay.exe";
            startInfousbrelayOn2.Arguments = "ON 2";
            usbrelayOn2.StartInfo = startInfousbrelayOn2;
            usbrelayOn2.Start();
            usbrelayOn2.WaitForExit();
            System.Diagnostics.Process usbrelayOff2 = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfousbrelayOff2 = new System.Diagnostics.ProcessStartInfo();
            startInfousbrelayOff2.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfousbrelayOff2.FileName = "usbrelay.exe";
            startInfousbrelayOff2.Arguments = "OFF 2";
            usbrelayOff2.StartInfo = startInfousbrelayOff2;
            usbrelayOff2.Start();

        }


        public void setScreenUp()
        {
            System.Diagnostics.Process usbRelayOn1 = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfousbRelayOn1 = new System.Diagnostics.ProcessStartInfo();
            startInfousbRelayOn1.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfousbRelayOn1.FileName = "usbrelay.exe";
            startInfousbRelayOn1.Arguments = "ON 1";
            usbRelayOn1.StartInfo = startInfousbRelayOn1;
            usbRelayOn1.Start();
            usbRelayOn1.WaitForExit();
            System.Diagnostics.Process usbRelayOff1 = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfousbRelayOff1 = new System.Diagnostics.ProcessStartInfo();
            startInfousbRelayOff1.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfousbRelayOff1.FileName = "usbrelay.exe";
            startInfousbRelayOff1.Arguments = "OFF 1";
            usbRelayOff1.StartInfo = startInfousbRelayOff1;
            usbRelayOff1.Start();

        }

        public void projOn()
        {
            PJLinkConnection proj = new PJLinkConnection("10.211.1.10", "info4scc"); //Creates an active connection to Projector via PJLink  
            proj.turnOn();

        }

        public void projOff()
        {
            PJLinkConnection proj = new PJLinkConnection("10.211.1.10", "info4scc"); //Creates an active connection to Projector via PJLink  
            proj.turnOff();
        }

        public void speakerPowerToggle()
        {
            var client = new RestClient("http://outlet");
            client.Authenticator = new HttpBasicAuthenticator("admin", "admin");

            var request1 = new RestRequest(Method.GET);
            request1.Resource = "cgi-bin/control.cgi?target=1&control=2";
            IRestResponse response1 = client.Execute(request1);

            var request2 = new RestRequest(Method.GET);
            request2.Resource = "cgi-bin/control.cgi?target=2&control=2";
            IRestResponse response2 = client.Execute(request2);


        }
    
}
