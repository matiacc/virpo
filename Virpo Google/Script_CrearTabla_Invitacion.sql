USE [VirpoDB]
GO
/****** Objeto:  Table [dbo].[Invitacion]    Fecha de la secuencia de comandos: 03/04/2010 23:20:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invitacion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idInvitado] [int] NULL,
	[idBanda] [int] NULL,
	[idInvitador] [int] NULL,
	[fechaInvitacion] [datetime] NULL,
 CONSTRAINT [PK_Invitacion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
