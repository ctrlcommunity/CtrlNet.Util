# CtrlNet.Util
CtrlNet.Util is an application framework under.net core platform, which is composed of common operation class (tool class), third-party component encapsulation, third-party business interface encapsulation and so on.
#
### Nuget Packages
| 包名称                                                         | Nuget稳定版本                                                                                                       | Nuget预览版本                                                                                                          | 下载数                                                                                                               |
|----------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------|
| [CtrlNet.Util](https://www.nuget.org/packages/CtrlNet.Util/) | [![CtrlNet.Util](https://img.shields.io/nuget/v/CtrlNet.Util.svg)](https://www.nuget.org/packages/CtrlNet.Util/) | [![CtrlNet.Util](https://img.shields.io/nuget/vpre/CtrlNet.Util.svg)](https://www.nuget.org/packages/CtrlNet.Util/) | [![CtrlNet.Util](https://img.shields.io/nuget/dt/CtrlNet.Util.svg)](https://www.nuget.org/packages/CtrlNet.Util/) |                                  

使用：

Install-Package CtrlNet.Util

1. The current extended class includes
Normal type conversions (String, DateTime, Int, Bool, Decimal, Double)
Json serialization and deserialization
String verification, judgment, conversion of Chinese pinyin, etc
There are also some general validation judgments
2. Security

2.1 the DES encryption
` ` ` csharp
/ / encryption
Var encryptStr = DESEncrypt. Encrypt (" XXXX ");
/ / decryption
Var STR = DESEncrypt. Decrypt (encryptStr);
` ` `
2.2 3 des encryption
` ` ` csharp
/ / encryption
Var STR = 3 desencrypt. Encrypt (" 123456 ");
/ / decryption
3 desencrypt. Decrypt (" STR ");
` ` `
3, the Http
` ` ` csharp
/ / synchronize
Var STR = HttpMethods. Post (" url ", "jsondata");
Var STR = HttpMethods. Get (" url ");
/ / asynchronous
Task < HttpResponseMessage > MSG = HttpMethods. PostAsync (" url ", "jsondata");
Task < HttpResponseMessage > MSG = HttpMethods. GetAsync (" url ");
` ` `
4. Guid operation
` ` ` csharp
/ / Guid operations
Guid Guid = CombUtil. NewComb ();
DateTime date = CombUtil. GetDateFromComb (guid);
` ` `
5. Binary serialization
` ` ` csharp
// binary serialization
Var binary = new BinarySerializer().Serialize("obj");
Var obj = new BinarySerializer (.) Deserialize (binary);
` ` `
6. Excel operation
` ` ` csharp
/ / export
ExcelHelper. ExportBytes (new List < object > (), the new string [1]).
/ / import
ExcelHelper. ExcelImport < object > (" filename ");
` ` `
7. Add object mapping
// deep copy
` ` ` csharp
MapperExtensions. Clone < Test > (test1);
` ` `
// object creation
` ` ` csharp
MapperExtensions. Map < TDestination > (source);
` ` `
Object creation
` ` ` csharp
MapperExtensions. Map < TSource, TDestination > (source);
` ` `
merge
` ` ` csharp
MapperExtensions. Map < TSource, TDestination > (source);
` ` `
There are also some general validation judgments
