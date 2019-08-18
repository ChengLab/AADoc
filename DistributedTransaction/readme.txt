分布式事务demo实例基于netcore2.1实现、数据库sqlserver实现的

运行本实例需要几步操作：
1.需要你配置下 数据库账号 密码、rabbitmq 的账号密码；
2.执行sql脚本 创建数据库和表
3.初始AA_SecurityCode 一条数据，因为我为了演示，在项目AABase.Consumers中硬编码了一句_securityCodeRepository.Get("edb13d0b-004f-43e3-ab7f-e5e5e4a01665");


其他说明：
Base.Web----生产方
AABase.Consumers----消费方
Base.Timing----重试方

powerDesigner 结构.png  数据表结构图
dbinit.sql----数据库脚本

为了测试，你需要在
[AA_SecurityCode]表  初始化一条数据如下：
INSERT [dbo].[AA_SecurityCode] ([Id], [Code], [GmtCreate], [GmtModified], [EnabledState]) VALUES (N'edb13d0b-004f-43e3-ab7f-e5e5e4a01665', N'ab123cd', CAST(N'2019-08-16 00:00:00.000' AS DateTime), CAST(N'2019-08-16 00:00:00.000' AS DateTime), 1)

 最终运行截图
 运行截图.png