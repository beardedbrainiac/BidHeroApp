CREATE TABLE [dbo].[Item] (
    [Id]              INT                IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (50)      NOT NULL,
    [Code]            NVARCHAR (50)      NOT NULL,
    [StartDate]       DATETIMEOFFSET (7) NOT NULL,
    [EndDate]         DATETIMEOFFSET (7) NOT NULL,
    [CategoryId]      INT                NOT NULL,
    [IsActive]        BIT                DEFAULT ((1)) NOT NULL,
    [IsDeleted]       BIT                NOT NULL,
    [CreatedByUserId] NVARCHAR (450)     NOT NULL,
    [CreatedDate]     DATETIMEOFFSET (7) DEFAULT (getutcdate()) NOT NULL,
    [UpdatedByUserId] NVARCHAR (450)     NULL,
    [UpdatedDate]     DATETIMEOFFSET (7) NULL,
    [DeletedByUserId] NVARCHAR (450)     NULL,
    [DeletedDate]     DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Item_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id]),
    CONSTRAINT [FK_Item_CreatedByUser] FOREIGN KEY ([CreatedByUserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_Item_DeletedByUser] FOREIGN KEY ([DeletedByUserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_Item_UpdatedByUser] FOREIGN KEY ([UpdatedByUserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Item_UpdatedByUserId]
    ON [dbo].[Item]([UpdatedByUserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Item_DeletedByUserId]
    ON [dbo].[Item]([DeletedByUserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Item_CreatedByUserId]
    ON [dbo].[Item]([CreatedByUserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Item_CategoryId]
    ON [dbo].[Item]([CategoryId] ASC);

