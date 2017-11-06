CREATE TABLE [dbo].[Employee] (
    [id]                      INT            IDENTITY (1, 1) NOT NULL,
    [fullName]                NVARCHAR (500) NOT NULL,
    [initiationDate]          DATE           NOT NULL,
    [fk_hiredfor]             INT            NOT NULL,
    [email]                   NVARCHAR (250) NOT NULL,
    [cellphone]               NVARCHAR (50)  NOT NULL,
    [startDate]               DATE           NOT NULL,
    [service_equipmentneeded] NVARCHAR (MAX) NOT NULL,
    [aditional_service]       NVARCHAR (500) NULL,
    [fk_companylist]          INT            NULL,
    [another_company]         NVARCHAR (250) NULL,
    [aditional_info]          NVARCHAR (500) NULL,
    [fk_buildingaccess]       INT            NULL,
    [another_building]        NVARCHAR (500) NULL,
    [restricted_access]       NVARCHAR (500) NULL,
    [hiringManagerEmail]      NVARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Employee_Building] FOREIGN KEY ([fk_buildingaccess]) REFERENCES [dbo].[Buildings] ([id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Employee_Company] FOREIGN KEY ([fk_companylist]) REFERENCES [dbo].[Company] ([id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Employee_HiredFor] FOREIGN KEY ([fk_hiredfor]) REFERENCES [dbo].[BeingHiredFor] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

