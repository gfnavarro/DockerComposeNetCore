CREATE TABLE [dbo].[TestTable](
     [Id] [int] IDENTITY(1,1) NOT NULL,
     [Value] [nvarchar](255) NULL
 ) ON [PRIMARY];
 
Insert into [dbo].[TestTable] ([Value]) values ('Test01');
Insert into [dbo].[TestTable] ([Value]) values ('Test02');
Insert into [dbo].[TestTable] ([Value]) values ('Test03');