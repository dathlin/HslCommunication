<pre>
             ///\      ///\             /////////\              ///\
            //\\/      //\/           //\\\\\\\\//\            //\\/
           //\/       //\/          //\\/       \\/           //\/
          //\/       //\/           \//\                     //\/
         /////////////\/             \//////\               //\/
        //\\\\\\\\\//\/               \\\\\//\             //\/
       //\/       //\/                     \//\           //\/
      //\/       //\/           ///\      //\\/          //\/       //\
     ///\      ///\/            \/////////\\/           /////////////\/
     \\\/      \\\/              \\\\\\\\\/             \\\\\\\\\\\\\/             Present by Richard.Hu
</pre>

# HslCommunication

![Build status](https://img.shields.io/badge/Build-Success-green.svg) [![NuGet Status](https://img.shields.io/nuget/v/HslCommunication.svg)](https://www.nuget.org/packages/HslCommunication/) ![NuGet Download](https://img.shields.io/nuget/dt/HslCommunication.svg) [![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/HslCommunication/community) [![NetFramework](https://img.shields.io/badge/Language-C%23%207.0-orange.svg)](https://blogs.msdn.microsoft.com/dotnet/2016/08/24/whats-new-in-csharp-7-0/) [![Visual Studio](https://img.shields.io/badge/Visual%20Studio-2019-red.svg)](https://www.visualstudio.com/zh-hans/) ![copyright status](https://img.shields.io/badge/CopyRight-Richard.Hu-brightgreen.svg) 

[HslCommunication.jar](https://github.com/dathlin/HslCommunicationJavaDemo)

![Build status](https://img.shields.io/badge/Build-Success-green.svg) ![NetFramework](https://img.shields.io/badge/Language-java-orange.svg) ![version](https://img.shields.io/maven-central/v/com.github.dathlin/HslCommunication) ![JDK status](https://img.shields.io/badge/JDK-1.8.0-green.svg) ![IDE status](https://img.shields.io/badge/Intellij%20Idea-2018.4-red.svg) ![copyright status](https://img.shields.io/badge/CopyRight-Richard.Hu-brightgreen.svg) 

[HslCommunication.py](https://github.com/dathlin/HslCommunicationPython)

![Build status](https://img.shields.io/badge/Build-Success-green.svg) ![NetFramework](https://img.shields.io/badge/python-3.6-orange.svg) ![version](https://img.shields.io/pypi/v/HslCommunication) ![download](https://img.shields.io/pypi/dm/HslCommunication) ![IDE status](https://img.shields.io/badge/Visual%20Studio-Code-red.svg) ![copyright status](https://img.shields.io/badge/CopyRight-Richard.Hu-brightgreen.svg) 

## CopyRight
(C) 2017 - 2023 Richard.Hu, All Rights Reserved

## Authorization(授权)
具体可以参照 http://www.hsltechnology.cn/Home/Licence?area=HslCommunication

试用授权： 加入 **技术支持VIP群** 即可以获得激活码，支持长时间测试使用。企业用户可以联系微信:13516702732 申请试用的证书
```
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main( )
        {
            // 授权示例   调用一次即可  call only once
            if(!HslCommunication.Authorization.SetAuthorizationCode( "你的激活码" ))
            {
                MessageBox.Show( "授权失败！当前程序只能使用8小时！" );
                return;
            }


            Application.EnableVisualStyles( );
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new Form1( ) );
        }
```

商用授权（赠送源代码）: 
   1. 公对公签订合同。
   2. 公对公打款，开具增值税发票。
   3. 获取专用的软件，账户，来下载最新的源代码，激活码
   4. 企业专业培训额外付费，1000元人民币1小时，培训控件使用，控件开发。

## Official Website
Webside: [http://www.hslcommunication.cn/](http://www.hslcommunication.cn/)

API: [http://api.hslcommunication.cn/](http://api.hslcommunication.cn/)

Gitter[talk with me]: [https://gitter.im/HslCommunication/community](https://gitter.im/HslCommunication/community)

## What is HSL
This is an industrial IoT based, computer communications architecture implementation, integrated with most of the basic functional implementation of industrial software development, 
such as Mitsubishi PLC Communications, Siemens PLC Communications, OMRON PLC Communications, Modbus Communications,
All of these communications have been implemented in multiple languages, and of course, the feature integration of the main. NET Library is even more powerful, 
in addition to the implementation of cross-program, cross-language, cross-platform communication, so that you are no longer obsessed with the use of Windows or Linux system, 
the realization of log function, flow number generation function, mail sending function, Fourier transform function, and so on, 
will integrate more common features of industrial environment in the future.

In order not to let the industry 4.0 stay on the slogan, the high-rise flat up, and the cornerstone is HSL.

## What can HSL do
HSL can connect the equipment of the industrial production site to the free transmission of data at the bottom, whether active or passive, 
whatever your acquisition system (usually the acquisition system is a Windows computer, or an embedded system, or a Linux-based box),
can achieve the random transmission of data, convenient and fast to achieve a strong, real-time, high-response robust system, whether you are building a C/S system, 
or B/S system, or C-B-S-A (Integrated desktop client, browser, Android) hybrid system, is a fast and low-cost implementation,

As long as you have the primary data of the industrial field, that is, can build a powerful real-time monitoring function of the software,
production reports and automated scheduling software, a variety of process parameters history tracking software, data based on the experience of machine learning software, 
as well as full-featured MES system and so on. 

**By the way**, the traditional industrial model is the procurement of off-the-shelf industrial software, 
including the host computer software and MES system, while ignoring their own system.
For some industry-standard functional software, such as ERP systems, financial software, these can be purchased directly,
However, for the host computer and MES system, the actual needs of each enterprise are very different, it is difficult to have a common scene, 
and the current situation is to spend a lot of money to do small things, so here, give a future-oriented model to achieve: for the production enterprise, 
Based on HSL to develop enterprise-class MES system implementation, as the core Warehouse center of data, and business logic processing Center, 
for equipment suppliers, based on HSL to develop the host computer software system, fast and convenient distribution of data to the customer's MES system, work together.

## Install From NuGet
Description: NuGet for stable version, Support Online upgrade, the use of components is best downloaded from NuGet, 
the project published here is likely to have not yet compiled the beta version, NuGet installation is as follows:
```
Install-Package HslCommunication
```

## HslCommunication.dll Summary 
When I started working on this project, I had an idea of how to easily and quickly read and write PLC data. Our code logic should be very simple, 
and it only takes one or two lines of code to implement this feature. Like this
```
// Pseudo code
PLC plc = new PLC("192.168.0.11", 6000);

short value = plc.ReadInt16("D100");
```
But after a long period of development and attempt, found that the return of PLC is likely to be abnormal, this anomaly may come from the network failure, 
may also come from you entered the wrong address, or the PLC itself is not allowed to operate, so in this project added a class **Operateresult**, 
So the final code becomes what it looks like (with Siemens PLC as an example)
```
SiemensS7Net siemens = new SiemensS7Net( SiemensPLCS.S1200, " 192.168.1.110" );
OperateResult<short> read = siemens.ReadInt16("M100");

if(read.IsSuccess)
{
	// you get the right value
	short value = read.Content;
}
else
{
	// failed , but you still can know the failed detail
	Consolo.WriteLine(read.Message);
}
```
Of course, you can also write very concise, because the judgment of success is ignored, so the following operation is risky.
```
SiemensS7Net siemens = new SiemensS7Net( SiemensPLCS.S1200, " 192.168.1.110" );
short value = siemens.ReadInt16("M100").Content;   // Look at this code, isn't it very succinct.
```
When use .Net4.5 or higher plateform. we can use like this
```
SiemensS7Net siemens = new SiemensS7Net( SiemensPLCS.S1200, " 192.168.1.110" );
short value = (await siemens.ReadInt16Async("M100")).Content;   // Look at this code, isn't it very succinct.
```

The above operation we have read the data, but is based on a short connection, 
when the reading of the data finished, automatically shut down the network, 
if you want to open a long connection, follow the following actions.

```
SiemensS7Net siemens = new SiemensS7Net( SiemensPLCS.S1200, " 192.168.1.110" );
siemens.SetPersistentConnection( );
OperateResult<short> read = siemens.ReadInt16("M100");

if(read.IsSuccess)
{
	// you get the right value
	short value = read.Content;
}
else
{
	// failed , but you still can know the failed detail
	Consolo.WriteLine(read.Message);
}

// when you don't want read data, you should call close method
siemens.ConnectClose( );

```
When use .Net4.5 or higher plateform. we can use like this
```
SiemensS7Net siemens = new SiemensS7Net( SiemensPLCS.S1200, " 192.168.1.110" );
siemens.SetPersistentConnection( );
OperateResult<short> read = await siemens.ReadInt16Async("M100");

if(read.IsSuccess)
{
	// you get the right value
	short value = read.Content;
}
else
{
	// failed , but you still can know the failed detail
	Consolo.WriteLine(read.Message);
}

// when you don't want read data, you should call close method
siemens.ConnectClose( );

```

So we can see that all the other modes of communication are similar to this, including Mitsubishi PLC, Siemens PLC,AB PLC, OMRON PLC, Keane plc, Panasonic Plc,
redis Communications, EFT Robots, Kuka robots and so on, including its own support for the HSL protocol.

The goal is to reduce the cost of learning for developers, and usually you have to learn how to use several different libraries and learn the basics of PLC. Now, 
all you need to know is how the basic PLC address is represented, and you can read and write PLC data.


Called from Visual C++ project

cppProject -> Properties -> Configuration Properties -> General -> CLR Support

Add HslCommunication.dll(net35) reference
```
#include "pch.h"
#include <iostream>
using namespace HslCommunication;
using namespace ModBus;

int main()
{
    std::cout << "Hello World!\n";


	// This is the demo , called C# ModbusTcpNet
	System::String ^ipAddress = gcnew System::String("127.0.0.1");
	ModbusTcpNet ^modbus = gcnew ModbusTcpNet(ipAddress, 502, 1);

	System::String ^dataAddress = gcnew System::String("100");
	OperateResult<short> ^readValue = modbus->ReadInt16(dataAddress);
	if (readValue->IsSuccess) {
		short value = readValue->Content;
		printf("Read Value：%d \n", value);
	}
	else
	{
		printf("Read Failed");
	}
}
```

If you want to communication in your mobile phone application, you also can use C# code by xamarin, you can download HslAppDemo to test
[HslAppDemo.apk](https://github.com/dathlin/HslCommunication/raw/master/Download/com.companyname.HslAppDemo-Signed.apk)


Another feature of this project is support for cross-language communication support. You can build a C # background server that supports Windows desktop application 
and Web background, and Android phone-side, Python programs, Java programs to communicate. server side code:
```
class Program
{
    static void Main(string[] args)
    {
		NetSimplifyServer simplifyServer;
		try
		{
			simplifyServer = new NetSimplifyServer( );
			simplifyServer.ReceiveStringEvent += SimplifyServer_ReceiveStringEvent;
			simplifyServer.ServerStart( 12345 );
		}
		catch(Exception ex )
		{
			Console.WriteLine( "Create failed: " + ex.Message );
			Return;
		}

		Console.ReadLine();
	}

	private static void SimplifyServer_ReceiveStringEvent( AppSession session, NetHandle handle, string value )
	{
		if (handle == 1)
		{
			// Message to operate when a signal from the client is received 1
			simplifyServer.SendMessage( session, handle, "This is test single：" + value );
		}
		else
		{
			simplifyServer.SendMessage( session, handle, "not supported msg" );
		}
	
		// Show out, who sent it, what did it send?
		Console.WriteLine($"{session} [{handle}] {value}");
	}
}
```
C# Client Side (Also asp.net mvc, asp.net core mvc)
```
NetSimplifyClient simplifyClient = new NetSimplifyClient( "127.0.0.1", 12345 );
string value = simplifyClient.ReadFromServer( 1, "test" ).Content;
```
Java Client Side
```
NetSimplifyClient simplifyClient = new NetSimplifyClient( "127.0.0.1", 12345 );
string value = simplifyClient.ReadFromServer( 1, "test" ).Content;
```
Python Client Side
```
netSimplifyClient = NetSimplifyClient("127.0.0.1",12345)
value = netSimplifyClient.ReadFromServer(1,'123').Content
```

**Note**: In the source code, still contains a lot of Chinese annotation, in the future for a short period of time, 
will be used in English and Chinese double annotation, thank you for your understanding.

**HslCommunicationDemo** The features supported by this project can be roughly clear through the demo interface below:
![Picture](https://raw.githubusercontent.com/dathlin/HslCommunication/master/imgs/demo.png)


## HslCommunication.jar Summary 
This component provides the Java version, for the. NET version of the castration version, removed all the server function code, 
retained part of the client function code, convenient and plc, device data interaction, and C # program data interaction, 
this jar component is suitable for the development of Android, easy to build a. NET Server + Windows Client + asp.net client + J2EE client + Java Client + Android client.
![Picture](https://raw.githubusercontent.com/dathlin/HslCommunication/master/imgs/java_demo.png)

## HslCommunication.py Summary 
This component provides a Python version, a castration version of the. NET version, removes all server function codes, retains some of the client function code, 
facilitates data interaction with PLC, devices, and data interaction with C # programs for cross-platform operation
![Picture](https://raw.githubusercontent.com/dathlin/HslCommunication/master/imgs/python_demo.png)

## Xamarin.Android Demo
![Picture](https://raw.githubusercontent.com/dathlin/HslCommunication/master/imgs/appDemo.png)

## Where is the Source code?
Not free open source. you can refer to webside: http://www.hslcommunication.cn/Cooperation

## How to sponsor author?

[PayPal](https://www.PayPal.Me/hslcommunication)

![Alipay](https://raw.githubusercontent.com/dathlin/HslCommunication/master/imgs/support.png)

Thank you for your understanding 
