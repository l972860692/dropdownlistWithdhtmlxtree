--first change you connectstring  database and uid pwd
CREATE TABLE [dbo].[Corps](
	[ID] [int]  NOT NULL,
	[ParentID] [int] NOT NULL,
	[Name] [varchar](20) NULL,
	[Sort] [decimal](10, 2) NULL,
)
insert into Corps select 1,0,'�Ϻ��ܹ�˾',null
insert into Corps select 2,1,'�Ĵ��ֹ�˾',null
insert into Corps select 3,1,'�����ܹ�˾',null
insert into Corps select 4,2,'��������',null
insert into Corps select 5,2,'��������',null
insert into Corps select 6,2,'�Ļ�����',null
insert into Corps select 7,5,'.net�з�',null
insert into Corps select 8,5,'java�з�',null
insert into Corps select 9,7,'ScreProject',null
insert into Corps select 10,7,'AMSProject',null
