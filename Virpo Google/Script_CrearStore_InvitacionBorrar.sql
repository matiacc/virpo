/****** Objeto:  StoredProcedure [dbo].[InvitacionBorrar]    Fecha de la secuencia de comandos: 03/10/2010 21:21:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InvitacionBorrar]

			@idInvitacion int
			
AS
BEGIN
		DELETE FROM Invitacion
		WHERE id = @idInvitacion 	
END

