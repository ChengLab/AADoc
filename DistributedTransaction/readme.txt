�ֲ�ʽ����demoʵ������netcore2.1ʵ�֡����ݿ�sqlserverʵ�ֵ�

���б�ʵ����Ҫ����������
1.��Ҫ�������� ���ݿ��˺� ���롢rabbitmq ���˺����룻
2.ִ��sql�ű� �������ݿ�ͱ�
3.��ʼAA_SecurityCode һ�����ݣ���Ϊ��Ϊ����ʾ������ĿAABase.Consumers��Ӳ������һ��_securityCodeRepository.Get("edb13d0b-004f-43e3-ab7f-e5e5e4a01665");


����˵����
Base.Web----������
AABase.Consumers----���ѷ�
Base.Timing----���Է�

powerDesigner �ṹ.png  ���ݱ�ṹͼ
dbinit.sql----���ݿ�ű�

Ϊ�˲��ԣ�����Ҫ��
[AA_SecurityCode]��  ��ʼ��һ���������£�
INSERT [dbo].[AA_SecurityCode] ([Id], [Code], [GmtCreate], [GmtModified], [EnabledState]) VALUES (N'edb13d0b-004f-43e3-ab7f-e5e5e4a01665', N'ab123cd', CAST(N'2019-08-16 00:00:00.000' AS DateTime), CAST(N'2019-08-16 00:00:00.000' AS DateTime), 1)

 �������н�ͼ
 ���н�ͼ.png