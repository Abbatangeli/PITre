USE [PCM_DEPOSITO_1]
GO
/****** Object:  StoredProcedure [DOCSADM].[sp_ARCHIVE_Delete_Transfer_All]    Script Date: 08/14/2013 11:50:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC   [DOCSADM].[sp_ARCHIVE_Delete_Transfer_All] 
AS
BEGIN
DELETE [DOCSADM].[ARCHIVE_Transfer]

END
GO
