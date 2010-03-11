USE [VirpoDB]
GO
/****** Objeto:  StoredProcedure [dbo].[InvitacionInsertar]    Fecha de la secuencia de comandos: 03/04/2010 22:41:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InvitacionInsertar] 
			@usrInvitado int, 
			@idBanda int,
			@usrInvitador int,
			@fechaInvitacion datetime		
AS
BEGIN
		INSERT INTO Invitacion(idInvitado, idBanda, idInvitador, fechaInvitacion)
		VALUES(@usrInvitado, @idBanda, @usrInvitador, @fechaInvitacion)	
END
 


