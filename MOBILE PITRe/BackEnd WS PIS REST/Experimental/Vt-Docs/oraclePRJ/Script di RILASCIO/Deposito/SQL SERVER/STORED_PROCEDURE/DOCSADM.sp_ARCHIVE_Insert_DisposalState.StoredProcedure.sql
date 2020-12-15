USE [PCM_DEPOSITO_1]
GO
/****** Object:  StoredProcedure [DOCSADM].[sp_ARCHIVE_Insert_DisposalState]    Script Date: 08/14/2013 11:50:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC   [DOCSADM].[sp_ARCHIVE_Insert_DisposalState]  ( @Disposal_ID int , @DisposalStateType_ID int , @System_ID int OUTPUT )
AS
BEGIN
INSERT INTO [DOCSADM].[ARCHIVE_DisposalState] ( [Disposal_ID], [DisposalStateType_ID], [DateTime] ) 
VALUES ( @Disposal_ID, @DisposalStateType_ID, getdate() ) 
SET @System_ID = SCOPE_IDENTITY()
END
GO
