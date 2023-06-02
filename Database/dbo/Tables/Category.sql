CREATE TABLE [dbo].[Category] (
    [Id]              INT                IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (50)      NOT NULL,
    [IsActive]        BIT                CONSTRAINT [DF_Category_IsActive] DEFAULT ((1)) NOT NULL,
    [IsDeleted]       BIT                CONSTRAINT [DF_Category_IsDeleted] DEFAULT ((0)) NOT NULL,
    [CreatedByUserId] NVARCHAR (450)     NOT NULL,
    [CreatedDate]     DATETIMEOFFSET (7) CONSTRAINT [DF_Category_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [UpdatedByUserId] NVARCHAR (450)     NULL,
    [UpdatedDate]     DATETIMEOFFSET (7) NULL,
    [DeletedByUserId] NVARCHAR (450)     NULL,
    [DeletedDate]     DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Category_CreatedByUser] FOREIGN KEY ([CreatedByUserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_Category_DeletedByUser] FOREIGN KEY ([DeletedByUserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_Category_UpdatedByUser] FOREIGN KEY ([UpdatedByUserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

