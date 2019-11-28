# AlipaySdk

## Qc.AlipaySdk

`Qc.AlipaySdk` 基于 `.NET Standard 2.0` 构建，对支付宝开放平台的接口（网页授权登录）进行了封装。


### 使用 AlipaySdk


#### 一.安装程序包

[![Nuget](https://img.shields.io/nuget/v/Qc.AlipaySdk)](https://www.nuget.org/packages/Qc.AlipaySdk/)

- dotnet cli  
  `dotnet add package Qc.AlipaySdk`
- 包管理器  
  `Install-Package Install-Package Qc.AlipaySdk`

#### 二.添加配置

> 如需实现动态获取应用配置，可自行实现接口 `IAlipaySdkHook`  

```cs
using AlipaySdk;
public void ConfigureServices(IServiceCollection services)
{
  //...
  services.AddAlipaySdk<AlipaySdk.DefaultAlipaySdkHook>(opt =>
  {
      opt.AppId = "AppId";
      opt.AppPrivateKey = "应用私钥";
  });
  //...
}
```

#### 三.代码中使用

- 授权登录

 在需要地方注入`AlipayOauthSdkService`后即可使用

### AlipayConfig 配置项

- AppId: 应用ID
- AppPrivateKey： 私钥文本(使用支付宝开发平台助手生成)
- ApiAuthorizeUrl： 授权地址
- ApiGateway：支付宝网关地址
- Timeout：请求超时时间(s)

Alipay 文档地址: https://docs.open.alipay.com/284/web/

## 示例说明

`Qc.AlipaySdk.Sample` 为示例项目，可进行测试

## 发布历史

- v1.0.0
  - 初始化项目，接通支付宝登录接口