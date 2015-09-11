--first change you connectstring  database and uid pwd
CREATE TABLE [dbo].[Corps](
	[ID] [int]  NOT NULL,
	[ParentID] [int] NOT NULL,
	[Name] [varchar](20) NULL,
	[Sort] [decimal](10, 2) NULL,
)
insert into Corps select 1,0,'上海总公司',null
insert into Corps select 2,1,'四川分公司',null
insert into Corps select 3,1,'云南总公司',null
insert into Corps select 4,2,'行政部门',null
insert into Corps select 5,2,'技术部门',null
insert into Corps select 6,2,'文化部门',null
insert into Corps select 7,5,'.net研发',null
insert into Corps select 8,5,'java研发',null
insert into Corps select 9,7,'ScreProject',null
insert into Corps select 10,7,'AMSProject',null
